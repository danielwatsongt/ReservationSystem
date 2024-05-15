using ReservationGraphQL.Common;
using ReservationGraphQL.Data;

namespace ReservationGraphQL.Providers
{
    public class ProviderPayloadBase : Payload
    {
        protected ProviderPayloadBase(Provider provider)
        {
            Provider = provider;
        }

        protected ProviderPayloadBase(IReadOnlyList<UserError> errors) 
            : base(errors) 
        { 
        } 

        public Provider? Provider { get; }
    }
}
