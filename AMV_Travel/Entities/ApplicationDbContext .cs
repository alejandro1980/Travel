using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AMV_Travel.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
