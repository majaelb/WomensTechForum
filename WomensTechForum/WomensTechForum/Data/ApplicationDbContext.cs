using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WomensTechForum.Models;

namespace WomensTechForum.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WomensTechForum.Models.MainCategory> MainCategory { get; set; } = default!;
        public DbSet<WomensTechForum.Models.Post> Post { get; set; } = default!;
        public DbSet<WomensTechForum.Models.SubCategory> SubCategory { get; set; } = default!;
    }
}