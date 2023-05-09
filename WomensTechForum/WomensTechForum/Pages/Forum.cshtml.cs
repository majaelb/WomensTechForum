using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WomensTechForum.Models;

namespace WomensTechForum.Pages
{
    public class ForumModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public ForumModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public List<MainCategory>? MainCategories { get; set; }
        public List<SubCategory>? SubCategories { get; set; }

        [BindProperty]
        public Post NewPost { get; set; }

        public IFormFile? UploadedImage { get; set; } //L�ggs utanf�r databas-inneh�llet f�r att sparas som en str�ng i db l�ngre ner
        
        
        public async Task<IActionResult> OnGetAsync()
        {

            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();

            return Page();
        }
    }
}
