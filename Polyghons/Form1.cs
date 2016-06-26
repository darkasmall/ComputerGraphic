using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace lab7
{
    public partial class Form1 : Form
    {
        Bitmap b;
        List<point> points = new List<point>();
        List<edge> edges = new List<edge>();

        point oldSelectedPoint;
        edge oldSelectedEdge;

        polygon plgn = new polygon();


        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = b;

        }


        // Добавление точки

        private void addPoint(double x, double y)
        {
            point p = new point(x, y);
            points.Add(p);
            pointsBox.Items.Add(p);
            drawPoint(p, Color.Black);

            comboBoxEdgeSource.Items.Add(p);
            comboBoxEdgeEnd.Items.Add(p);
        }
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addPoint(e.X, e.Y);
        }

        // Удаление точки
        private void deletePointButton_Click(object sender, EventArgs e)
        {
            point p = pointsBox.SelectedItem as point;

            if (p == null)
                MessageBox.Show("Выберите точку!");
            else
            {
                points.Remove(p);
                pointsBox.Items.Remove(p);

                comboBoxEdgeSource.Items.Remove(p);
                comboBoxEdgeEnd.Items.Remove(p);

                List<edge> es = containingsPoint(p);

                for (int i = 0; i < edges.Count; ++i)
                {
                    if (es.Contains(edges[i]))
                        edges.Remove(edges[i]);
                }

                drawListOfEdge(es, pictureBox1.BackColor);
                drawPoint(p, pictureBox1.BackColor);
            }
            
        }



        // Добавление ребра
        private void addEdgeButton_Click(object sender, EventArgs e)
        {
            point p1 = comboBoxEdgeSource.SelectedItem as point;
            point p2 = comboBoxEdgeEnd.SelectedItem as point;


            if (p1 == null || p2 == null)
                MessageBox.Show("Выберите точки!");
            else if (p1 == p2)
                MessageBox.Show("Выберите разные точки!");
            else
            {
                edge ed = new edge(ref p1, ref p2);
                edges.Add(ed);
                edgesBox.Items.Add(ed);
                drawAllEdges();

                comboBoxEdgeIntsct1.Items.Add(ed);
                comboBoxEdgeIntsct2.Items.Add(ed);
            }

            
        }

        // Удаление ребра
        private void deleteEdgeButton_Click(object sender, EventArgs e)
        {
            edge ed = edgesBox.SelectedItem as edge;

            if (ed == null)
                MessageBox.Show("Выберите ребро!");
            else
            {
                edges.Remove(ed);
                edgesBox.Items.Remove(ed);
                drawEdge(ed, pictureBox1.BackColor);
                drawPoint(ed.source, Color.Black);
                drawPoint(ed.dest, Color.Black);

                comboBoxEdgeIntsct1.Items.Remove(ed);
                comboBoxEdgeIntsct2.Items.Remove(ed);
            }
        }


        void refreshBoxes(int i)
        {
            pointsBox.Items[i] = points[i];

            comboBoxEdgeSource.Items[i] = points[i];
            comboBoxEdgeEnd.Items[i] = points[i];

            List<edge> es = containingsPoint(points[i]);
            for (int j = 0; j < edges.Count; ++j)
            {
                if (es.Contains(edges[j]))
                {
                    edgesBox.Items[j] = edges[j];
                    comboBoxEdgeIntsct1.Items[j] = edges[j];
                    comboBoxEdgeIntsct2.Items[j] = edges[j];
                }

            }
        }

        // Вспомогательная функция, перемещает точку с индексом в массиве i в новое положение
        void shiftPoint(int i, double x, double y)
        {
            points[i].x = x;
            points[i].y = y;

            refreshBoxes(i);
        }

        // Вспомогательная функция, возвращает список ребер, инцидентных с точкой p
        List<edge> containingsPoint(point p)
        {
            List<edge> res = new List<edge>();
            foreach (edge e in edges)
            {
                if (e.isVertexOfEdge(p))
                    res.Add(e);
            }
            return res;
        }


        // Сдвиг точки
        private void buttonShiftPoint_Click(object sender, EventArgs e)
        {
            int dx, dy;
            if (pointsBox.SelectedItem == null)
                MessageBox.Show("Выберите точку!");
            else if (!int.TryParse(textBoxShX.Text, out dx) || !int.TryParse(textBoxShY.Text, out dy))
                MessageBox.Show("Неверные параметры сдвига!");
            else
            {
                point oldP = pointsBox.SelectedItem as point;

                List<edge> es = containingsPoint(oldP);

                drawListOfEdge(es, pictureBox1.BackColor);
                drawPoint(oldP, pictureBox1.BackColor);

                int i = pointsBox.Items.IndexOf(oldP);

                shiftPoint(i, oldP.x + dx, oldP.y + dy);

                drawPoint(points[i], Color.Black);
                drawListOfEdge(es, Color.Black);
                //refreshPicture();
            }
        }





        // Сдвиг
        private void shiftButton_Click(object sender, EventArgs e)
        {
            int xd, yd;

            if (!int.TryParse(textBoxShX.Text, out xd) || !int.TryParse(textBoxShY.Text, out yd))
                MessageBox.Show("Неверные параметры сдвига!");
            else
            {
                for (int i = 0; i < points.Count; ++i)
                    shiftPoint(i, points[i].x + xd, points[i].y + yd);

                refreshPicture();
            }
        }

        // Поворот
        private void rotateButton_Click(object sender, EventArgs e)
        {
            double phi;
            if (!double.TryParse(textBoxPhi.Text, out phi))
                MessageBox.Show("Некорректный угол поворота!");
            else
            {
                phi = phi * Math.PI / 180;
                for (int i = 0; i < points.Count; ++i)
                {
                    shiftPoint(i, (points[i].x * Math.Cos(phi) - points[i].y * Math.Sin(phi)), (points[i].x * Math.Sin(phi) + points[i].y * Math.Cos(phi)));
                }

                refreshPicture();
            }
        }

        // Масштаб
        private void scaleButton_Click(object sender, EventArgs e)
        {
            double a, b;

            if (!double.TryParse(textBoxScX.Text, out a) || !double.TryParse(textBoxScY.Text, out b))
                MessageBox.Show("Некорректные параметры масштаба!");

            else
            {
                for (int i = 0; i < points.Count; ++i)
                {
                    shiftPoint(i, (points[i].x * a), (points[i].y * b));
                }
                refreshPicture();
            }
        }



