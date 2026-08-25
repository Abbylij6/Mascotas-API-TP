namespace MascotasAPI
{
    public abstract class Mascotas
    {
        internal static readonly int Count;
        private int id;

        private string nombre;

        private int edad;

        public int Id
        {
            get {return this.id;} set {id = value;}
        }
        public string Nombre
        {
            get {return this.nombre;} set {nombre = value;}
        }

        public int Edad
        {
            get {return this.edad;} set {edad = value;}
        }


    }
}