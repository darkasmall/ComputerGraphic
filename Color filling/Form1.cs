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
        private Pen pen = new Pen(Color.Black);
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
            Graphics g = Graphics.FromImage(b);
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
            Graphics g = Graphics.FromImage(b);
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

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fill(e.Location);
        }




        private Point findLeft(Point p)
        {
            int left = p.X;
            while (b.GetPixel(left, p.Y).ToArgb() != pen.Color.ToArgb() && left > 0)
                --left;
            return new Point(left+1, p.Y);
        }

        private Point findRight(Point p)
        {
            int right = p.X;
            while (b.GetPixel(right, p.Y).ToArgb() != pen.Color.ToArgb() && right < b.Width - 1)
                ++right;
            return new Point(right-1, p.Y);
        }


        private void fill(Point p)
        {
            if (!(p.X >= 0 && p.Y >= 0 && p.X < b.Width && p.Y < b.Height)) return;
            if (b.GetPixel(p.X, p.Y).ToArgb() != pen.Color.ToArgb())
            {
                Graphics g = Graphics.FromImage(b);

                Point l = findLeft(p);
                Point r = findRight(p);

                Pen f = new Pen(pen.Color, 1);

                g.DrawLine(f, l, r);

               // pictureBox1.Image = b;
                pictureBox1.Refresh();

                for (int i = l.X; i <= r.X; ++i)
                    fill(new Point(i, p.Y + 1));
                
                for (int i = l.X; i <= r.X; ++i)
                    fill(new Point(i, p.Y - 1));

                g.Dispose();
            }
        }


        


    }
}
