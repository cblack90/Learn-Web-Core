using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sandbox.Models;

namespace Sandbox.Data
{
    public class SandboxContext : IdentityDbContext //DbContext
    {
        public SandboxContext (DbContextOptions<SandboxContext> options)
            : base(options) //options
        {
        }

        public DbSet<Sandbox.Models.Movie> Movie { get; set; }
        public DbSet<Sandbox.Models.CompanyInfo> CompanyInfo { get; set; }
    }
}
