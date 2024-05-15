using ReservationGraphQL.Common;
using ReservationGraphQL.Data;

namespace ReservationGraphQL.Clients
{
    public class ClientPayloadBase : Payload
    {
        protected ClientPayloadBase(Client client)
        {
            Client = client;
        }

        protected ClientPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors) 
        { 
        } 

        public Client? Client { get; }
    }
}
