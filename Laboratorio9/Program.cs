class Programa1
{
    public static void Main (string[] args)
    {
        Console.Write("Ingrese el precio del producto: ");
        double precio = double.Parse(Console.ReadLine());

        if (precio <= 0)
        {
            Console.WriteLine("El precio debe ser positivo.");
            return;
        }

        Console.Write("Forma de pago (efectivo/tarjeta): ");
        string pago = Console.ReadLine().ToLower();

        if (pago == "tarjeta")
        {
            Console.Write("Ingrese el número de cuenta (16 dígitos): ");
            string cuenta = Console.ReadLine();

            if (cuenta.Length == 16 && long.TryParse(cuenta, out _))
            {
                Console.WriteLine($"Pago aceptado con tarjeta. Precio: {precio:C}");
            }
            else
            {
                Console.WriteLine("Número de cuenta inválido.");
            }
        }
        else if (pago == "efectivo")
        {
            Console.WriteLine($"Pago aceptado en efectivo. Precio: {precio:C}");
        }
        else
        {
            Console.WriteLine("Forma de pago no válida.");
        }
    }
}
