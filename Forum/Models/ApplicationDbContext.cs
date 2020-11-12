using Microsoft.EntityFrameworkCore;

namespace Forum.Models {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Theme> Themes { get; set; }
    }
}
