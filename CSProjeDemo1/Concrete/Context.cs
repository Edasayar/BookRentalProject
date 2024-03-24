using CSProjeDemo1.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Concrete
{
    public class Context:DbContext
    {
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

            
        //    modelBuilder.Entity<BookHistory>().ToTable("BookHistories");

           
        //    modelBuilder.Entity<BookNovel>().ToTable("BookNovels");

           
        //    modelBuilder.Entity<BookScience>().ToTable("BookSciences");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Eda\\MSSQLSERVER01;initial catalog=LibraryDb; integrated security=true; TrustServerCertificate=true;");
        }

        public DbSet<BaseBook> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookHistory> BookHistories { get; set; }
        public DbSet<BookNovel> BookNovels { get; set; }
        public DbSet<BookScience> BookSciences { get; set; }
        public DbSet<Library> Libraries { get; set; }
    }
}
