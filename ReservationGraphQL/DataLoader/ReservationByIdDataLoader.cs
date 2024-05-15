using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using ReservationGraphQL.Data;

namespace ReservationGraphQL.DataLoader
{
    public class ReservationByIdDataLoader : BatchDataLoader<int, Reservation>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public ReservationByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Reservation>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Reservations
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
