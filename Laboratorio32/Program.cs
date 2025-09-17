using System;

namespace OperacionesMatematicas
{
    public class CalculosMatematicos
    {
        // Método del ejercicio anterior
        public int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }

        // Nuevo método: calcular área de un círculo
        public double CalculoArea(double radio)
        {
            return Math.PI * Math.Pow(radio, 2);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Introduce el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());

            CalculosMatematicos calculo = new CalculosMatematicos();
            double area = calculo.CalculoArea(radio);

            Console.WriteLine($"El área del círculo con radio {radio} es: {area}");
        }
    }
}
