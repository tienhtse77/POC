using FengshuiChecker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Repositories
{
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
}
