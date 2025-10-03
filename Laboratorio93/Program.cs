class Programa3
{
    public static void Main (string[] args)
    {
        Console.Write("Ingrese lado 1: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Ingrese lado 2: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Ingrese lado 3: ");
        double c = double.Parse(Console.ReadLine());

        if (a + b > c && a + c > b && b + c > a) // Condición para ser triángulo
        {
            if (a == b && b == c)
                Console.WriteLine("Es un triángulo equilátero.");
            else if (a == b || a == c || b == c)
                Console.WriteLine("Es un triángulo isósceles.");
            else
                Console.WriteLine("Es un triángulo escaleno.");
        }
        else
        {
            Console.WriteLine("Los lados no forman un triángulo válido.");
        }
    }
}
