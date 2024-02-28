using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Resturant.Models.Context
{
    public class ProjectContext:IdentityDbContext<AppUser>
    {
        public ProjectContext() : base(){ }

        public ProjectContext(DbContextOptions<ProjectContext>options):base(options){ }


        public DbSet<Book> Books { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<BookProducts> BookProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<BookProduct>().HasKey(e => new { e.prodId, e.bookId });
            //builder.Entity<BookProducts>().HasKey(bc => new { bc.prodId, bc.bookId });

            //builder.Entity<BookProducts>().HasOne(b => b.bookId).WithMany(bg => bg.prodId).HasForeignKey(bc => bc.begripId);
            //builder.Entity<BookProducts>().HasOne(c => c.prodId).WithMany(ca => ca.Begrippen).HasForeignKey(cc => cc.categoryId);

        }


    }
}
