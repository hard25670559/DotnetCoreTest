using System;
using ManyToManyTest.Model;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyTest
{
    public class MTMContext : DbContext
    {

        public MTMContext(DbContextOptions<MTMContext> options) : base(options)
        {

        }

        private void BuildDefault<T>(ModelBuilder modelBuilder) where T : BaseModel
        {
            modelBuilder.Entity<T>()
                .Property(model => model.Create)
                .HasDefaultValueSql("datetime('now', 'localtime')");

            modelBuilder.Entity<T>()
                .Property(model => model.Update)
                .HasDefaultValueSql("datetime('now', 'localtime')");

            modelBuilder.Entity<T>()
                .Property(model => model.Delete)
                .HasDefaultValue(false);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            this.BuildDefault<User>(modelBuilder);
            this.BuildDefault<Product>(modelBuilder);
            this.BuildDefault<UserProduct>(modelBuilder);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

    }
}
