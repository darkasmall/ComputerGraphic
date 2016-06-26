using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab7
{
    public class edge : IComparable
    {
        public point source, dest;
        public edge(ref point p1, ref point p2)
        {
            //if (p1 < p2)
            //{
            //    source = p1;
            //    dest = p2;
            //}
            //else
            //{
            //    source = p2;
            //    dest = p1;
            //}

            this.source = p1;
            this.dest = p2;

        }

        //public edge(point p1, point p2)
        //{
        //    if (p1 < p2)
        //    {
        //        source = p1;
        //        dest = p2;
        //    }
        //    else
        //    {
        //        source = p2;
        //        dest = p1;
        //    }

        //}
        public edge (edge e)
        {
            this.source = e.source;
            this.dest = e.dest;
        }
        public bool isVertexOfEdge(point p)
        {
            return (source == p) || (dest == p);
        }

        public override string ToString()
        {
            return source.ToString() + " - " + dest.ToString();
        }

        public double x()
        {
            return dest.x - source.x;
        }

        public double y()
        {
            return dest.y - source.y;
        }

        public double length()
        {
            return Math.Sqrt(this.x() * this.x() + this.y() * this.y());
        }

        public int CompareTo(object obj)
        {
            edge e = obj as edge;
            if (this.source > e.source) return 1;
            if (this.source < e.source) return -1;
            if (this.dest > e.dest) return 1;
            if (this.dest < e.dest) return -1;
            return 0;
        }

        public edge rot()
        {
            point m = (this.source + this.dest) * 0.5;
            point v = this.dest - this.source;
            point n = new point(v.y, -v.x);
            this.source = m - n * 0.5;
            this.dest = m + n * 0.5;
            return this;
        }

        public edge flip()
        {
            return (this.rot()).rot();
        }
    }
}
