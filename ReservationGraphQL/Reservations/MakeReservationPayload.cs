using ReservationGraphQL.Data;
using ReservationGraphQL.Common;

namespace ReservationGraphQL.Reservations
{
    public class MakeReservationPayload : ReservationPayloadBase
    {
        public MakeReservationPayload(Reservation reservation)
            : base(reservation) 
        { 
        }

        public MakeReservationPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {

        }
    }
}
