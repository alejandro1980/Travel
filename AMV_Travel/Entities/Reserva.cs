namespace AMV_Travel.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
