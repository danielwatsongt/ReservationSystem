using HotChocolate;
using HotChocolate.Types;
using ReservationGraphQL.Data;
using ReservationGraphQL.Extensions;

namespace ReservationGraphQL.Clients
{
    [ExtendObjectType("Mutation")]
    public class ClientMutations
    {
        [UseApplicationDbContext]
        public async Task<CreateClientPayload> CreateClientAsync(CreateClientInput input, [ScopedService] ApplicationDbContext context)
        {
            var client = new Client
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                Phone = input.Phone
            };

            context.Clients.Add(client);
            await context.SaveChangesAsync();

            return new CreateClientPayload(client);
        }
    }
}
