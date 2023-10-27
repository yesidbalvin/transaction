// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Transactions.Application.Observation;
using Transactions.Domain.Observation.Repository;
using Transactions.Domain.PotentialObservation.Repository;
using Transactions.Infrastructure.Context;
using Transactions.Infrastructure.EntityFramework.Observation;
using Transactions.Infrastructure.EntityFramework.PotentialObservation;


var configurationBuilder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = configurationBuilder.Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
var host = CreateHostBuilder(args, connectionString).Build();

using var serviceScope = host.Services.CreateScope();
var provider = serviceScope.ServiceProvider;
var observationProcessor = provider.GetRequiredService<IObservationProcessor>();
await observationProcessor.ExecuteAsync();

await host.RunAsync();
return;


static IHostBuilder CreateHostBuilder(string[] args, string connectionString) =>
        Host.CreateDefaultBuilder(args)
                .ConfigureServices((services) =>
                {
                    var configurationBuilder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    var configuration = configurationBuilder.Build();

                    var connectionString = configuration.GetConnectionString("DefaultConnection");

                    services.AddScoped<IObservationProcessor, ObservationProcessor>();
                    services.AddScoped<IObservationRepository, ObservationRepository>();
                    services.AddScoped<IPotentialObservationRepository, PotentialObservationRepository>();
                    services.AddDbContext<TransactionsContext>(options => options.UseMySql(connectionString,
                            ServerVersion.AutoDetect(connectionString)));
                });
