namespace CH10_DataAccessBenchmarks.Configuration
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    internal class SecretsManager
    {
        public static IConfiguration Configuration { get; private set; }

        public static string GetSecrets<T>(string sectionName) where T : class
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (isDevelopment) //only add secrets in development
            {
                builder.AddUserSecrets<T>();
            }

            Configuration = builder.Build();

            return Configuration.GetSection($"{typeof(T).Name}:{sectionName}").Value;
        }
    }
}