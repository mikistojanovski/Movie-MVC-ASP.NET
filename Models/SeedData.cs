using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using soprosopro.Areas.Identity.Data;
using soprosopro.Models;
#nullable disable
namespace soprosopro.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<soprosoproUser>>();
            IdentityResult roleResult;
            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }
            soprosoproUser user = await UserManager.FindByEmailAsync("admin@movie.com");
            if (user == null)
            {
                var User = new soprosoproUser();
                User.Email = "admin@movie.com";
                User.UserName = "admin@movie.com";
                string userPWD = "Movie123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Admin"); }
            }
            // creating Client role     
            roleCheck = await RoleManager.RoleExistsAsync("Client");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Client")); }
            user = await UserManager.FindByEmailAsync("Miki@movie.com");
            if (user == null)
            {
                var User = new soprosoproUser();
                User.Email = "Miki@movie.com";
                User.UserName = "Miki@movie.com";
                string userPWD = "Movie123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Client"); }
            }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new soprosoproContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<soprosoproContext>>());
            {
                CreateUserRoles(serviceProvider).Wait();
                // Look for any movies.
                if (context.Movie.Any() || context.Person.Any() || context.Genre.Any()||context.Client.Any())
                {
                    return; // DB has been seeded
                }
                context.Client.AddRange(new Client { Name = "Miki" , userId = context.Users.Single(x => x.Email == "Miki@movie.com").Id });
                context.SaveChanges();

                context.Movie.AddRange(
                       new Movie
                       {
                           Title = "abc",
                           ClientId=1
                       },
                         new Movie
                         {
                             Title = "cba",
                             ClientId = 1
                         }
                       ); context.SaveChanges();

                context.Genre.AddRange(
                    new Genre
                    {
                        Type = "Comedy"
                    },
                     new Genre
                     {
                         Type = "Slice Of Life"
                     }
                    );
                context.SaveChanges();
                context.Person.AddRange(
                    new Person
                    {
                        Name = "Mike"
                    },
                     new Person
                     {
                         Name = "Pyke"
                     }
                    );
                context.SaveChanges();

                context.MovieGenres.AddRange(
                    new MovieGenres
                    {
                        MovieId = 1,
                        GenreId = 1
                    },
                     new MovieGenres
                     {
                         MovieId = 2,
                         GenreId = 1
                     },
                      new MovieGenres
                      {
                          MovieId = 1,
                          GenreId = 2
                      }
                    );

                context.SaveChanges();

                context.MovieActors.AddRange(
                   new MovieActors
                   {
                       MovieId = 1,
                       ActorId = 1
                   },
                    new MovieActors
                    {
                        MovieId = 2,
                        ActorId = 1
                    },
                     new MovieActors
                     {
                         MovieId = 1,
                         ActorId = 2
                     }
                   );

                context.SaveChanges();
                context.MovieDirectors.AddRange(
                    new MovieDirectors
                    {
                        MovieId = 1,
                        DirectorId = 1
                    },
                     new MovieDirectors
                     {
                         MovieId = 2,
                         DirectorId = 1
                     },
                      new MovieDirectors
                      {
                          MovieId = 1,
                          DirectorId = 2
                      }
                    );

                context.SaveChanges();
                context.MovieProducers.AddRange(
                    new MovieProducers
                    {
                        MovieId = 1,
                        ProducerId = 1
                    },
                     new MovieProducers
                     {
                         MovieId = 2,
                         ProducerId = 1
                     },
                      new MovieProducers
                      {
                          MovieId = 1,
                          ProducerId = 2
                      }
                    );

                context.SaveChanges();
            }
        }
    }
}