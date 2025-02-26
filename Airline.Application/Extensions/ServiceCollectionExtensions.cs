using Airline.Application.Airline.Commands.Behaviour;
using Airline.Application.Airline.Commands.Delete;
using Airline.Application.Airline.Commands.Update;
using Airline.Application.Users;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Airline.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddApplication(this IServiceCollection services)
	{
		var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

		services.AddValidatorsFromAssembly(applicationAssembly)
				.AddFluentValidationAutoValidation();

		services.AddAutoMapper(applicationAssembly);
		services.AddScoped<IUserContext, UserContext>();
        services.AddTransient(typeof(IPipelineBehavior<DeleteAirlineCommand,Unit>), typeof(AirlineCommandBehaviour<DeleteAirlineCommand,Unit>));
        services.AddTransient(typeof(IPipelineBehavior<UpdateAirlineCommand, Unit>), typeof(AirlineCommandBehaviour<UpdateAirlineCommand, Unit>));
    }
}