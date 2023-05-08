using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WomensTechForum.Models;

namespace WomensTechForum.Data
{
    public class WomensTechForumContext : DbContext
    {
        public WomensTechForumContext (DbContextOptions<WomensTechForumContext> options)
            : base(options)
        {
        }

        public DbSet<WomensTechForum.Models.MainCategory> MainCategory { get; set; } = default!;

        public DbSet<WomensTechForum.Models.SubCategory> SubCategory { get; set; } = default!;

        public DbSet<WomensTechForum.Models.Post> Post { get; set; } = default!;
    }
}
