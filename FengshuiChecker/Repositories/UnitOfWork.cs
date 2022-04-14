using FengshuiChecker.Models;
using FengshuiChecker.Repositories.PhoneNumberRepository;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace FengshuiChecker.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FengshuiCheckerDbContext _context;

        private IPhoneNumberRepository _phoneNumberRepository;

        public IPhoneNumberRepository PhoneNumberRepository
        {
            get { return _phoneNumberRepository ??= new PhoneNumberRepository.PhoneNumberRepository(_context); }
        }

        public UnitOfWork(FengshuiCheckerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IDbContextTransaction GetTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
