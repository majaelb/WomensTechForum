using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WomensTechForum.Data;
using WomensTechForum.Models;

namespace WomensTechForum.Pages.Admin.MainCategoryAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly WomensTechForum.Data.ApplicationDbContext _context;

        public DetailsModel(WomensTechForum.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public MainCategory MainCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MainCategory == null)
            {
                return NotFound();
            }

            var maincategory = await _context.MainCategory.FirstOrDefaultAsync(m => m.Id == id);
            if (maincategory == null)
            {
                return NotFound();
            }
            else 
            {
                MainCategory = maincategory;
            }
            return Page();
        }
    }
}
