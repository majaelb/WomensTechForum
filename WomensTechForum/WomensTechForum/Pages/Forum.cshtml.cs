using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Security.Claims;
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
        public List<Post> Posts { get; set; }


        [BindProperty]
        public Post NewPost { get; set; }

        [BindProperty]
        public IFormFile UploadedImage { get; set; } //Läggs utanför databas-innehållet för att sparas som en sträng i db längre ner
        
        
        public async Task<IActionResult> OnGetAsync(int chosenMainId, int chosenSubId)
        {
            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();
            Posts = await _context.Post.ToListAsync();

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

        public async Task<IActionResult> OnPostAsync()
        {
            string fileName = string.Empty;

            if (UploadedImage != null)
            {
                Random rnd = new();
                fileName = rnd.Next(100000).ToString() + UploadedImage.FileName;
                var file = "./wwwroot/img/" + fileName;

                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }
            }

            NewPost.Date = DateTime.Now;
            NewPost.ImageSrc = fileName;
            NewPost.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //NewPost.SubCategoryId = ChosenSubCategory.Id;

            _context.Add(NewPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Forum"); 
        }
    }
}
