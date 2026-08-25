using MascotasAPI;

public class Perro : Mascotas
{
    private string raza;

    public string Raza
    {
        get{return this.raza;} set {raza = value;}
    }

    public override string Tipo()
    {
        return "Perro";
    }
}