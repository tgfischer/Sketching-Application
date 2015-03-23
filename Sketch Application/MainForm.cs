using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sketch_Application
{
    public partial class MainForm : Form
    {
        private bool isDrawing = false;
        private bool polygonFirst = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.colourPanel_Click(null, null);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Select;
            this.SetCurrentButton(this, (Button)sender);
        }

        private void freeDrawButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.FreeHand;
            this.SetCurrentButton(this, (Button)sender);
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Line;
            this.SetCurrentButton(this, (Button)sender);
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Rectangle;
            this.SetCurrentButton(this, (Button)sender);
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Square;
            this.SetCurrentButton(this, (Button)sender);
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Ellipse;
            this.SetCurrentButton(this, (Button)sender);
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Circle;
            this.SetCurrentButton(this, (Button)sender);
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Polygon;
            this.SetCurrentButton(this, (Button)sender);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.canvas.ClearCanvas();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownPanel.BackColor = Color.Tomato;

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
                }
            }

            this.mouseDownPanel.BackColor = Color.White;
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

            this.mouseDownPanel.BackColor = Color.White;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing) 
            {
                this.canvas.AddToCurrentShape(this.canvas.PointToClient(Cursor.Position));
                this.mouseDownPanel.BackColor = Color.CornflowerBlue;
            }
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
    }
}
