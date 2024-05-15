using Microsoft.EntityFrameworkCore;
using ReservationGraphQL.Clients;
using ReservationGraphQL.Data;
using ReservationGraphQL.DataLoader;
using ReservationGraphQL.Providers;
using ReservationGraphQL.Reservations;

namespace ReservationGraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=reservations.db"))
                .AddGraphQLServer()                
                .AddQueryType<Query>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<ClientMutations>()
                    .AddTypeExtension<ProviderMutations>()
                    .AddTypeExtension<ReservationMutations>()
                .AddDataLoader<ClientByIdDataLoader>()
                .AddDataLoader<ProviderByIdDataLoader>()
                .AddDataLoader<ReservationByIdDataLoader>();
            
            var app = builder.Build();
            app.MapGraphQL();

            app.Run();
        }
    }
}

