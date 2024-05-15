using Microsoft.EntityFrameworkCore;

namespace ReservationGraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Provider> Providers { get; set; } = default!;
        public DbSet<Reservation> Reservations { get; set; } = default!;
    }
}
