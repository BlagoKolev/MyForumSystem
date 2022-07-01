using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyForumSystem.Data;
using MyForumSystem.Data.Models;

namespace MyForumSystem.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);
            await SeedAdmin(services);
            CreateUsers(services);
            SeedCategories(services);
            SeedPosts(services);
            SeedComments(services); 

            return app;
        }


        private static void CreateUsers(IServiceProvider services)
        {
            var userManager = GetUserManager(services);

            var testUser = new IdentityUser
            {
                UserName = "testUser@mail.com",
                Email = "testUser@mail.com"
            };

            userManager.CreateAsync(testUser, "123456").GetAwaiter().GetResult();
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var db = GetDbContext(services);
            db.Database.Migrate();
        }
        private static async Task<IdentityResult> SeedAdmin(IServiceProvider services)
        {
            var userManager = GetUserManager(services);
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

            var db = GetDbContext(services);

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

            db.AddRangeAsync(categories).GetAwaiter().GetResult();
            db.SaveChangesAsync().GetAwaiter().GetResult();
        }
        private static void SeedPosts(IServiceProvider services)
        {
            var db = GetDbContext(services);
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var user = userManager.FindByEmailAsync("testUser@mail.com").GetAwaiter().GetResult();

            if (db.Posts.Any())
            {
                return;
            }

            //Posts to Sport category

            var firstSportPost = new Post
            {
                Title = "Football",
                Contents = "Who is your favourite football team?",
                CreatorId = user.Id,
                CategoryId = 1,
                CreatedOn = DateTime.UtcNow,
            };

            var secondSportPost = new Post
            {
                Title = "Formula 1",
                Contents = "Who is your favourite Formula 1 team?",
                CreatorId = user.Id,
                CategoryId = 1,
                CreatedOn = DateTime.UtcNow,
            };

            var thirdSportPost = new Post
            {
                Title = "Formula 1",
                Contents = "Who is your favourite Formula 1 driver?",
                CreatorId = user.Id,
                CategoryId = 1,
                CreatedOn = DateTime.UtcNow,
            };

            var fourthSportPost = new Post
            {
                Title = "Tennis",
                Contents = "Who is your favourite tennis player?",
                CreatorId = user.Id,
                CategoryId = 1,
                CreatedOn = DateTime.UtcNow,
            };

            var posts = new List<Post>() { firstSportPost, secondSportPost, thirdSportPost, fourthSportPost };
            db.AddRangeAsync(posts).GetAwaiter().GetResult();
            db.SaveChangesAsync().GetAwaiter().GetResult();
        }
        private static void SeedComments(IServiceProvider services)
        {
            var db = GetDbContext(services);
            var userManager = GetUserManager(services);
            var user = userManager.FindByEmailAsync("testUser@mail.com").GetAwaiter().GetResult();

            if (db.Comments.Any())
            {
                return;
            }

            //Comments to category Sport
            var firstSportComment = new Comment
            {
                Contents = "Manchester United",
                Creator = user,
                CreatorId = user.Id,
                Parrent = null,
                ParrentId = null,
                PostId = 1,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
            };
            var secondSportComment = new Comment
            {
                Contents = "Juventus",
                Creator = user,
                CreatorId = user.Id,
                Parrent = null,
                ParrentId = null,
                PostId = 1,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
            };
            var thirdSportComment = new Comment
            {
                Contents = "Chelsea",
                Creator = user,
                CreatorId = user.Id,
                Parrent = null,
                ParrentId = null,
                PostId = 1,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
            };

            //Comments to comments of category Sport

            var firstUnderSportComment = new Comment
            {
                Contents = "Yes they are great.",
                Creator = user,
                CreatorId = user.Id,
                Parrent = firstSportComment,
                ParrentId = 1,
                PostId = 1,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
            };
            var secondUnderSportComment = new Comment
            {
                Contents = "I think they are the best in Premier League.",
                Creator = user,
                CreatorId = user.Id,
                Parrent = firstSportComment,
                ParrentId = 1,
                PostId = 1,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
            };

            var comments = new List<Comment> { firstSportComment, secondSportComment, thirdSportComment,firstUnderSportComment, secondUnderSportComment };

            db.Comments.AddRangeAsync(comments).GetAwaiter().GetResult();
            db.SaveChangesAsync().GetAwaiter().GetResult();
        }
        private static UserManager<IdentityUser> GetUserManager(IServiceProvider services)
        {
            return services.GetRequiredService<UserManager<IdentityUser>>();
        }
        private static MyForumDbContext GetDbContext(IServiceProvider services)
        {
            return services.GetRequiredService<MyForumDbContext>();
        }
    }
}

