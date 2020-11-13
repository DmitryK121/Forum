using Microsoft.EntityFrameworkCore;

namespace Forum.Models {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Theme> Themes { get; set; }
    }
}
