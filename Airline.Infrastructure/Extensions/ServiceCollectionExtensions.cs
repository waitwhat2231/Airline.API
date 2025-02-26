using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Airline.Domain.Entities;
using Airline.Infrastructure.Persistence;
using Airline.Domain.Repositories;
using Airline.Infrastructure.Repositories;
using Airline.Infrastructure.Seeders.Roles;
using Airline.Infrastructure.Seeders.Admin;

namespace Airline.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("AirlineConnectionString");
		services.AddDbContext<AirlineDbContext>(options => options.UseSqlServer(connectionString));
		services.AddScoped<IAirlineRepository, AirlineRepository>();
        services.AddScoped<IAirportRepository, AirportRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IRolesSeeder, RolesSeeder>();
		services.AddScoped<IAdminSeeder, AdminSeeder>();
		//this for identity and jwt when needed
		services.AddIdentityCore<User>()


			.AddRoles<IdentityRole>()
			.AddTokenProvider<DataProtectorTokenProvider<User>>("AirlineTokenProvidor")
			.AddEntityFrameworkStores<AirlineDbContext>()
			.AddDefaultTokenProviders();
	}
}
