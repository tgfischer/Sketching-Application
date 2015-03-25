using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sketch_Application
{
    public partial class MainForm : Form
    {
        private bool isDrawing = false;
        private bool polygonFirst = true;
        private ImageFile file;

        public MainForm()
        {
            InitializeComponent();

            this.file = new ImageFile();
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.colourPanel_Click(null, null);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Select;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.Cross;
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Move;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.SizeAll;
        }

        private void freeDrawButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.FreeHand;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.Default;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Line;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.Default;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Rectangle;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.Default;
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Square;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.Default;
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Ellipse;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.Default;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Circle;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.Default;
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Polygon;
            this.SetCurrentButton(this, (Button)sender);
            this.canvas.Cursor = Cursors.Default;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.canvas.ClearCanvas();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(this.canvas.Bounds);
            //Console.WriteLine(this.canvas.PointToScreen(Cursor.Position));

            if (e.Button == MouseButtons.Right) //right click
            {
                this.canvas.AddLineToCurrentShape(this.canvas.PointToClient(Cursor.Position));
                this.isDrawing = false;
                polygonFirst = true;
            }
            else // Left click
            {
                if (this.canvas.Mode == Mode.Polygon && polygonFirst)
                {
                    this.isDrawing = true;
                    this.canvas.AddNewShape(this.canvas.PointToClient(Cursor.Position));
                    polygonFirst = false;
                }
                else if (this.canvas.Mode == Mode.Polygon)
                {
                    this.isDrawing = true;
                    this.isDrawing = this.canvas.AddLineToCurrentShape(this.canvas.PointToClient(Cursor.Position));

                    if (!isDrawing)
                    {
                        polygonFirst = true;
                    }
                }
                else
                {
                    this.isDrawing = true;
                    this.canvas.AddNewShape(this.canvas.PointToClient(Cursor.Position));

                    if (this.file.IsSaved)
                    {
                        this.file.IsSaved = false;
                        this.Text = this.FormTitle;
                    }
                }
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.canvas.Mode != Mode.Polygon)
            {
                this.isDrawing = false;
            }

            if (this.canvas.Mode == Mode.Select)
            {
                this.canvas.SelectShapes();
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing) 
            {
                this.canvas.AddToCurrentShape(this.canvas.PointToClient(Cursor.Position));
            }
        }

        private void canvas_MouseLeave(object sender, EventArgs e)
        {
            this.isDrawing = false;
            polygonFirst = true;
        }

        private void colourPanel_Click(object sender, MouseEventArgs e)
        {
            DialogResult result = this.colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.canvas.Colour = this.colorDialog.Color;
                this.colourPanel.BackColor = this.canvas.Colour;
            }
        }

        private void SetCurrentButton(Control parent, Button button)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.HasChildren)
                {
                    SetCurrentButton(control, button);
                }
                else if (control is Button)
                {
                    if (control == button)
                    {
                        control.BackColor = Color.DimGray;
                        control.ForeColor = Color.White;
                    }
                    else
                    {
                        control.BackColor = default(Color);
                        control.ForeColor = default(Color);
                    }
                }
            }
        }

        private void pasteRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.canvas.Paste(this.canvas.PointToClient(Cursor.Position));
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.canvas.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.canvas.Paste(new Point(0, 0));
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.canvas.Shapes.Count == 0)
            {
                MessageBox.Show("There is nothing to save!");
                return;
            }

            if (!File.Exists(this.file.FilePath))
            {
                this.saveAsToolStripMenuItem_Click(null, null);
                return;
            }

            this.canvas.RemoveSelect();

            this.file.Save(this.canvas.Shapes);

            this.Text = this.FormTitle;
            this.canvas.Invalidate();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.canvas.Shapes.Count == 0)
            {
                MessageBox.Show("There is nothing to save!");
                return;
            }

            this.canvas.RemoveSelect();
            
            this.saveFileDialog.FileName = this.file.FileName;
            this.saveFileDialog.Filter = "XML File (*.xml)|*.xml|All files (*.*)|*.*";

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.file.SaveAs(this.canvas.Shapes, this.saveFileDialog.FileName);
            }

            this.Text = this.FormTitle;
            this.canvas.Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.canvas.ClearCanvas();

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.canvas.Shapes = this.file.Open(this.canvas.Shapes, this.openFileDialog.FileName);
            }

            this.Text = this.FormTitle;
            this.canvas.Invalidate();
        }

        private string FormTitle
        {
            get 
            {
                if (this.file.IsSaved)
                {
                    return this.file.FileName + " - Paint";
                }
                else
                {
                    return this.file.FileName + "* - Paint";
                }
            }
        }
    }
}
