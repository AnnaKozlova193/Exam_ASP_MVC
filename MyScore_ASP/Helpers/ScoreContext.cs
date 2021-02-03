namespace MyScore_ASP.Helpers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MyScore_ASP.Models;

    public partial class ScoreContext : DbContext
    {
        public ScoreContext()
            : base("name=ScoreContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Table_Matufactur> Table_Matufactur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.IdCategory);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Table_Matufactur)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.IdCategory);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Clients)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.IdProduct);

            modelBuilder.Entity<Table_Matufactur>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Table_Matufactur)
                .HasForeignKey(e => e.IdManufacturer);
        }
    }
}
