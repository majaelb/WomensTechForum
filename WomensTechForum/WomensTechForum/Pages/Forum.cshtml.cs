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

        [BindProperty]
        public Post ChosenPost { get; set; }
        [BindProperty]
        public PostThread ChosenPostThread { get; set; }
        public List<Post> Posts { get; set; }
        public List<PostThread> PostThreads { get; set; }


        [BindProperty]
        public Post NewPost { get; set; }

        [BindProperty]
        public PostThread NewPostThread { get; set; }

        [BindProperty]
        public IFormFile UploadedImage { get; set; } //Läggs utanför databas-innehållet för att sparas som en sträng i db längre ner


        public async Task<IActionResult> OnGetAsync(int chosenMainId, int chosenSubId, int chosenPostId, int deleteid, int changeId, int changePTId)
        {
            MainCategories = await _context.MainCategory.ToListAsync();
            SubCategories = await _context.SubCategory.ToListAsync();
            Posts = await _context.Post.ToListAsync();
            PostThreads = await _context.PostThread.ToListAsync();

            if (chosenMainId != 0)
            {
                ChosenMainCategory = MainCategories.FirstOrDefault(c => c.Id == chosenMainId);
            }
            if (chosenSubId != 0)
            {
                ChosenSubCategory = SubCategories.FirstOrDefault(c => c.Id == chosenSubId);
            }
            if (chosenPostId != 0)
            {
                ChosenPost = Posts.FirstOrDefault(c => c.Id == chosenPostId);
            }
            if (deleteid != 0)
            {
                Models.Post post = await _context.Post.FindAsync(deleteid);

                if (post != null)
                {
                    if (System.IO.File.Exists("./wwwroot/img/" + post.ImageSrc))
                    {
                        System.IO.File.Delete("./wwwroot/img/" + post.ImageSrc); //Ta bort bilden
                    }
                    _context.Post.Remove(post); //ta bort inlägget
                    await _context.SaveChangesAsync(); //Spara

                    return RedirectToPage("./Forum");//Tillbaka till startsidan
                }
            }
            if (changeId != 0)
            {
                Post offensivePost = await _context.Post.FindAsync(changeId);

                if (offensivePost != null)
                {
                    offensivePost.Offensive = true;
                    //offensivePost.NoOfReports += 1;
                    await _context.SaveChangesAsync();
                }
            }
            if (changePTId != 0)
            {
                PostThread offensivePost = await _context.PostThread.FindAsync(changePTId);

                if (offensivePost != null)
                {
                    offensivePost.Offensive = true;
                    //offensivePost.NoOfReports += 1;
                    await _context.SaveChangesAsync();
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostNewPostAsync()
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
            _context.Add(NewPost);
            await _context.SaveChangesAsync();



            return RedirectToPage("./Forum");
        }

        public async Task<IActionResult> OnPostNewPostThreadAsync()
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

            NewPostThread.Date = DateTime.Now;
            NewPostThread.ImageSrc = fileName;
            NewPostThread.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.Add(NewPostThread);
            await _context.SaveChangesAsync();



            return RedirectToPage("./Forum");
        }
        //public async Task<IActionResult> OnPostOffensiveAsync()
        //{
        //    ChosenPost.Offensive = true;
        //    ChosenPost.NoOfReports += 1;
        //    //if (ChosenPost.Id != 0)
        //    //{
        //    //    Post offensivePost = await _context.Post.FindAsync(ChosenPost.Id);

        //    //    if (offensivePost != null)
        //    //    {
        //    //        offensivePost.Offensive = true;
        //    //        offensivePost.NoOfReports += 1;
        //    //        await _context.SaveChangesAsync();
        //    //    }
        //    //}
        //    return RedirectToPage("./Forum");

        //}
    }
}
