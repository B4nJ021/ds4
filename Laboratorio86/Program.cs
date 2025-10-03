class ClaseBase
{
    public void test()
    {

    }
    public virtual void masTests() //agregar virtual
    {

    }
}

class ClaseHijo : ClaseBase
{
    public override void masTests()
    {

    }
}
internal class Program
{
       private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicacion");
    }
}