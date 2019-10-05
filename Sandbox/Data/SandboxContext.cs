using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sandbox.Models;

namespace Sandbox.Data
{
    public class SandboxContext : DbContext
    {
        public SandboxContext (DbContextOptions<SandboxContext> options)
            : base(options)
        {
        }

        public DbSet<Sandbox.Models.Movie> Movie { get; set; }
    }
}
