using FengshuiChecker.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace FengshuiChecker.Console.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    internal readonly FengshuiCheckerDbContext _context;
    internal DbSet<T> dbSet;

    public GenericRepository(FengshuiCheckerDbContext context)
    {
        _context = context;
        dbSet = _context.Set<T>();
    }
}
