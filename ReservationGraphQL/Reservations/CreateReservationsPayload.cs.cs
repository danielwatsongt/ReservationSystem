using ReservationGraphQL.Data;
using ReservationGraphQL.Common;

namespace ReservationGraphQL.Reservations
{
    public class CreateReservationsPayload : ReservationsPayloadBase
    {
        public CreateReservationsPayload(List<Reservation> reservations)
            : base(reservations) 
        { 
        }

        public CreateReservationsPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {

        }
    }
}
