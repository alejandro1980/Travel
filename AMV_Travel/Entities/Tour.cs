namespace AMV_Travel.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Precio { get; set; }
    }
}
