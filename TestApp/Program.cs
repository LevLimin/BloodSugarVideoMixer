using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MyFirstLib;

using TestApp;

var builder = new HostBuilder()
    .ConfigureHostConfiguration(configHost =>
        { })
    .ConfigureAppConfiguration((hostContext, configApp) =>
        { })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient<SgvDownloader>("tls", (_, client) =>
        {
            client.BaseAddress = new Uri("https://yalibreatom.ru/api/v1/");
        });

        services.AddTransient<IMainApp, MainApp>();
    })
    .ConfigureLogging((hostContext, configLogging) =>
        { })
    .UseConsoleLifetime()
    .Build();

try
{
    var app = builder.Services.GetService<IMainApp>();
    await app!.Start();
}
catch (Exception ex)
{
    Console.WriteLine("Что-то не так!");
}
