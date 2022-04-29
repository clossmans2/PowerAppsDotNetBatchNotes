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

            var schoolFactory = new SchoolContextFactory(appSettings.ConnectionString);
            var blankParams = new string[] { };
            var schoolContext = schoolFactory.CreateDbContext(blankParams);
            CreateDbIfNotExists(schoolContext);

        }

        private static void CreateDbIfNotExists(SchoolContext ctx)
        {
            try
            {
                //ctx.Database.EnsureDeleted();
                DbInitializer.Initialize(ctx);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An Error Occurred: {ex.Message}");
            }
        }

    }
}
