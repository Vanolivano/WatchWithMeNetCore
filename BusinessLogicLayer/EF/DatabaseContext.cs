using System;
using BusinessLogicLayer.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.EF
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        

        // Запускается при комадах
        // dotnet ef migrations add "Name",
        // dotnet ef migrations remove,
        // dotnet ef database update 
//        public DatabaseContext()
//        {
////            base.Database.EnsureDeleted();// Удаляет базу если она есть
////            base.Database.EnsureCreated(); // Создает базу если ее нет
////            base.Database.Migrate(); //Выполняет последнюю миграцию
//        }
        
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
//            base.Database.EnsureDeleted();// Удаляет базу если она есть
//            base.Database.EnsureCreated(); // Создает базу если ее нет
            base.Database.Migrate(); //Выполняет последнюю миграцию
        }

        // Вспомогательный метод нужен для корректной работы конструктора без параметров
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//           if (!optionsBuilder.IsConfigured)
//            {
//                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//               optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WatchWithMeDb;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
////            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.19074.3");
//            base.OnModelCreating(modelBuilder);
//            
//        }
    }
}
