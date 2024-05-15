using HotChocolate;
using HotChocolate.Types;
using ReservationGraphQL.Common;
using ReservationGraphQL.Data;
using ReservationGraphQL.Extensions;

namespace ReservationGraphQL.Reservations
{
    [ExtendObjectType("Mutation")]
    public class ReservationMutations
    {
        [UseApplicationDbContext]
        public async Task<CreateReservationsPayload> CreateReservationsAsync(CreateReservationsInput input, [ScopedService] ApplicationDbContext context)
        {
            List <Reservation> reservations = new List<Reservation>();

            DateTime roundedStartTime = RoundToNext15(input.StartTime);
            DateTime roundedEndTime = RoundToNext15(input.EndTime);

            TimeSpan duration = roundedEndTime - roundedStartTime;
            int reservationCount = (int)duration.TotalMinutes / 15;

            if (reservationCount > 1)
            {
                var error = new UserError("Duration not long enough for a reservation.", "RESERVATION_ERROR");
                return new CreateReservationsPayload([error]);
            }

            DateTime reservedTime = DateTime.Now.AddMinutes(reservationCount - 30);

            for (int i = 0; i < reservationCount; i++)
            {
                DateTime startTime = input.StartTime.AddMinutes(i * 15);
                var reservation = new Reservation
                {
                    ProviderId = input.ProviderId,
                    StartTime = startTime,
                    ReservedTime = reservedTime
                };
                context.Reservations.Add(reservation);
                reservations.Add(reservation);
            }
            await context.SaveChangesAsync();

            return new CreateReservationsPayload(reservations);
        }

        [UseApplicationDbContext]
        public async Task<MakeReservationPayload> MakeReservationAsync(MakeReservationInput input, [ScopedService] ApplicationDbContext context)
        {
            Reservation reservation = await context.Reservations.FindAsync(input.ReservationId);

            if (reservation == null)
            {
                var error = new UserError("Reservation not found.", "RESERVATION_NOT_FOUND");
                return new MakeReservationPayload([error]);                    
            }

            if (reservation.StartTime < DateTime.Now.AddDays(1))
            {
                var error = new UserError("Reservations must be made at least 24 hours ahead of time.", "RESERVATION_ERROR");
                return new MakeReservationPayload([error]);
            }

            if (reservation.ClientId != null && reservation.ClientId != input.ClientId && reservation.ReservedTime > DateTime.Now.AddMinutes(-30))
            {
                var error = new UserError("Reservation has already been booked by another client.", "RESERVATION_ERROR");
                return new MakeReservationPayload([error]);
            }

            reservation.ClientId = input.ClientId;
            reservation.ReservedTime = DateTime.Now;

            await context.SaveChangesAsync();
            return new MakeReservationPayload(reservation);
        }

        [UseApplicationDbContext]
        public async Task<ConfirmReservationPayload> ConfirmReservationAsync(ConfirmReservationInput input, [ScopedService] ApplicationDbContext context)
        {
            Reservation reservation = await context.Reservations.FindAsync(input.ReservationId);

            if (reservation == null)
            {
                var error = new UserError("Reservation not found.", "RESERVATION_NOT_FOUND");
                return new ConfirmReservationPayload([error]);
            }

            if (input.ClientId != reservation.ClientId)
            {
                var error = new UserError("You must reserve an appintment before you may confirm it.", "RESERVATION_ERROR");
                return new ConfirmReservationPayload([error]);
            }

            if (!input.Confirm)
            {
                reservation.ReservedTime = DateTime.Now.AddMinutes(-30);
                reservation.Confirmed = false;
            }
            else
            {
                reservation.Confirmed = true;
            }

            await context.SaveChangesAsync();
            return new ConfirmReservationPayload(reservation);
        }        

        private static DateTime RoundToNext15(DateTime datetime)
        {
            TimeSpan span = TimeSpan.FromMinutes(15);
            return new DateTime((datetime.Ticks + span.Ticks - 1) / span.Ticks * span.Ticks, datetime.Kind);
        }
    }
}
