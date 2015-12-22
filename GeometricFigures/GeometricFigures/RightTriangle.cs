using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public class RightTriangle : GeometricFigure
    {
        public double A { get; set; }
        public double B { get; set; }

        public RightTriangle(double a, double b)
        {
            A = a;
            B = b;
        }

        public override double Area => (A * B) / 2;
    }
}
