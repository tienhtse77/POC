using Microsoft.EntityFrameworkCore.Storage;

namespace FengshuiChecker.Console.Interfaces;

public interface IUnitOfWork
{
    IPhoneNumberRepository PhoneNumberRepository { get; }

    IDbContextTransaction GetTransaction();

    Task<int> CommitAsync();
}
