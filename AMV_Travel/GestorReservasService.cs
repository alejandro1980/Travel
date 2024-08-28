using AMV_Travel.Entities;
using Microsoft.EntityFrameworkCore;

namespace AMV_Travel
{
    public class GestorReservasService
    {
        private readonly ApplicationDbContext _context;

        public GestorReservasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AgregarTour(Tour tour)
        {
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }

        public List<Tour> MostrarTours()
        {
            return _context.Tours.ToList();
        }

        public void ReservarTour(Reserva reserva)
        {
            List<Tour> toursDisponibles =MostrarTours();
            foreach (var tour in toursDisponibles)
            {
                if (reserva.TourId== tour.Id)
                {
                    reserva.Tour = tour;

                    _context.Reservas.Add(reserva);
                    _context.SaveChanges();

                }

            }


            //_context.Reservas.Add(reserva);
            //_context.SaveChanges();
        }

        public List<Reserva> MostrarReservas()
        {
            return _context.Reservas.Include(r => r.Tour).ToList();
        }

        public void EliminarReserva(int reservaId)
        {
            var reserva = _context.Reservas.Find(reservaId);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SaveChanges();
            }
        }
    }
}
