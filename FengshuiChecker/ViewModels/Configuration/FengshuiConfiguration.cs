namespace FengshuiChecker.Console.ViewModels.Configuration;

public class FengshuiConfiguration
{
    public int MaxLength { get; set; }

    public string[] ForbiddenLastNumbers { get; set; }

    public string[] ValidLastNumbers { get; set; }

    public int MinSumFirst5Numbers { get; set; }

    public int MaxSumFirst5Numbers { get; set; }

    public int MinSumLast5Numbers { get; set; }

    public int MaxSumLast5Numbers { get; set; }
}
