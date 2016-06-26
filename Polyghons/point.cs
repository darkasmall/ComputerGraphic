using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace lab7
{
    public class point// : IComparable
    {
        public double x, y;

        public point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public point(String str)
        {
            int x, y;
            Char [] separators =  {':'};
            String[] strs = str.Split(separators);
            String sx = strs[0].Substring(1, strs[0].Length - 1);
            String sy = strs[1].Substring(0, strs[1].Length - 1);
            int.TryParse(sx, out x);
            int.TryParse(sy, out y);
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + (int)x + " : " + (int)y + ")";
        }

        public Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }

        public double length()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public int CompareTo(object obj)
        {
            point p = obj as point;
            if (p.x < this.x) return 1;
            if (p.x > this.x) return -1;
            if (p.y < this.y) return 1;
            if (p.y > this.y) return -1;
            return 0;
        }

        //static public bool operator ==(point p1, point p2)
        //{
        //    if (p2 == null)
        //    {
        //        if (p1 == null)
        //            return true;
        //        else return false;
        //    }
        //    //return (p1.CompareTo(p2) == 0);
        //    if (p1.x != p2.x || p1.y != p2.y) return false;
        //    return true;
        //}

        //static public bool operator !=(point p1, point p2)
        //{
        //    return !(p1 == p2);
        //}



        static public bool operator >(point p1, point p2)
        {
            return (p1.CompareTo(p2) == 1);
            //if (p1.x > p2.x) return true;
            //if (p1.x == p2.x && p1.y > p2.y) return true;
            //return false;
        }

        static public bool operator <(point p1, point p2)
        {
              return (p1.CompareTo(p2) == -1);
          //  return !(p1 == p2) && !(p1 > p2);
        }

        static public point operator+(point p1, point p2)
        {
            return new point(p1.x + p2.x, p1.y + p2.y);
        }

        static public point operator*(point p1, double d)
        {
            return new point(p1.x * d, p1.y * d);
        }

        static public point operator-(point p1, point p2)
        {
            return new point(p1.x - p2.x, p1.y - p2.y);
        }


    }
}
