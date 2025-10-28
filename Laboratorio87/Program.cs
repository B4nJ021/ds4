internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicacion");
    }
}
class ClaseBase //eliminar sealed
{
    public void test()
    {

    }
    public void moreTesting()
    {

    }
}
class ClaseHijo : ClaseBase
{
}