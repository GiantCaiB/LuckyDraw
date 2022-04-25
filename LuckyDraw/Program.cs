using LuckyDraw.Service;
using LuckyDraw.Service.Interface.Interfaces;
using LuckyDraw.Service.Interface.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
     .ConfigureServices((_, services) =>
        services.AddSingleton<IDrawService, DrawService>()
        .AddSingleton<IPrintService, PrintService>())
    .Build();

// Build a config object, using env vars and JSON providers.
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

using var serviceScope = host.Services.CreateScope();
var provider = serviceScope.ServiceProvider;
var drawService = provider.GetRequiredService<IDrawService>();
var printService = provider.GetRequiredService<IPrintService>();

var resultAnalysis = config.GetRequiredSection(nameof(ResultAnalysis)).Get<ResultAnalysis>();
var results = await drawService.GenerateResult(resultAnalysis);
printService.Print(results);

await host.RunAsync();