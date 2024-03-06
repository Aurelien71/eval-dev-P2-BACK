using EvalBack.Context;
using EvalBack.Repositories;
using EvalBack.Repositories.Contracts;
using EvalBack.Service;
using EvalBack.Services.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<IEvenementService, EvenementService>();
        services.AddScoped<IEvenementRepository, EvenementRepository>();

        var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

        services.AddDbContext<EvenementContext>(options =>
            options.UseSqlServer(config.GetConnectionString("db"),
                b => b.MigrationsAssembly(typeof(EvenementContext).Assembly.FullName)));
    })
    .Build();

host.Run();
