using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using ReservationGraphQL.Data;

namespace ReservationGraphQL.DataLoader
{
    public class ProviderByIdDataLoader : BatchDataLoader<int, Provider>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public ProviderByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Provider>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Providers
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
