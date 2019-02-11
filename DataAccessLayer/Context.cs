/*namespace DataAccessLayer
{
    using Microsoft.EntityFrameworkCore;
    using DataAccessLayer.Entities;
    
    public class Context: DbContext
    {
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=WatcWithMeDB;Trusted_Connection=True;");
            }
    }
}*/