///////////////////////////////////////////

        // Нарисовать точку
        void drawPoint(point p, Color c)
        {
            Graphics g = Graphics.FromImage(b);
            g.FillEllipse(new SolidBrush(c), (int)p.x, (int)p.y, 4, 4);
            pictureBox1.Refresh();
            g.Dispose();
        }

        // Нарисовать ребро
        void drawEdge(edge e, Color c)
        {
            Graphics g = Graphics.FromImage(b);
            g.DrawLine(new Pen(c), e.source.ToPoint(), e.dest.ToPoint());
            //drawPoint(source, Color.Black);
            // drawPoint(dest, Color.Black);
            pictureBox1.Refresh();
            g.Dispose();
        }

        // Нарисовать все ребра
        void drawAllEdges()
        {
            foreach (edge e in edges)
                drawEdge(e, Color.Black);
        }

        // Нарисовать все точки
        void drawAllPoints()
        {
            foreach (point p in points)
                drawPoint(p, Color.Black);
        }

        // Нарисовать список ребер
        void drawListOfEdge(List<edge> l, Color c)
        {
            foreach (edge e in l)
            {
                drawEdge(e, c);
                drawPoint(e.source, Color.Black);
                drawPoint(e.dest, Color.Black);
            }
        }

        // Обновить картинку
        void refreshPicture()
        {
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);
            drawAllPoints();
            drawAllEdges();
            pictureBox1.Refresh();
            g.Dispose();
        }


        void drawPolygon()
        {
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);
            drawAllPoints();
            
            //for (int i = 0; i < points.Count - 1; ++i)
            //{
            //    g.DrawLine(new Pen(Color.Blue), points[i].ToPoint(), points[i + 1].ToPoint());
            //}
            //g.DrawLine(new Pen(Color.Blue), points[points.Count - 1].ToPoint(), points[0].ToPoint());

            foreach (edge e in plgn.edges)
                g.DrawLine(new Pen(Color.Blue), e.source.ToPoint(), e.dest.ToPoint());

            pictureBox1.Refresh();
            g.Dispose();
        }


        void drawTrian(List<triangle> tr)
        {
            Graphics g = Graphics.FromImage(b);
            foreach (triangle t in tr)
            {
                g.DrawLine(new Pen(Color.Black), t.vertices[0].ToPoint(), t.vertices[1].ToPoint());
                g.DrawLine(new Pen(Color.Black), t.vertices[0].ToPoint(), t.vertices[2].ToPoint());
                g.DrawLine(new Pen(Color.Black), t.vertices[1].ToPoint(), t.vertices[2].ToPoint());
            }
            pictureBox1.Refresh();
            g.Dispose();
        }
//////////////////////////////////////////



