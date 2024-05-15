using ReservationGraphQL.Common;
using ReservationGraphQL.Data;

namespace ReservationGraphQL.Clients
{
    public class CreateClientPayload : ClientPayloadBase
    {
        public CreateClientPayload(Client client)
            : base(client)
        {
        }

        public CreateClientPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
