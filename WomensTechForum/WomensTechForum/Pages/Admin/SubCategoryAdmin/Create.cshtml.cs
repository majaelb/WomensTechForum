using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WomensTechForum.Data;
using WomensTechForum.Models;

namespace WomensTechForum.Pages.Admin.SubCategoryAdmin
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
        ViewData["MainCategoryId"] = new SelectList(_context.MainCategory, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SubCategory SubCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SubCategory == null || SubCategory == null)
            {
                return Page();
            }

            _context.SubCategory.Add(SubCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
