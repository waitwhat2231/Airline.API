using Airline.API.Extensions;
using Airline.API.Middlewares;
using Airline.Application.Extensions;
using Airline.Domain.Entities;
using Airline.Infrastructure.Extensions;
using Airline.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ExceptionHandlingMiddlewares>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});

var app = builder.Build();

var scope = app.Services.CreateScope(); //for seeders
// example: var govSeeder = scope.ServiceProvider.GetRequiredService<IGovernorateSeeder>();
var rolesSeeder = scope.ServiceProvider.GetRequiredService<IRolesSeeder>();

await rolesSeeder.Seed();
// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionHandlingMiddlewares>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGroup("api/identity").WithTags("Identity").MapIdentityApi<User>();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
