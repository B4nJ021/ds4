using System;

namespace OperacionesMatematicas
{
    public class CalculosMatematicos
    {
        public int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce el primer numero: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduce el segundo numero: ");
            int b = Convert.ToInt32(Console.ReadLine());

            CalculosMatematicos calculo = new CalculosMatematicos();
            int resultado = calculo.Calcular(a, b);

            Console.WriteLine($"El resultado de (a+b)*(a-b) con a={a} y b={b} es: {resultado}");
        }
    }
}
