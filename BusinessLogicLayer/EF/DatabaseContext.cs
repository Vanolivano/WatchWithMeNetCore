using BusinessLogicLayer.Domains;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.EF
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        
        public DatabaseContext()
        {
            base.Database.EnsureDeleted();
            base.Database.EnsureCreated();
            //base.Database.Migrate();
            
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WatchWithMeDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.19074.3");
            
        }
    }
}
