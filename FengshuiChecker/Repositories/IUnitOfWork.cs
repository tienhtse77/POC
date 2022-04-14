using FengshuiChecker.Repositories.PhoneNumberRepository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengshuiChecker.Repositories
{
    public interface IUnitOfWork
    {
        IPhoneNumberRepository PhoneNumberRepository { get; }

        IDbContextTransaction GetTransaction();

        Task<int> CommitAsync();
    }
}
