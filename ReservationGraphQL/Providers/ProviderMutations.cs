using HotChocolate;
using HotChocolate.Types;
using ReservationGraphQL.Data;
using ReservationGraphQL.Extensions;

namespace ReservationGraphQL.Providers
{
    [ExtendObjectType("Mutation")]
    public class ProviderMutations
    {
        [UseApplicationDbContext]
        public async Task<CreateProviderPayload> CreateProviderAsync(CreateProviderInput input, [ScopedService] ApplicationDbContext context)
        {
            var provider = new Provider
            {
                FirstName = input.FirstName,
                LastName = input.LastName,                
            };

            context.Providers.Add(provider);
            await context.SaveChangesAsync();

            return new CreateProviderPayload(provider);
        }
    }
}
