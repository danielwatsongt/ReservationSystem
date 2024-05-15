using ReservationGraphQL.Common;
using ReservationGraphQL.Data;

namespace ReservationGraphQL.Reservations
{
    public class ReservationsPayloadBase : Payload
    {
        protected ReservationsPayloadBase(List<Reservation> reservations)
        {
            Reservations = reservations;
        }

        protected ReservationsPayloadBase(IReadOnlyList<UserError> errors) 
            : base(errors) 
        { 
        } 

        public List<Reservation>? Reservations { get; }
    }
}
