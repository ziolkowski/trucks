using FluentValidation;
using Trucks.DataAccess.Commands.CreateTruck;
using Trucks.DataAccess.Repositories;
using Trucks.Database;
using Trucks.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetValue<string>("DataBaseConnectionString") ?? throw new NullReferenceException("ConnectionString to database cannot be null");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg => cfg.EnableAnnotations());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddValidatorsFromAssemblyContaining<CreateTruckValidator>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<TruckContext>();

builder.Services.AddScoped<ITruckRepository, TruckRepository>();

builder.Services.AddScoped<ITruckStatusService, TruckStatusService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
