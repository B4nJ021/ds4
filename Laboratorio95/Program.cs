class Programa5
{
    public static void Main(string[]args)
    {
        Aleatorio ale = new Aleatorio();

        Console.Write("Cantidad de números a generar: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Número mínimo: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Número máximo: ");
        int max = int.Parse(Console.ReadLine());

        if (cantidad > (max - min + 1))
        {
            Console.WriteLine("No se pueden generar números únicos en ese rango.");
            return;
        }

        HashSet<int> numeros = new HashSet<int>();

        while (numeros.Count < cantidad)
        {
            numeros.Add(ale.GenerarNumero(min, max));
        }

        Console.WriteLine("Números generados sin repetir:");
        foreach (int n in numeros)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }
}
