using ReservationGraphQL.Common;
using ReservationGraphQL.Data;

namespace ReservationGraphQL.Reservations
{
    public class ReservationPayloadBase : Payload
    {
        protected ReservationPayloadBase(Reservation reservation)
        {
            Reservation = reservation;
        }

        protected ReservationPayloadBase(IReadOnlyList<UserError> errors) 
            : base(errors) 
        { 
        } 

        public Reservation? Reservation { get; }
    }
}
