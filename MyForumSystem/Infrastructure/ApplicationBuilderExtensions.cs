using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyForumSystem.Data;
using MyForumSystem.Data.Models;

namespace MyForumSystem.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);
            SeedAdmin(services);
            SeedCategories(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var db = services.GetRequiredService<MyForumDbContext>();
            db.Database.Migrate();
        }

        private static async Task<IdentityResult> SeedAdmin(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var result = new IdentityResult();

            if (await roleManager.RoleExistsAsync("Admin"))
            {
                return result;
            }

            var role = new IdentityRole("Admin");

            await roleManager.CreateAsync(role);

            var adminEmail = "admin@forum.com";
            var adminPassword = "admin";

            var adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail
            };

            await userManager.CreateAsync(adminUser, adminPassword);
            result = await userManager.AddToRoleAsync(adminUser, role.Name);
            return result;

        }
        private static void SeedCategories(IServiceProvider services)
        {

            var db = services.GetRequiredService<MyForumDbContext>();

            if (db.Categories.Any())
            {
                return;
            }

            var sportCategory = new Category
            {
                Name = "Sport",
                Description = "Here you can discuss all about sport.",
                Image = "https://image.shutterstock.com/image-vector/realistic-sports-balls-vector-big-600w-1017906871.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var moviesCategory = new Category
            {
                Name = "Movies",
                Description = "Here you can discuss all about your favourite films, tv shows and others.",
                Image = "https://image.shutterstock.com/image-illustration/one-red-cinema-chair-fizzy-600w-1457573270.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var musicCategory = new Category
            {
                Name = "Music",
                Description = "Here you can discuss all about music world.",
                Image = "https://image.shutterstock.com/image-vector/musical-instruments-colorful-flat-design-600w-1482016586.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var computerCategory = new Category
            {
                Name = "Computers and Programming",
                Description = "Here you can discuss all about high technologies.",
                Image = "https://image.shutterstock.com/image-vector/professional-programmer-writing-code-testing-600w-1926705251.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var lifestyleCategory = new Category
            {
                Name = "Lifestyle",
                Description = "Here you can discuss all about lifestyle.",
                Image = "https://image.shutterstock.com/image-vector/bundle-sixteen-healthy-lifestyle-set-600w-1922836826.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var repairsCategory = new Category
            {
                Name = "Repairs",
                Description = "Here you can discuss all about repairs and home stuff.",
                Image = "https://image.shutterstock.com/image-illustration/simple-repair-icon-wrench-turnscrew-600w-2093468854.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var financesCategory = new Category
            {
                Name = "Finances",
                Description = "Here you can discuss all about finances.",
                Image = "https://image.shutterstock.com/image-photo/coins-money-growing-plant-finance-600w-577166506.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var cultureCategory = new Category
            {
                Name = "Culture",
                Description = "Here you can discuss all about culture.",
                Image = "https://image.shutterstock.com/image-photo/culture-concept-chart-keywords-icons-600w-1056388772.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var gardeningCategory = new Category
            {
                Name = "Gardening",
                Description = "Here you can discuss all about gardening.",
                Image = "https://image.shutterstock.com/image-photo/gardening-tools-watering-can-seeds-600w-175282622.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var vehiclesCategory = new Category
            {
                Name = "Vehicles",
                Description = "Here you can discuss all about vehicles and racing.",
                Image = "https://image.shutterstock.com/image-vector/electric-car-charging-station-front-600w-1864450102.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var gamingCategory = new Category
            {
                Name = "Gaming",
                Description = "Here you can discuss all about gaming.",
                Image = "https://image.shutterstock.com/image-vector/vector-illustration-word-game-over-600w-1230400006.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var petsCategory = new Category
            {
                Name = "Pets",
                Description = "Here you can discuss all about pets.",
                Image = "https://image.shutterstock.com/image-photo/group-pets-posing-around-border-600w-1762836920.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            var categories = new List<Category>()
            {
                sportCategory,
                moviesCategory,
                musicCategory,
                computerCategory,
                lifestyleCategory,
                repairsCategory,
                financesCategory,
                cultureCategory,
                gardeningCategory,
                vehiclesCategory,
                gamingCategory,
                petsCategory
            };

            db.AddRange(categories);
            db.SaveChanges();
        }
    }
}

