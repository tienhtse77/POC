﻿using FengshuiChecker.Models;
using FengshuiChecker.Repositories;
using FengshuiChecker.Repositories.PhoneNumberRepository;
using FengshuiChecker.Services.PhoneNumberService;
using FengshuiChecker.Services.RuleValidationService;
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
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddTransient<MainClass>())
        .Build();

    Console.WriteLine("Hello, World!");
    var entryPoint = host.Services.GetRequiredService<MainClass>();
    await entryPoint.Run();

} catch (Exception ex)
{
    Console.WriteLine("Application failed to start", ex);
    throw;
}

public class MainClass
{
    private IPhoneNumberService service;

    public MainClass(IPhoneNumberService service)
    {
        this.service = service;
    }

    public async Task Run(CancellationToken stoppingToken = default)
    {
        (await service.GetShengfuiPhoneNumbers()).ToList().ForEach(phoneNumber => Console.WriteLine(phoneNumber));
    }
}
