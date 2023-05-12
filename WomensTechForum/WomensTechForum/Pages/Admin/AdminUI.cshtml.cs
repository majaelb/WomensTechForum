using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public void OnGet()
        {
            ReportedPosts = _context.Post.Where(p => p.Offensive == true).ToList();
            ReportedPostThreads = _context.PostThread.Where(p => p.Offensive == true).ToList();
        }
    }
}
