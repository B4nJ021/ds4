class Persona
{
    //Campo de cada objeto Persona que almacena su nombre

    public string Nombre;
    //Campo de cada objeto Persona que almacena su edad
    public int Edad;
    //Campo de cada objeto Persona que almacena su NIF

    public string NIF;

    void Cumpleaños() //Incrementa en 1 la edad de la Persona
    {
        Edad++;
    }

    //Constructor de Persona
    public Persona(string nombre, int edad, string nif)
    {
        Nombre = nombre;
        Edad = edad;
        NIF = nif;
    }
}

class Trabajador : Persona
{
    //Campo de cada objeto Trabajador que almacena cuánto gana
    public int Sueldo;

    public Trabajador(string nombre, int edad, string nif, int sueldo)
        :base(nombre, edad, nif)
    { //Inicializamos cada Trabajador en base al constructor de Persona
        Sueldo = sueldo;
    }
}