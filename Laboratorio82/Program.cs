public class Cuenta
{
    private string idCuenta;

    public Cuenta(string prmIdCuenta)
    {
        this.idCuenta = prmIdCuenta;
        System.Console.WriteLine(
            "Constructor Clase Base para cuenta {0}", prmIdCuenta);
    }

    public virtual void CalcularIntereses()
    {
        System.Console.WriteLine(
            "Cuenta.CalcularIntereses() efectuado para la cuenta {0}",
            this.idCuenta);
    }

    public string getIdCuenta()
    {
        return this.idCuenta;
    }
}
public class CuentaCorriente : Cuenta
{
    public CuentaCorriente(string prmIdCuenta) : base(prmIdCuenta)
    {
    }

    public override void CalcularIntereses()
    {
        System.Console.WriteLine(
            "CuentaCorriente.CalcularIntereses() efectuado para " +
            "la cuenta {0}", getIdCuenta());
    }
}

public class CuentaAhorro : Cuenta
{
    public CuentaAhorro(string prmIdCuenta) : base(prmIdCuenta)
    {
    }
    public override void CalcularIntereses()
    {
        System.Console.WriteLine(
            "CuentaAhorro.CalcularIntereses() efectuado para " +
            "la cuenta {0}", getIdCuenta());
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        const string CUENTA = "100";

        Cuenta cuenta = new Cuenta(CUENTA);
        CuentaCorriente cuentaCorriente =
        new CuentaCorriente(CUENTA);
        CuentaAhorro cuentaAhorro =
        new CuentaAhorro(CUENTA);
        cuenta.CalcularIntereses();
        cuentaCorriente.CalcularIntereses();
        cuentaAhorro.CalcularIntereses();
    }
}