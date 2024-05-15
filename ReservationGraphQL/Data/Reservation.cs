namespace ReservationGraphQL.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public int? ClientId { get; set; } = null;
        public int ProviderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ReservedTime { get; set; }
        public bool Confirmed { get; set; } = false;
    }
}
