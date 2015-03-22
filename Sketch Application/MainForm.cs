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
        private bool isMouseDown = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = this.colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.canvas.Colour = this.colorDialog.Color;
                this.colourPanel.BackColor = this.canvas.Colour;
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Select;
        }

        private void freeDrawButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.FreeHand;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Line;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Rectangle;
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Square;
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Ellipse;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Circle;
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            this.canvas.Mode = Mode.Polygon;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.canvas.ClearCanvas();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMouseDown) 
            {

            } 
            else 
            {
                this.canvas.AddShape(Cursor.Position);
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.isMouseDown = false;
        }

        private void canvas_MouseLeave(object sender, EventArgs e)
        {
            this.isMouseDown = false;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown) 
            {

            }
            else
            {

            }
        }
    }
}