//////////////////////////////////////////
        private void drawRedEdge(edge ed)
        {
            if (ed != null)
            {
                if (oldSelectedEdge != null)
                    drawEdge(oldSelectedEdge, Color.Black);
                if (oldSelectedEdge == ed)
                    oldSelectedEdge = null;
                else
                {
                    drawEdge(ed, Color.Red);
                    oldSelectedEdge = ed;
                }
            }
        }

        private void drawRedPoint(point p)
        {
            if (p != null)
            {
                if (oldSelectedPoint != null)
                {
                    if (points.Contains(oldSelectedPoint))
                        drawPoint(oldSelectedPoint, Color.Black);
                }
                    
                if (oldSelectedPoint == p)
                    oldSelectedPoint = null;
                else
                {
                    drawPoint(p, Color.Red);
                    oldSelectedPoint = p;
                }
            }
        }

        // Выделение выбранного ребра красным цветом
        private void edgesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            edge ed = edgesBox.SelectedItem as edge;
            drawRedEdge(ed);

        }

        // Выделение выбранной точки красным цветом
        private void pointsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            point p = pointsBox.SelectedItem as point;
            drawRedPoint(p);
        }
        private void comboBoxEdgeIntsct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            edge ed = (sender as ComboBox).SelectedItem as edge;
            drawRedEdge(ed);
        }

        private void comboBoxEdgeSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            point p = (sender as ComboBox).SelectedItem as point;
            drawRedPoint(p);
        }

////////////////////////////////////////////////





        private void button1_Click(object sender, EventArgs e)
        {
            point p = pointsBox.SelectedItem as point;
            edge ed = edgesBox.SelectedItem as edge;

            if (p == null || ed == null)
                MessageBox.Show("Выберите ребро и точку!");
            else
            {
                textBox1.Text =BaseAlgs.classify(p, ed).ToString();
            }
        }



        private void edgeIntersectButton_Click(object sender, EventArgs e)
        {
            edge e1 = comboBoxEdgeIntsct1.SelectedItem as edge;
            edge e2 = comboBoxEdgeIntsct2.SelectedItem as edge;

            if (e1 == null || e2 == null)
                MessageBox.Show("Выберите ребра!");
            else if (e1 == e2)
                MessageBox.Show("Выберите разные ребра!");
            else
            {
                point p = BaseAlgs.intersectionPoint(e1, e2);
                if (p != null)
                    drawPoint(p, Color.Blue);
            }

            
        }

        private void rotateEdgeButton_Click(object sender, EventArgs e)
        {
            edge ed = edgesBox.SelectedItem as edge;
            if (ed == null)
                MessageBox.Show("Выберите ребро!");
            else
            {
               // ed.rot();   // обработать изменение точек!
                rotateEdge(ed);
                refreshPicture();
            }
        }


        void rotateEdge(edge e)
        {
            point m = new point(0.5 * (e.source.x + e.dest.x), 0.5 * (e.source.y + e.dest.y));
            point v = new point(e.dest.x - e.source.x, e.dest.y - e.source.y);
            point n = new point(v.y, -v.x);
            int i = points.IndexOf(e.source);
            int j = points.IndexOf(e.dest);
            shiftPoint(i, m.x - 0.5 * n.x, m.y - 0.5 * n.y);
            shiftPoint(j, m.x + 0.5 * n.x, m.y + 0.5 * n.y);
        }

        private void refreshPictureButton_Click(object sender, EventArgs e)
        {
            refreshPicture();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText("for_user.txt"));
        }

        private void createPolygonButton_Click(object sender, EventArgs e)
        {
            plgn.createPolygon(points);
            drawPolygon();
        }

        private void isPointInsideButton_Click(object sender, EventArgs e)
        {
            point p = pointsBox.SelectedItem as point;

            if (p == null)
                MessageBox.Show("Выберите точку!");
            else if (plgn == null)
                MessageBox.Show("Создайте полигон!");
            else
            {
                isPointInsideTextBox.Text = BaseAlgs.isPointInsidePolygon(p, plgn).ToString();
            }
        }

        private void delaunayButton_Click(object sender, EventArgs e)
        {
            saveToFile("d.txt");
            if (points.Count > 0)
            {
                List<triangle> tr = Delaunay.triangulate(points);
                drawTrian(tr);
            }
            
        }


        private void loadFromFile(String fileName)
        {
            String[] content = File.ReadAllLines(fileName);
            foreach (String s in content)
            {
                point p = new point(s);
                addPoint(p.x, p.y);
            }
        }

        private void saveToFile(String fileName)
        {
            String toWrite = "";
            foreach(point p in points)
            {
                toWrite += p.ToString() + "\r\n";
            }
            File.WriteAllText(fileName, toWrite);
        }

        private void loadFroamFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadFromFile(textBoxFilePath.Text);
            }
            catch
            {
                MessageBox.Show("Что-то не так");
            }
            
        }

        private void saveToFileButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                saveToFile(textBoxSaveToFile.Text);
            }
            catch
            {
                MessageBox.Show("Что-то не так");
            }
        }


    }




}
