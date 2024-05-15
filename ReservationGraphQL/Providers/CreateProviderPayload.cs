using ReservationGraphQL.Common;
using ReservationGraphQL.Data;

namespace ReservationGraphQL.Providers
{
    public class CreateProviderPayload : ProviderPayloadBase
    {
        public CreateProviderPayload(Provider provider)
            : base(provider)
        {
        }

        public CreateProviderPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
