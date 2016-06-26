using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Task2
{
    public partial class DrawForm : Form
    {
        private Pen pen = new Pen(Color.Black, 2);
        private Pen eraser = new Pen(Color.White, 7);
        private Point startPos;
        Bitmap b;
        public DrawForm()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = b;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                changeColor(cd.Color);
            }
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
            changeColor(Color.Black);
        }

       
        private void changeColor(Color newColor)
        {
            panel1.BackColor = newColor;
            pen.Color = newColor;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPos = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            if (e.Button == MouseButtons.Left)
                g.DrawLine(pen, startPos, e.Location);
            if (e.Button == MouseButtons.Right)
                g.DrawLine(eraser, startPos, e.Location);
                
                g.Dispose();
                startPos = e.Location;
                pictureBox1.Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Refresh();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
                pictureBox1.Image.Save(s);
                Text = "Image Editor - " + s;
            }
        }
    }
}
