using System;
using Microsoft.Extensions.Configuration;

namespace  ContosoUniversity
{
    public class Program
    {
        static AppSettings appSettings = new AppSettings();
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            ConfigurationBinder.Bind(configuration.GetSection("AppSettings"), appSettings);

            var context = new SchoolContext(appSettings.ConnectionString);

        }

    }
}
