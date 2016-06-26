using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task3
{
    
    public partial class Form1 : Form
    {
        private Random r = new Random();

        string dir1 = "left", dir2 = "right", dir3 = "down";

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Location = new Point(r.Next(Width - 150), r.Next(Height - 150));
            pictureBox2.Location = new Point(r.Next(Width - 150), r.Next(Height - 150));
            pictureBox3.Location = new Point(r.Next(Width - 150), r.Next(Height - 150));

            timer1.Interval = r.Next(1, 100);
            timer2.Interval = r.Next(1, 100);
            timer3.Interval = r.Next(1, 100);
        }

        public void mooving(PictureBox ob, ref string dir)
        {
            int x = ob.Location.X;
            int y = ob.Location.Y;

            switch (dir)
            {
                case "up": ob.Location = new Point(x, y - 1);
                    if (y == 0) dir = "down";
                    break;
                case "down": ob.Location = new Point(x, y + 1);
                    if (y + ob.Height * 1.5 >= Height) dir = "up";
                    break;
                case "right": ob.Location = new Point(x + 1, y);
                    if (x + ob.Width * 1.2 >= Width) dir = "left";
                    break;
                case "left": ob.Location = new Point(x - 1, y);
                    if (x == 0) dir = "right";
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mooving(pictureBox1, ref dir1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            mooving(pictureBox2, ref dir2);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            mooving(pictureBox3, ref dir3);
        }

        
    }
}
