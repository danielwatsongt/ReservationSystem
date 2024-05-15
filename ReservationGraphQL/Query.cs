using GreenDonut;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using ReservationGraphQL.Data;
using ReservationGraphQL.DataLoader;
using ReservationGraphQL.Extensions;

namespace ReservationGraphQL
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Provider>> GetProviders([ScopedService] ApplicationDbContext context) => context.Providers.ToListAsync();

        [UseApplicationDbContext]
        public Task<List<Reservation>> GetReservations([ScopedService] ApplicationDbContext context) => context.Reservations.ToListAsync();

        [UseApplicationDbContext]
        public Task<List<Client>> GetClients([ScopedService] ApplicationDbContext context) => context.Clients.ToListAsync();

        [UseApplicationDbContext]
        public Task<List<Reservation>> GetAvailableAppointments([ScopedService] ApplicationDbContext context)
            => context.Reservations.Where(c => !c.Confirmed && c.ReservedTime < DateTime.Now.AddMinutes(-30) && c.StartTime > DateTime.Now.AddDays(1)).ToListAsync();

        public Task<Provider> GetProviderAsync(int id, ProviderByIdDataLoader dataLoader, CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);

        public Task<Reservation> GetReservationAsync(int id, ReservationByIdDataLoader dataLoader, CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);

        public Task<Client> GetClientAsync(int id, ClientByIdDataLoader dataLoader, CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);

    }
}
