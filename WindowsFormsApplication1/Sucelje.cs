using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormApplication1
{
    public partial class sucelje : Form
    {
        public sucelje()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid(sender, e);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            drawGrid(sender, e);
        }

        private void drawGrid(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int numOfCells = 10;
            int cellSize = 30;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }
    }
}
