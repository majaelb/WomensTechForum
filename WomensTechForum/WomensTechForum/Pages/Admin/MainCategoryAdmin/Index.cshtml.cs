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
    public class IndexModel : PageModel
    {
        private readonly WomensTechForum.Data.WomensTechForumContext _context;

        public IndexModel(WomensTechForum.Data.WomensTechForumContext context)
        {
            _context = context;
        }

        public IList<MainCategory> MainCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MainCategory != null)
            {
                MainCategory = await _context.MainCategory.ToListAsync();
            }
        }
    }
}
