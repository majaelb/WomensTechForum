﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WomensTechForum.Data;
using WomensTechForum.Models;

namespace WomensTechForum.Pages.Admin.PostAdmin
{
    public class IndexModel : PageModel
    {
        private readonly WomensTechForum.Data.ApplicationDbContext _context;

        public IndexModel(WomensTechForum.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Post != null)
            {
                Post = await _context.Post
                .Include(p => p.SubCategory).ToListAsync();
            }
        }
    }
}
