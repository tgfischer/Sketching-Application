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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectButton = new System.Windows.Forms.Button();
            this.freeDrawButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.squareButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.polygonButton = new System.Windows.Forms.Button();
            this.colourPanel = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.canvas = new Sketch_Application.Canvas();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.colourToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1269, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // colourToolStripMenuItem
            // 
            this.colourToolStripMenuItem.Name = "colourToolStripMenuItem";
            this.colourToolStripMenuItem.Size = new System.Drawing.Size(99, 19);
            this.colourToolStripMenuItem.Text = "Change Colour";
            this.colourToolStripMenuItem.Click += new System.EventHandler(this.colourToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.selectButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.freeDrawButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lineButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rectangleButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.squareButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ellipseButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.circleButton, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.polygonButton, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.colourPanel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.canvas, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.clearButton, 0, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 690);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // selectButton
            // 
            this.selectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectButton.Location = new System.Drawing.Point(3, 4);
            this.selectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(81, 57);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // freeDrawButton
            // 
            this.freeDrawButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freeDrawButton.Location = new System.Drawing.Point(3, 69);
            this.freeDrawButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.freeDrawButton.Name = "freeDrawButton";
            this.freeDrawButton.Size = new System.Drawing.Size(81, 57);
            this.freeDrawButton.TabIndex = 1;
            this.freeDrawButton.Text = "Free Draw";
            this.freeDrawButton.UseVisualStyleBackColor = true;
            this.freeDrawButton.Click += new System.EventHandler(this.freeDrawButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineButton.Location = new System.Drawing.Point(3, 134);
            this.lineButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(81, 57);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleButton.Location = new System.Drawing.Point(3, 199);
            this.rectangleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(81, 57);
            this.rectangleButton.TabIndex = 3;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // squareButton
            // 
            this.squareButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squareButton.Location = new System.Drawing.Point(3, 264);
            this.squareButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.squareButton.Name = "squareButton";
            this.squareButton.Size = new System.Drawing.Size(81, 57);
            this.squareButton.TabIndex = 4;
            this.squareButton.Text = "Square";
            this.squareButton.UseVisualStyleBackColor = true;
            this.squareButton.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ellipseButton.Location = new System.Drawing.Point(3, 329);
            this.ellipseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(81, 57);
            this.ellipseButton.TabIndex = 5;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleButton.Location = new System.Drawing.Point(3, 394);
            this.circleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(81, 56);
            this.circleButton.TabIndex = 6;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // polygonButton
            // 
            this.polygonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonButton.Location = new System.Drawing.Point(3, 458);
            this.polygonButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(81, 58);
            this.polygonButton.TabIndex = 7;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // colourPanel
            // 
            this.colourPanel.BackColor = System.Drawing.Color.Black;
            this.colourPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colourPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colourPanel.Location = new System.Drawing.Point(3, 524);
            this.colourPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.colourPanel.Name = "colourPanel";
            this.colourPanel.Size = new System.Drawing.Size(81, 57);
            this.colourPanel.TabIndex = 8;
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Location = new System.Drawing.Point(3, 628);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(81, 59);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(90, 3);
            this.canvas.Name = "canvas";
            this.tableLayoutPanel1.SetRowSpan(this.canvas, 11);
            this.canvas.Size = new System.Drawing.Size(1176, 684);
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
            this.ClientSize = new System.Drawing.Size(1269, 715);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SE3353B Sketch Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colourToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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

    }
}

