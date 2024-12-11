
namespace T9Spelling;

public class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var app = host.Services.GetRequiredService<IApp>();
        app.Run("input.txt", "output.txt");
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                var mappingService = new T9MappingService();
                var t9Mapping = mappingService.GetMapping();
                services.AddSingleton<IT9MappingService>(mappingService);
                services.AddAutoMapper(cfg => cfg.AddProfile(new T9Profile(t9Mapping)));
                services.AddTransient<IT9TranslatorService, T9TranslatorService>();
                services.AddTransient<IApp, App>();
            });
}