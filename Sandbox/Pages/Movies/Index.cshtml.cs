using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sandbox.Data;
using Sandbox.Models;

namespace Sandbox.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Sandbox.Data.SandboxContext _context;

        public IndexModel(Sandbox.Data.SandboxContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
