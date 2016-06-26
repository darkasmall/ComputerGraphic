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
        int tc, shoots, hits, misses;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearInfo();
            timer1.Start();
            tc = 30;
            pictureBox1.Location = new Point(r.Next(this.panel1.Width - 60),
                                             r.Next(30, this.panel1.Height - 60));
            pictureBox1.Visible = true;
            textBox4.Text = tc.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tc == 0)
                button2_Click(sender, e);
            else
            {
                tc--;
                textBox4.Text = tc.ToString();
                pictureBox1.Location = new Point(r.Next(this.panel1.Width - 60),
                                                 r.Next(30, this.panel1.Height - 60));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox1.Visible = false;
            textBox4.Text = "";
        }

        void clearInfo()
        {
            shoots = 0;
            hits = 0;
            misses = 0;
            updateInfo();
        }

        void updateInfo()
        {
            textBox1.Text = shoots.ToString();
            textBox2.Text = hits.ToString();
            textBox3.Text = misses.ToString();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            shoots++;
            misses++;
            updateInfo();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            shoots++;
            hits++;
            updateInfo();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 700;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 500;
        }
    }
}
