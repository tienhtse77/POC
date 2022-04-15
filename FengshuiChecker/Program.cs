using FengshuiChecker.Console.Interfaces;
using FengshuiChecker.Console.Models;
using FengshuiChecker.Console.Repositories.PhoneNumberRepository;
using FengshuiChecker.Console.Services.PhoneNumberService;
using FengshuiChecker.Console.Services.RuleValidationService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

try
{
    IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
    IConfiguration configuration = configBuilder.Build();
    var connectionString = configuration.GetConnectionString("DefaultConnectionString");

    using IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services
                .AddDbContext<FengshuiCheckerDbContext>(options =>
                    options.UseSqlServer(connectionString, sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(3),
                        errorNumbersToAdd: null);
                    }))
                .AddScoped<IPhoneNumberService, PhoneNumberService>()
                .AddScoped<IFengshuiPhoneNumberValidator, FengshuiPhoneNumberValidator>()
                .AddScoped<IPhoneNumberRepository, PhoneNumberRepository>()
                .AddTransient<MainClass>())
        .Build();

    var entryPoint = host.Services.GetRequiredService<MainClass>();
    await entryPoint.Run();

} catch (Exception ex)
{
    Console.WriteLine("Application failed to start: ", ex);
}

public class MainClass
{
    private IPhoneNumberService service;

    public MainClass(IPhoneNumberService service)
    {
        this.service = service;
    }

    public async Task Run()
    {
        
        var result =  await service.GetShengfuiPhoneNumbers();

        if (result != null && result.Length == 0)
        {
            Console.WriteLine("There are NO Fengshui phone numbers in the system!");
            return;
        }

        Console.WriteLine("List of Fengshui phone numbers in the system: ");
        result.ToList().ForEach(phoneNumber => Console.WriteLine(phoneNumber));
    }
}
