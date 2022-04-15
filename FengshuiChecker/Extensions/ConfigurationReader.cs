using FengshuiChecker.Console.ViewModels.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace FengshuiChecker.Console.Extensions
{
    public static class ConfigurationReader
    {
        public static FengshuiConfiguration LoadConfiguration()
        {
            var contextPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (contextPath == null)
            {
                return null;
            }

            string path = Path.Combine(contextPath, @"fengshuiCondition.json");
            var rawConfig = File.ReadAllText(path);

            if (rawConfig == null)
            {
                return null;
            }

            var fengshuiConfig = JsonConvert.DeserializeObject<FengshuiConfiguration>(rawConfig);

            return fengshuiConfig;
        }
    }
}
