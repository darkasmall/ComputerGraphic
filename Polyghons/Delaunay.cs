using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab7
{
    public class Delaunay
    {
        public static List<triangle> triangulate(List<point> s)
        {
            List<triangle> triangles = new List<triangle>();
            List<edge> frontier = new List<edge>();
            point p = null;
            edge e = hullEdge(s);
            frontier.Add(e);

            while (frontier.Count != 0)
            {
            //    frontier.Sort((a,b) => a.CompareTo(b));
                e = frontier.First();
               // e = frontier.Min();
                //s.Remove(e.source);
                //s.Remove(e.dest);
                frontier.Remove(e);

                if (mate(e, s, ref p))
                {
                    //Console.WriteLine(p.ToString());
                    updateFrontier(frontier, p, e.source);
                    updateFrontier(frontier, e.dest, p);
                    triangles.Add(new triangle(e.source, e.dest, p));
                    //s.Remove(p);
                }
            }

            return triangles;
        }


        public static edge hullEdge(List<point> s)
        {
            point p1, p2;
            int m = 0;
            for (int i = 0; i < s.Count; ++i)
            {
                if (s[i] < s[m])
                    m = i;
            }
            point p = new point(s[0].x, s[0].y);
            s[0].x = s[m].x;
            s[0].y = s[m].y;
            s[m] = p;

            m = 1;

            for (int j = 2; j < s.Count; ++j)
            {
                p1 = s[0];
                p2 = s[m];
                BaseAlgs.orientation c = BaseAlgs.classify(s[j], new edge(ref p1, ref p2));
                //BaseAlgs.orientation c = BaseAlgs.classify(s[j], new edge(p1, p2));
                if (c == BaseAlgs.orientation.Left || c == BaseAlgs.orientation.Between)
                    m = j;
            }

            p1 = s[0];
            p2 = s[m];

            return new edge(ref p1, ref p2);
            //return new edge(p1, p2);
        }


        public static void updateFrontier(List<edge> frontier, point a, point b)
        {
            edge e = new edge(ref a, ref b);
            //edge e = new edge(a, b);
            if (frontier.Contains(e))
                frontier.Remove(e);
            else
            {
                e = e.flip();
                frontier.Add(e);
            }
        }


        public static bool mate(edge e, List<point> s, ref point p)
        {
            int fl = 0;
            point bestp = null;
            double t = double.MaxValue, bestt = double.MaxValue;
            edge f = new edge(e);
            f = f.rot();

            for (int i = 0; i < s.Count; ++i)
            {
                if (BaseAlgs.classify(s[i], e) == BaseAlgs.orientation.Right)
                {
                    point tp = s[i];
                    edge g = new edge(ref e.dest, ref tp);
                    //edge g = new edge(e.dest, tp);
                    g.rot();
                    BaseAlgs.intersect(f, g, out t);
                    if (t < bestt)
                    {
                        fl = 1;
                        bestp = s[i];
                        bestt = t;
                    }
                }
            }
            if (fl == 1)
            {
                p = bestp;
                return true;
            }
            return false;
        }





    }

}
