using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {

        private Pen pen = new Pen(Color.Black, 2);
        Bitmap b;
        Function f;
        

        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double start, end;

            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Введите диапазон!");
            else
            {
                if (!double.TryParse(textBox1.Text, out start) ||
                    !double.TryParse(textBox2.Text, out end) || start > end)
                    MessageBox.Show("Некорректные значения диапазона!");
                else
                    if (f == null)
                        MessageBox.Show("Выберите функцию!");
                    else
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    g.Clear(Color.White);

                    int n = b.Width;

                    
                    List<double> ys = new List<double>();

                    Point[] ps = new Point[n];

                    double step = (end - start) / n;

                    for (double cur = start; cur <= end; cur+=step)
                        ys.Add(f.y(cur));

                    double min = ys.Min();
                    double max = ys.Max();
                    double mid = (min + max) / 2;

                    double koef = (max - min) / b.Height;


                    for (int x = 0; x < n; ++x)
                        ps[x] = new Point(x, (int) (ys[x]/koef - min/koef));

                    
                    g.DrawCurve(pen, ps);

                    g.Dispose();
                    pictureBox1.Refresh();
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            f = new Square();
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            f = new Sin();
        }
    }


    class Function
    {
        public virtual double y(double x)
        {
            return 0;
        }
    }

    class Sin : Function
    {
        public override double y(double x)
        {
            return Math.Sin(x);
        }
    }

    class Square : Function
    {
        public override double y(double x)
        {
            return x * x;
        }
    }
}
