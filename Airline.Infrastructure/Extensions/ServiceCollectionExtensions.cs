using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Airline.Domain.Entities;
using Airline.Infrastructure.Persistence;

namespace Airline.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("AirlineConnectionString");
		services.AddDbContext<AirlineDbContext>(options => options.UseSqlServer(connectionString));

		//this for identity and jwt when needed
		services.AddIdentityCore<User>()
			.AddRoles<IdentityRole>()
			.AddTokenProvider<DataProtectorTokenProvider<User>>("AirlineTokenProvidor")
			.AddEntityFrameworkStores<AirlineDbContext>()
			.AddDefaultTokenProviders();
	}
}
