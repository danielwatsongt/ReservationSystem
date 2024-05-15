namespace ReservationGraphQL.Reservations
{
    public record ConfirmReservationInput(
        int ReservationId,
        int ClientId,
        bool Confirm
    );
    
}
