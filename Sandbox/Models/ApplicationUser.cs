using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string UserRole { get; set; }
        [PersonalData]
        public int CompanyID { get; set; }
        [PersonalData]
        public string CompanyName { get; set; }
    }
}
