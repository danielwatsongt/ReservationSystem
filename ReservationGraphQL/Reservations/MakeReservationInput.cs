namespace ReservationGraphQL.Reservations
{
    public record MakeReservationInput(
        int ReservationId,
        int ClientId
    );
    
}
