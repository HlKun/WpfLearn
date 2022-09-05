using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vector2D> points = new List<Vector2D>
            {
                new Vector2D(0, 0),
                new Vector2D(1, 2),
                new Vector2D(2, 0)
            };

            Vector2D P = new Vector2D(0, 0);

            var result = IsPointInPoly(P, points);
        }

        /// <summary>
        /// 射线法
        /// </summary>
        /// <param name="P"></param>
        /// <param name="points"></param>
        static bool IsPointInPoly(Vector2D P, List<Vector2D> points)
        {
            bool isInPoly = false;

            Vector2D A = points[0];

            for (int i = 1; i <= points.Count; i++)
            {
                Vector2D B = points[i == points.Count ? 0 : i];

                if ((B.Y <= P.Y && P.Y < A.Y) || (A.Y <= P.Y && P.Y < B.Y))
                {
                    Vector2D BP = new Vector2D(P.X - B.X, P.Y - B.Y);
                    Vector2D BA = new Vector2D(A.X - B.X, A.Y - A.Y);

                    double t = BP.X * BA.Y - BP.Y * BA.X;
                    if (A.Y < B.Y)
                        t = -t;

                    if (t < 0)
                        isInPoly = !isInPoly;
                }

                A = B;
            }

            return isInPoly;
        }
    }

    public class Vector2D
    {
        public Vector2D(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
