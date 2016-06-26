using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab7
{
    public class polygon
    {
        public List<point> vertices;
        public List<edge> edges;
        public void createPolygon(List<point> points)
        {
            vertices = points;
            edges = new List<edge>();

            sort();

            point p1;
            point p2; 

            for (int i = 0; i < vertices.Count - 1; ++i)
            {
                p1 = vertices[i];
                p2 = vertices[i + 1];
                edges.Add(new edge(ref p1, ref p2));
            }
            p1 = vertices[vertices.Count - 1];
            p2 = vertices[0];
            edges.Add(new edge(ref p1, ref p2));
        }


        protected void sort()
        {
            point pstart = vertices[0];
            foreach (point p in vertices)
            {
                if (p.x < pstart.x)
                    pstart = p;
                else if (p.x == pstart.x && p.y > pstart.y)
                    pstart = p;
            }

            vertices.Remove(pstart);


            vertices.Sort((a, b) => pointsComparer(a, b, pstart));
            vertices.Insert(0, pstart);
        }
        private int pointsComparer(point ps, point pd, point p)
        {
            switch (BaseAlgs.classify(p, new edge(ref ps, ref pd)))
            {
                case BaseAlgs.orientation.Left: return -1;
                case BaseAlgs.orientation.Right: return 1;
                default: return 0;
            }
        }

        public point this[int i]
        {
            get
            {
                return vertices[i];
            }
            set
            {
                vertices[i] = value;
            }
        }
    }

    public class triangle : polygon
    {
        public triangle(point p1, point p2, point p3)
        {
            vertices = new List<point>();
            vertices.Add(p1);
            vertices.Add(p2);
            vertices.Add(p3);
            sort();
        }
    }

}
