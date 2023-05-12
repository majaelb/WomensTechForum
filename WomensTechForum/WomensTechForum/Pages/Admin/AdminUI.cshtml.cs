using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WomensTechForum.Models;

namespace WomensTechForum.Pages.Admin
{
    public class AdminUIModel : PageModel
    {
        public List<Models.Post> ReportedPosts { get; set; }
        public List<Models.PostThread> ReportedPostThreads { get; set; }


        private readonly Data.ApplicationDbContext _context;
        public AdminUIModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        //public void OnGet()
        //{
        //    ReportedPosts = _context.Post.Where(p => p.Offensive == true).ToList();
        //    ReportedPostThreads = _context.PostThread.Where(p => p.Offensive == true).ToList();
        //}

        public async Task<IActionResult> OnGetAsync(int deleteId, int changeId, int deletePTId, int changePTId)
        {
            ReportedPosts = _context.Post.Where(p => p.Offensive == true).ToList();
            ReportedPostThreads = _context.PostThread.Where(p => p.Offensive == true).ToList();

            if (deleteId != 0)
            {
                Models.Post post = await _context.Post.FindAsync(deleteId);

                if (post != null)
                {
                    if (System.IO.File.Exists("./wwwroot/img/" + post.ImageSrc))
                    {
                        System.IO.File.Delete("./wwwroot/img/" + post.ImageSrc); //Ta bort bilden
                    }
                    _context.Post.Remove(post); //ta bort inlägget
                    await _context.SaveChangesAsync(); //Spara

                    return RedirectToPage("./AdminUI");//Tillbaka till startsidan
                }
            }

            if (changeId != 0)
            {
                Post offensivePost = await _context.Post.FindAsync(changeId);

                if (offensivePost != null)
                {
                    offensivePost.Offensive = false;
                    offensivePost.NoOfReports = 0;
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./AdminUI");
                }
            }

            if (deletePTId != 0)
            {
                Models.PostThread postthread = await _context.PostThread.FindAsync(deletePTId);

                if (postthread != null)
                {
                    if (System.IO.File.Exists("./wwwroot/img/" + postthread.ImageSrc))
                    {
                        System.IO.File.Delete("./wwwroot/img/" + postthread.ImageSrc); //Ta bort bilden
                    }
                    _context.PostThread.Remove(postthread); //ta bort inlägget
                    await _context.SaveChangesAsync(); //Spara

                    return RedirectToPage("./AdminUI");//Tillbaka till startsidan
                }
            }

            if (changePTId != 0)
            {
                PostThread offensivePostThread = await _context.PostThread.FindAsync(changePTId);

                if (offensivePostThread != null)
                {
                    offensivePostThread.Offensive = false;
                    offensivePostThread.NoOfReports = 0;
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./AdminUI");
                }
            }

            return Page();

        }
    }
}
