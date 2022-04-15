using System.ComponentModel.DataAnnotations;

namespace FengshuiChecker.Console.Models;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }
}
