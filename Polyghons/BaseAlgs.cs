using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab7
{
    public class BaseAlgs
    {
        public enum orientation { Left, Right, Beyond, Behind, Between, Origin, Destination }; // classify
        public enum forIntersectionPoint { Collinear, Parallel, Skew, Skew_No_Cross, Skew_Cross };

        public enum pointLocationType { Inside, Outside, Boundary }; // point inside polygon
        public enum edgelocationType { Touching, Crossing, Inessential }; // point inside polygon



        public static orientation classify(point p, edge ed)
        {
            point p0 = ed.source;
            point p1 = ed.dest;
            //point a = new point(ed.x(), ed.y());
            point a = p1 - p0;
            point b = p - p0;
            //edge tp = new edge(ref ed.source, ref p);
            //edge tp = new edge(ed.source, p);
            //point b = new point(tp.x(), tp.y());

            double sa = a.x * b.y - b.x * a.y;

            if (sa > 0)
                return orientation.Left;
            if (sa < 0)
                return orientation.Right;
            if (a.x * b.x < 0 || a.y * b.y < 0)
                return orientation.Behind;
            //if (ed.length() < tp.length())
            if (a.length() < b.length())
                return orientation.Beyond;
            if (p0 == p)
                return orientation.Origin;
            if (p1 == p)
                return orientation.Destination;
            return orientation.Between;
        }


        private static double dotProduct(point p1, point p2)
        {
            return p1.x * p2.x + p1.y * p2.y;
        }

        private static forIntersectionPoint intersect_(edge e1, edge e2, out double t)
        {
            point a = e1.source;
            point b = e1.dest;
            point c = e2.source;
            point d = e2.dest;
            point n = new point(d.y - c.y, c.x - d.x);
            double denom = dotProduct(n, new point(b.x - a.x, b.y - a.y));
            if (denom == 0)
            {
                t = double.MaxValue;
                orientation aclass = classify(e1.source, e2);
                if (aclass == orientation.Left || aclass == orientation.Right)
                    return forIntersectionPoint.Parallel;
                else return forIntersectionPoint.Collinear;
            }
            double num = dotProduct(n, new point(a.x - c.x, a.y - c.y));
            t = -num / denom;
            return forIntersectionPoint.Skew;
        }

        public static forIntersectionPoint intersect(edge e1, edge e2, out double t)
        {
            double s;
            forIntersectionPoint crossType = intersect_(e1, e2, out s);
            t = s;
            if (crossType == forIntersectionPoint.Collinear || crossType == forIntersectionPoint.Parallel)
                return crossType;
            if (s < 0.0 || s > 1.0)
                return forIntersectionPoint.Skew_No_Cross;
            intersect_(e1, e2, out t);
            if (0.0 <= t && t <= 1.0)
                return forIntersectionPoint.Skew_Cross;
            else
                return forIntersectionPoint.Skew_No_Cross;
        }


        private static point pt(edge e, double t)
        {
            double x = e.source.x + t * (e.dest.x - e.source.x);
            double y = e.source.y + t * (e.dest.y - e.source.y);

            return new point(x, y);
        }

        public static point intersectionPoint(edge e1, edge e2)
        {
            point p = null;

            double t;

            if (intersect(e1, e2, out t) == forIntersectionPoint.Skew_Cross)
                p = BaseAlgs.pt(e1, t);

            return p;
        }




        public static pointLocationType isPointInsidePolygon(point pnt, polygon plgn)
        {
            int parity = 0;
            foreach (edge e in plgn.edges)
            {
                switch (edgeType(e.source, e.dest, pnt))
                {
                    case edgelocationType.Touching:
                        return pointLocationType.Boundary;
                    case edgelocationType.Crossing:
                        parity = 1 - parity;
                        break;
                }
            }

            return (parity == 1) ? pointLocationType.Inside : pointLocationType.Outside;
        }


        private static edgelocationType edgeType(point ps, point pd, point p)
        {
            switch(classify(p, new edge(ref ps, ref pd)))
            {
                case orientation.Left:
                    return (ps.y < p.y && p.y < pd.y) ? edgelocationType.Crossing : edgelocationType.Inessential;
                case orientation.Right:
                    return (pd.y < p.y && p.y < ps.y) ? edgelocationType.Crossing : edgelocationType.Inessential;
                case orientation.Between:
                case orientation.Origin:
                case orientation.Destination:
                    return edgelocationType.Touching;
                default:
                    return edgelocationType.Inessential;
            }
        }

    }
}
