using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio123
{
    public static class TrianguloHelper
    {
        public static double CalcularSemiperimetro(double a, double b, double c)
        {
            return (a + b + c) / 2.0;
        }

        public static double CalcularArea(double a, double b, double c)
        {
            double s = CalcularSemiperimetro(a, b, c);
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public static bool EsTrianguloValido(double a, double b, double c)
        {
            // Desigualdad triangular
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
