using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio12
{
    public static class Calculator
    {
        public static double CalcularDistancia(double velocidad, double tiempo)
        {
            return velocidad * tiempo;
        }

        public static double CalcularPromedio(double n1, double n2, double n3)
        {
            return (n1 + n2 + n3) / 3.0;
        }

        public static double CalcularSemiperimetro(double a, double b, double c)
        {
            return (a + b + c) / 2.0;
        }

        public static double CalcularAreaTriangulo(double a, double b, double c)
        {
            double s = CalcularSemiperimetro(a, b, c);
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}
