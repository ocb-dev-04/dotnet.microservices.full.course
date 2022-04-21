using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IServiceProvider service)
        {
            using (var servicesScope = service.CreateScope())
            {
                AppDbContext? context = servicesScope.ServiceProvider.GetService<AppDbContext>();
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                SeedData(context);
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (context.Platforms.Any())
            {
                System.Console.WriteLine("--> al ready data saved...");
                return;
            }

            System.Console.WriteLine("--> Seeding data...");

            context.Platforms.AddRange(
                new Platform() { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "Kubernetes", Publisher = "CNCF", Cost = "Free" }
            );

            context.SaveChanges();
        }
    }
}