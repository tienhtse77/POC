using FengshuiChecker.Models;
using Microsoft.EntityFrameworkCore;

namespace FengshuiChecker.Repositories.PhoneNumberRepository
{
    public class PhoneNumberRepository : GenericRepository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(FengshuiCheckerDbContext context) : base(context) { }

        public async Task<PhoneNumber[]> GetAllPhoneNumbers()
        {
            return await _context.PhoneNumbers.Where(pn => pn.IsDeleted == true).ToArrayAsync();
        }
    }
}
