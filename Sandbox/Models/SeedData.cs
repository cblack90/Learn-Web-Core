using Sandbox.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPW)
        {
            using (var context = new SandboxContext(serviceProvider.GetRequiredService<DbContextOptions<SandboxContext>>()))
            {
               
                var adminID = await EnsureUser(serviceProvider, testUserPW, "admin@fullcirclevisuals.com");
                await EnsureRole(serviceProvider, adminID, Constants.AdministratorRole);

                var managerID = await EnsureUser(serviceProvider, testUserPW, "manager@fullcirclevisuals.com");
                await EnsureRole(serviceProvider, managerID, Constants.ManagerRole);

                

                SeedDB(context, adminID);
            }
        }//end of seed data
        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string testUserPW, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPW);
            }
            if(user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }
            return user.Id;
        }//end of EnsureUser
        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if(roleManager == null)
            {
                throw new Exception("roleManger null");
            }
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            var user = await userManager.FindByIdAsync(uid);

            if(user == null)
            {
                throw new Exception("The testUserPW password was prbably not strong enough!");
            }
            IR = await userManager.AddToRoleAsync(user, role);
            return IR;
        }
        public static void SeedDB(SandboxContext context, string adminID)
        {
            //Look for any movies
            if (context.Movie.Any())
            {
                return; //DB has been seeded
            }
            context.Movie.AddRange
                    (
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99m,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99m,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99m,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99m,
                        Rating = "R"
                    }
                    );
            context.SaveChanges();
        }
    }//end of class
}
