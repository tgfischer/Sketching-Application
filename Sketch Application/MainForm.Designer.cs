namespace Sketch_Application
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.selectButton = new System.Windows.Forms.Button();
            this.freeDrawButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.squareButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.polygonButton = new System.Windows.Forms.Button();
            this.colourPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.canvas = new Sketch_Application.Canvas();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.colourToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1269, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // colourToolStripMenuItem
            // 
            this.colourToolStripMenuItem.Name = "colourToolStripMenuItem";
            this.colourToolStripMenuItem.Size = new System.Drawing.Size(99, 19);
            this.colourToolStripMenuItem.Text = "Change Colour";
            this.colourToolStripMenuItem.Click += new System.EventHandler(this.colourToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Enabled = false;
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.selectButton, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.freeDrawButton, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.lineButton, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.rectangleButton, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.squareButton, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.ellipseButton, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.circleButton, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.polygonButton, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.colourPanel, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.canvas, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.clearButton, 0, 11);
            this.tableLayoutPanel.Controls.Add(this.moveButton, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 12;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1269, 918);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // selectButton
            // 
            this.selectButton.BackColor = System.Drawing.Color.DimGray;
            this.selectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("selectButton.BackgroundImage")));
            this.selectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectButton.ForeColor = System.Drawing.Color.White;
            this.selectButton.Location = new System.Drawing.Point(3, 4);
            this.selectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(81, 72);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "Select";
            this.selectButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.selectButton.UseVisualStyleBackColor = false;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // freeDrawButton
            // 
            this.freeDrawButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("freeDrawButton.BackgroundImage")));
            this.freeDrawButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.freeDrawButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freeDrawButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.freeDrawButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.freeDrawButton.Location = new System.Drawing.Point(3, 164);
            this.freeDrawButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.freeDrawButton.Name = "freeDrawButton";
            this.freeDrawButton.Size = new System.Drawing.Size(81, 72);
            this.freeDrawButton.TabIndex = 1;
            this.freeDrawButton.Text = "Free Line";
            this.freeDrawButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.freeDrawButton.UseVisualStyleBackColor = true;
            this.freeDrawButton.Click += new System.EventHandler(this.freeDrawButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lineButton.BackgroundImage")));
            this.lineButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lineButton.Location = new System.Drawing.Point(3, 244);
            this.lineButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(81, 72);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "Line";
            this.lineButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rectangleButton.BackgroundImage")));
            this.rectangleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rectangleButton.Location = new System.Drawing.Point(3, 324);
            this.rectangleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(81, 72);
            this.rectangleButton.TabIndex = 3;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // squareButton
            // 
            this.squareButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("squareButton.BackgroundImage")));
            this.squareButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.squareButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squareButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.squareButton.Location = new System.Drawing.Point(3, 404);
            this.squareButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.squareButton.Name = "squareButton";
            this.squareButton.Size = new System.Drawing.Size(81, 72);
            this.squareButton.TabIndex = 4;
            this.squareButton.Text = "Square";
            this.squareButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.squareButton.UseVisualStyleBackColor = true;
            this.squareButton.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ellipseButton.BackgroundImage")));
            this.ellipseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ellipseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ellipseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ellipseButton.Location = new System.Drawing.Point(3, 484);
            this.ellipseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(81, 72);
            this.ellipseButton.TabIndex = 5;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circleButton.BackgroundImage")));
            this.circleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.circleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.circleButton.Location = new System.Drawing.Point(3, 564);
            this.circleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(81, 72);
            this.circleButton.TabIndex = 6;
            this.circleButton.Text = "Circle";
            this.circleButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // polygonButton
            // 
            this.polygonButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("polygonButton.BackgroundImage")));
            this.polygonButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.polygonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.polygonButton.Location = new System.Drawing.Point(3, 644);
            this.polygonButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(81, 72);
            this.polygonButton.TabIndex = 7;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // colourPanel
            // 
            this.colourPanel.BackColor = System.Drawing.Color.Black;
            this.colourPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colourPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colourPanel.Location = new System.Drawing.Point(3, 724);
            this.colourPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colourPanel.Name = "colourPanel";
            this.colourPanel.Size = new System.Drawing.Size(81, 57);
            this.colourPanel.TabIndex = 8;
            this.colourPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colourPanel_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutRightToolStripMenuItem,
            this.pasteRightToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // cutRightToolStripMenuItem
            // 
            this.cutRightToolStripMenuItem.Name = "cutRightToolStripMenuItem";
            this.cutRightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutRightToolStripMenuItem.Text = "Cut";
            this.cutRightToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteRightToolStripMenuItem
            // 
            this.pasteRightToolStripMenuItem.Name = "pasteRightToolStripMenuItem";
            this.pasteRightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteRightToolStripMenuItem.Text = "Paste";
            this.pasteRightToolStripMenuItem.Click += new System.EventHandler(this.pasteRightToolStripMenuItem_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clearButton.BackgroundImage")));
            this.clearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearButton.Location = new System.Drawing.Point(3, 841);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(81, 74);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Clear";
            this.clearButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveButton.BackgroundImage")));
            this.moveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.moveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveButton.Location = new System.Drawing.Point(3, 83);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(81, 74);
            this.moveButton.TabIndex = 12;
            this.moveButton.Text = "Move";
            this.moveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.ContextMenuStrip = this.contextMenuStrip;
            this.canvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(90, 3);
            this.canvas.Name = "canvas";
            this.tableLayoutPanel.SetRowSpan(this.canvas, 12);
            this.canvas.Size = new System.Drawing.Size(1176, 912);
            this.canvas.TabIndex = 9;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseLeave += new System.EventHandler(this.canvas_MouseLeave);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 943);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "untitled* - Paint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colourToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button freeDrawButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button squareButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.Panel colourPanel;
        private Canvas canvas;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cutRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}

