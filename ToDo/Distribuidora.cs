namespace distribuidora
{
    public class Tarea
    {
        public int TareaID { get; set; }
        public string Descripcion { get; set; }
        private int duracion;

        public int Duracion
        {
            get { return duracion; }
            set
            {
                if (value >= 10 && value <= 100)
                {
                    duracion = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La duracion debe ser de entre 10 y 100");
                }
            }
        } 

        public Tarea(int tareaid, string descripcion, int duracion)
        {
            TareaID = tareaid;
            Descripcion = descripcion;
            Duracion = duracion;
        }

        public void MostrarTareas(){
            Console.WriteLine($"{TareaID, -5} | {Descripcion, -30} | {Duracion, -10}");
        }
    }
}