using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Sandbox.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[PersonalData]
        //public string UserRole { get; set; }
        //public int UserID { get; set; }
        //[PersonalData]
        //public int CompanyID { get; set; }
        //[PersonalData]
        //public string CompanyName { get; set; }
        [PersonalData]
        public string CompanyID { get; set; }
        [PersonalData]
        public string CompanyName { get; set; }

 

    }
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole> 
    {
        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            :base(userManager, roleManager,optionsAccessor)
        { }
        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
            if (!string.IsNullOrWhiteSpace(user.CompanyName))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim(ClaimTypes.Name, user.CompanyName) });
            }
            if (!string.IsNullOrWhiteSpace(user.CompanyID))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim(ClaimTypes.NameIdentifier, user.CompanyID) });
            }
            return principal;
        }
    }
    public static class IdentityExtensions
    {
        public static string CompanyName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Name);
            //test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string CompanyID(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }

//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext() : base("SandboxContext", throwIfV1Schema: false)
//        {
//            Database.SetInitializer(new SeedData());
//        }
//        public static ApplicationDbContext Create()
//        {
//            return new ApplicationDbContext();
//        }
//    }
}
