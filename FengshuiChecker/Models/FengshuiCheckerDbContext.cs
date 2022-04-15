using Microsoft.EntityFrameworkCore;

namespace FengshuiChecker.Console.Models;

public class FengshuiCheckerDbContext : DbContext
{
    public FengshuiCheckerDbContext(DbContextOptions<FengshuiCheckerDbContext> options) : base(options) { }

    public DbSet<PhoneNetworkProvider> PhoneNetworkProviders { get; set; }

    public DbSet<PhoneNumber> PhoneNumbers { get; set; }

    public DbSet<PhoneNumberPrefix> PhoneNumberPrefixes { get; set; }
}
