namespace ReservationGraphQL.Reservations
{
    public record CreateReservationsInput(
        DateTime StartTime,
        DateTime EndTime,
        int ProviderId
    );
    
}
