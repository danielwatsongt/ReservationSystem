# ReservationSystem

This is a GraphQL server exposing an API for creating reservations. Features include:
* Creating a new Client
* Creating a new Provider
* Providers can add their availability through the createReservations mutation, allowing them to specify a start and stop time. Reservation slots are created for each 15 minute interval between these times.
* Clients can query for Available Appointments, which returns all appointments that are at least 24 hours away, not yet booked, and have not yet been reserved.
* Clients can then book one of these appoints through the MakeReservation mutation, which stops the reservation from appearing in the Available Appointments query. After not being confirmed for 30 minutes, the appointment will be queryable again.
* Clients can then use the ConfirmReservation mutation to confirm their appointment. If they choose to Confirm, it will be permanently reserved for them. If they choose not to confirm, it will immediately be queryable again from Available Appointments

Though this is a working implementation, due to time constraints, there are many missing features:
1. Providers should be able to add availability for multiple days at a time. This implementation currently only allows a single time duration. This also gives providers the ability to add 24/7 availability for years at a time, which should not be allowed.
2. Providers should be able to cancel appointments as well. If they are already confirmed, this should immediately notify the client that their reservation has been cancelled.
3. The Client and Provider APIs should probably be separated into separate services so that they cannot access each other.
4. This implementation currently has no security whatsoever! Anyone can pretend to be anyone else, can query all other clients and providers, and can see already booked reservations and who owns them. This should obviously be fixed with roles and permissions.

Developer thoughts:
1. I might have bit off more than I could chew on this one. I figured I would learn something new and write this entirely as a HotChocolate C# server! I had never used HotChocolate before, but figured it was a good time to learn.
2. I ended up leaving all the Queries in a single file instead of breaking them up into Type-dependent files. This was purely due to running out of time, but I understand that this is ugly and wouldn't pass a code review.
3. I'm missing some DataLoaders - a Provider should be obviously be able to easily query for all of their appointments, booked or free. Again, ran out of time.
4. This was a surprisingly fun task. I really enjoyed learning all of this, and making it work. Thanks for the opportunity!
