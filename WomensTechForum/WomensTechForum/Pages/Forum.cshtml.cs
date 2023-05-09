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
        public MainCategory ChosenMainCategory { get; set; }
        public SubCategory ChosenSubCategory { get; set; }
        [BindProperty]
        public Post NewPost { get; set; }

        public IFormFile? UploadedImage { get; set; } //L�ggs utanf�r databas-inneh�llet f�r att sparas som en str�ng i db l�ngre ner
        
        
        public async Task<IActionResult> OnGetAsync(int chosenMainId, int chosenSubId)
        {
            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();

            if(chosenMainId != 0)
            {
                ChosenMainCategory = MainCategories.FirstOrDefault(c => c.Id == chosenMainId);
            }
            if(chosenSubId != 0) 
            {
                ChosenSubCategory = SubCategories.FirstOrDefault(c => c.Id == chosenSubId);
            }

            return Page();
        }
    }
}
