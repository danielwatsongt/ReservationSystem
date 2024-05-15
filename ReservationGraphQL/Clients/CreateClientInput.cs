namespace ReservationGraphQL.Clients
{
    public record CreateClientInput(
        string FirstName,
        string LastName,
        string Email,
        string Phone
    );
}
