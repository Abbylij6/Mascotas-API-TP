using MascotasAPI;

public class Gato : Mascotas
{
    private string color;

    public string Color
    {
        get{return this.color;} set {color = value;}
    }

    public override string Tipo()
    {
        return "Gato";
    }
}