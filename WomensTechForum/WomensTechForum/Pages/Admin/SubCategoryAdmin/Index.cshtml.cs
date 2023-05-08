using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WomensTechForum.Data;
using WomensTechForum.Models;

namespace WomensTechForum.Pages.Admin.SubCategoryAdmin
{
    public class IndexModel : PageModel
    {
        private readonly WomensTechForum.Data.ApplicationDbContext _context;

        public IndexModel(WomensTechForum.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SubCategory> SubCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SubCategory != null)
            {
                SubCategory = await _context.SubCategory
                .Include(s => s.MainCategory).ToListAsync();
            }
        }
    }
}
