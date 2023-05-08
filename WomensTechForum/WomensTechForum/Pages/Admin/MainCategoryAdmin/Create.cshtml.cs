using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WomensTechForum.Data;
using WomensTechForum.Models;

namespace WomensTechForum.Pages.Admin.MainCategoryAdmin
{
    public class CreateModel : PageModel
    {
        private readonly WomensTechForum.Data.WomensTechForumContext _context;

        public CreateModel(WomensTechForum.Data.WomensTechForumContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MainCategory MainCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MainCategory == null || MainCategory == null)
            {
                return Page();
            }

            _context.MainCategory.Add(MainCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
