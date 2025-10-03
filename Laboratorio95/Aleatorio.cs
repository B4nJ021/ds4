class Aleatorio
{
    private Random rand = new Random();

    // Generar número entre dos valores
    public int GenerarNumero(int min, int max)
    {
        return rand.Next(min, max + 1); // incluye max
    }

    // Generar arreglo de números entre dos valores
    public int[] GenerarArreglo(int cantidad, int min, int max)
    {
        int[] arreglo = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = rand.Next(min, max + 1);
        }
        return arreglo;
    }
}