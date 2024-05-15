using ReservationGraphQL.Data;
using ReservationGraphQL.Common;

namespace ReservationGraphQL.Reservations
{
    public class ConfirmReservationPayload : ReservationPayloadBase
    {
        public ConfirmReservationPayload(Reservation reservation)
            : base(reservation) 
        { 
        }

        public ConfirmReservationPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {

        }
    }
}
