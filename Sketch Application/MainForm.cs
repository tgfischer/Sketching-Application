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
        private Color colour = Color.Black;
        private Graphics g;
        private Pen pen;

        public MainForm()
        {
            InitializeComponent();

            this.pen = new Pen(this.colour, 2F);
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = this.colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.colour = this.colorDialog.Color;
                this.colourPanel.BackColor = this.colour;
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {

        }

        private void freeDrawButton_Click(object sender, EventArgs e)
        {

        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            //this.canvas.AddShape(Cursor.Position, );
            g = this.canvas.CreateGraphics();
            g.DrawLine(this.pen, 250, 50, 400, 200);
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {

        }

        private void squareButton_Click(object sender, EventArgs e)
        {

        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {

        }

        private void circleButton_Click(object sender, EventArgs e)
        {

        }

        private void polygonButton_Click(object sender, EventArgs e)
        {

        }
    }
}
