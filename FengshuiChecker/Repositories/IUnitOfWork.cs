using FengshuiChecker.Console.Repositories.PhoneNumberRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace FengshuiChecker.Console.Repositories;

public interface IUnitOfWork
{
    IPhoneNumberRepository PhoneNumberRepository { get; }

    IDbContextTransaction GetTransaction();

    Task<int> CommitAsync();
}
