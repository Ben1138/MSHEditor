using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using LibSWBF2;
using LibSWBF2.MSH;
using LibSWBF2.MSH.Types;
using LibSWBF2.MSH.Chunks;
using LibSWBF2.Exceptions;

namespace MSHEditor {
    public partial class EditorForm : Form {
        MSH msh;
        BaseChunk selectedChunk = null;
        FileInfo mshFile;

        TreeNode materialsNode;
        TreeNode modelsNode;

        GLDraw glDraw;
        Point mousePos;
        bool rotateCamera = false;
        bool translateCamera = false;

        public EditorForm() {
            InitializeComponent();
        }

        private void OpenMSH(string path) {
            bool success = false;

            try {
                msh = MSH.LoadFromFile(path);
                success = true;
            }
            catch (FileNotFoundException) {
                MessageBox.Show(path + " could not be found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException) {
                MessageBox.Show(path + " is not a valid File!", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InsufficientPermissionsException) {
                MessageBox.Show("Insufficient permissions on File " + path, "Insufficient Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException) {
                MessageBox.Show("Error while reading/writing File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EndOfDataException) {
                MessageBox.Show("Unexpected end of Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidChunkException) {
                MessageBox.Show("Corrupted Chunk Data found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //takes way too long
            //foreach (string line in Log.GetLastLines(LogType.Info))
            //textBox1.AppendText(line + "\n");

            logBox.Lines = Log.GetAllLines(LogType.Info);

            if (success) {
                mshView.Enabled = true;
                inspector.Enabled = true;
                checkToolStripMenuItem.Enabled = true;
                materialToolStripMenuItem.Enabled = true;
                modelToolStripMenuItem.Enabled = true;
                segmentToolStripMenuItem.Enabled = true;

                mshFile = new FileInfo(path);

                CheckMSH(false);
                RefreshTreeView();

                glDraw.LoadTextures(BuildTextureList());
                glDraw.SegmentsToRender = GetSegmentsFromSelection();
            }
        }

        private void ApplyEditorAttributes() {
            if (msh != null) {
                foreach (MATD mat in msh.Materials) {
                    mat.Attribute = mat.Attribute;
                }
            }
        }

        private FileInfo[] BuildTextureList() {
            List<FileInfo> texList = new List<FileInfo>();

            foreach (MATD mat in msh.Materials) {
                foreach (string texName in mat.Textures) {
                    if (!string.IsNullOrEmpty(texName)) {
                        string[] result = Directory.GetFiles(mshFile.DirectoryName, texName, SearchOption.AllDirectories);

                        if (result.Length > 0) {
                            FileInfo tgaFile = new FileInfo(result[0]);

                            if (tgaFile.Exists) {
                                if (!texList.Contains(tgaFile))
                                    texList.Add(tgaFile);
                            }
                            else {
                                MessageBox.Show("Could not find Texture '" + tgaFile.FullName + "' !", "Texture not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else {
                            MessageBox.Show("Could not find Texture '" + texName + "' !", "Texture not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            return texList.ToArray();
        }

        private void SaveMSH(string path) {
            try {
                msh.WriteToFile(path);
            }
            catch (FileNotFoundException) {
                MessageBox.Show(path + " could not be found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException) {
                MessageBox.Show(path + " is not a valid File!", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InsufficientPermissionsException) {
                MessageBox.Show("Insufficient permissions on File " + path, "Insufficient Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException) {
                MessageBox.Show("Error while reading/writing File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EndOfDataException) {
                MessageBox.Show("Unexpected end of Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidChunkException) {
                MessageBox.Show("Corrupted Chunk Data found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            logBox.Lines = Log.GetAllLines(LogType.Info);
        }

        private void RefreshTreeView() {
            mshView.Nodes.Clear();

            if (msh != null) {
                if (msh.SelectionInformation != null) {
                    TreeNode sinf = mshView.Nodes.Add("Selection Information");
                    sinf.Name = "SINF";
                    sinf.Nodes.Add("Frame Information").Name = "FRAM";
                    sinf.Nodes.Add("Bounding Box").Name = "BBOX";
                }

                if (msh.Camera != null)
                    mshView.Nodes.Add("Camera").Name = "CAMR";

                materialsNode = mshView.Nodes.Add("Materials");
                materialsNode.Name = "MATL";

                modelsNode = mshView.Nodes.Add("Models");
                modelsNode.Name = "MODL";


                for (int i = 0; i < msh.Materials.Count; i++) {
                    materialsNode.Nodes.Add(msh.Materials[i].Name).Name = "MAT" + i;
                }

                for (int i = 0; i < msh.Models.Count; i++) {
                    TreeNode node = modelsNode.Nodes.Add(msh.Models[i].Name);
                    node.Name = "MOD" + i;

                    if (msh.Models[i].Geometry != null) {
                        node.Nodes.Add("Bounding Box").Name = "GBOX" + i;

                        for (int j = 0; j < msh.Models[i].Geometry.Segments.Length; j++) {
                            node.Nodes.Add("Segment " + (j + 1)).Name = "SEG" + i + "." + j;
                        }
                    }
                }
            }
        }

        private void CheckMSH(bool showSuccess) {
            CheckResult check = msh.CheckIntegrity();
            string checkMsg = "";

            foreach (string msg in check.Messages) {
                checkMsg += "\n" + msg;
                logBox.Text += checkMsg;
            }

            if (check.IsValid) {
                if (showSuccess)
                    MessageBox.Show("No Errors found", "Nice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(checkMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SEGMDraw[] GetSegmentsFromSelection() {
            List<SEGMDraw> segments = new List<SEGMDraw>();

            void AddModl(MODL m) {
                if (m.Geometry != null) {
                    foreach (SEGM segm in m.Geometry.Segments) {
                        AddSegm(segm, m);
                    }
                }
            }

            void AddSegm(SEGM s, MODL m) {
                ModelTag t = ModelTag.Common;

                if (m != null)
                    t = m.Tag;

                segments.Add(new SEGMDraw() { segment = s, tag = t });
            }

            if (selectedChunk is MODL) {
                AddModl((MODL)selectedChunk);
            }
            else if (selectedChunk is SEGM) {
                AddSegm((SEGM)selectedChunk, null);
            }
            else {
                foreach (MODL modl in msh.Models) {
                    AddModl(modl);
                }
            }

            return segments.ToArray();
        }

        private void openMSHToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Battlefront Mesh File (*.msh)|*.msh";

            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName)) {
                OpenMSH(dialog.FileName);
            }
        }

        private void saveMSHToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Battlefront Mesh File (*.msh)|*.msh";

            if (dialog.ShowDialog() == DialogResult.OK) {
                if (File.Exists(dialog.FileName) &&
                    MessageBox.Show("'" + dialog.FileName + "' already exists! Overwrite anyway?", "Already Exists",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)

                    return;

                SaveMSH(dialog.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if (mshView.SelectedNode == null)
                return;

            removeMaterialMenuItem.Enabled = false;
            removeModelMenuItem.Enabled = false;
            removeSegmentMenuItem.Enabled = false;

            switch (mshView.SelectedNode.Name) {
                case "SINF":
                    selectedChunk = msh.SelectionInformation;
                    break;
                case "FRAM":
                    selectedChunk = msh.SelectionInformation.FrameInformation;
                    break;
                case "BBOX":
                    selectedChunk = msh.SelectionInformation.BoundingBox;
                    break;
                case "CAMR":
                    selectedChunk = msh.Camera;
                    break;
                /*case "MATL":
                    selectedChunk = msh.Materials;
                    break;
                case "MODL":
                    selectedChunk = msh.Models;
                    break;*/
                default:
                    selectedChunk = null;
                    break;
            }

            //Material Selection
            Match match = Regex.Match(mshView.SelectedNode.Name, "MAT[0-9]+");
            if (match.Success) {
                int index = Convert.ToInt32(match.Value.Replace("MAT", ""));
                selectedChunk = msh.Materials[index];

                removeMaterialMenuItem.Enabled = true;
            }

            //Model Selection
            match = Regex.Match(mshView.SelectedNode.Name, "MOD[0-9]+");
            if (match.Success) {
                int index = Convert.ToInt32(match.Value.Replace("MOD", ""));
                selectedChunk = msh.Models[index];

                removeModelMenuItem.Enabled = true;
            }

            //Geometry Bounding Box Selection
            match = Regex.Match(mshView.SelectedNode.Name, "GBOX[0-9]+");
            if (match.Success) {
                int index = Convert.ToInt32(match.Value.Replace("GBOX", ""));
                selectedChunk = msh.Models[index].Geometry.BoundingBox;
            }

            //Segment Selection
            match = Regex.Match(mshView.SelectedNode.Name, "SEG[0-9]+.[0-9]+");
            if (match.Success) {
                string txt = match.Value.Replace("SEG", "");
                int[] indices = Array.ConvertAll(txt.Split(new char[] { '.' }), int.Parse);

                selectedChunk = msh.Models[indices[0]].Geometry.Segments[indices[1]];

                removeSegmentMenuItem.Enabled = true;
            }

            inspector.SelectedObject = selectedChunk;
            glDraw.SegmentsToRender = GetSegmentsFromSelection();
        }

        private void checkMSHIntegrityToolStripMenuItem_Click(object sender, EventArgs e) {
            if (msh != null) {
                CheckMSH(true);
            }
            else {
                MessageBox.Show("No MSH loaded", "No MSH", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            if (e.ChangedItem.Label.Equals("Name")) {
                mshView.SelectedNode.Text = (string)e.ChangedItem.Value;
            }
        }

        private void addMaterialMenuItem_Click(object sender, EventArgs e) {
            msh.Materials.Add(new MATD(msh));
            RefreshTreeView();
        }

        private void removeMaterialMenuItem_Click(object sender, EventArgs e) {
            if (selectedChunk.GetType() == typeof(MATD)) {
                MATD material = (MATD)selectedChunk;

                if (MessageBox.Show("Do you really want to delete the Material '" + material.Name + "' ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    msh.Materials.Remove(material);
                    RefreshTreeView();
                }
            }
            else {
                MessageBox.Show("Selected Item is not a Material!", "No Material Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addModelMenuItem_Click(object sender, EventArgs e) {
            msh.Models.Add(new MODL(msh));
            RefreshTreeView();
        }

        private void removeModelMenuItem_Click(object sender, EventArgs e) {
            if (selectedChunk.GetType() == typeof(MODL)) {
                MODL model = (MODL)selectedChunk;

                if (MessageBox.Show("Do you really want to delete the Model '" + model.Name + "' ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    msh.Models.Remove(model);
                    RefreshTreeView();
                }
            }
            else {
                MessageBox.Show("Selected Item is not a Model!", "No Model Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            glDraw = new GLDraw(glControl1);
            glDraw.BackgroundColor = buttonPickColorGL.BackColor;

            // Ensure that the viewport and projection matrix are set correctly.
            glDraw.Resize();

            Application.Idle += Application_Idle;

            glControl1.MouseWheel += GlControl1_MouseWheel;

            drawModeSelect.SelectedIndex = 2;
            glDraw.DrawMode = (DrawMode)drawModeSelect.SelectedIndex;
        }

        protected override void OnClosing(CancelEventArgs e) {
            Application.Idle -= Application_Idle;

            base.OnClosing(e);
        }

        private void Application_Idle(object sender, EventArgs e) {
            while (glControl1.IsIdle) {
                glDraw.Render();
            }
        }

        private void glControl1_Resize(object sender, EventArgs e) {
            if (glDraw != null)
                glDraw.Resize();
        }

        private void glControl1_SizeChanged(object sender, EventArgs e) {
            if (glDraw != null)
                glDraw.Resize();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e) {
            glDraw.Render();
        }        

        private void buttonPickColorGL_Click(object sender, EventArgs e) {
            ColorDialog colorPicker = new ColorDialog();

            if (colorPicker.ShowDialog() == DialogResult.OK) {
                glDraw.BackgroundColor = colorPicker.Color;
                buttonPickColorGL.BackColor = colorPicker.Color;
            }
        }

        private void glControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                rotateCamera = true;
            }
            else if (e.Button == MouseButtons.Right) {
                translateCamera = true;
            }
        }

        private void glControl1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                rotateCamera = false;
            }
            else if (e.Button == MouseButtons.Right) {
                translateCamera = false;
            }
        }

        private void glControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
            int deltaX = e.X - mousePos.X;
            int deltaY = e.Y - mousePos.Y;

            if (rotateCamera) {
                glDraw.cameraRotation.X += deltaY * ((float)sensitivitySlider.Value / 100);
                glDraw.cameraRotation.Y += deltaX * ((float)sensitivitySlider.Value / 100);
            }
            else if (translateCamera) {
                glDraw.cameraPosition.X += deltaX * ((float)sensitivitySlider.Value / 200);
                glDraw.cameraPosition.Y -= deltaY * ((float)sensitivitySlider.Value / 200);
            }           

            mousePos.X = e.X;
            mousePos.Y = e.Y;
        }

        private void GlControl1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e) {
            float newZ = glDraw.cameraPosition.Z - e.Delta * ((float)sensitivitySlider.Value / 1000);
            glDraw.cameraPosition.Z = LibSWBF2.Math.Clamp(newZ, 0, 10000);
        }

        private void button1_Click(object sender, EventArgs e) {
            glDraw.ResetCamera();
        }

        private void drawModeSelect_SelectedIndexChanged(object sender, EventArgs e) {
            glDraw.DrawMode = (DrawMode)drawModeSelect.SelectedIndex;
        }
    }
}
