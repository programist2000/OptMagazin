using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OptMagazin.Models;

namespace OptMagazin
{
    public class MagazinContext : DbContext
    {
        public MagazinContext() : base("DbConnection") { }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<WorkerChild> WorkerChildren { get; set; }

        public DbSet<Vacation> Vacations { get; set; }

        public DbSet<VacationSort> VacationSorts { get; set; }

        public DbSet<WorkerEducation> WorkerEducations { get; set; }

        public DbSet<University> Universities { get; set; }

        public DbSet<EducationSpecialty> EducationSpecialties { get; set; }

        public DbSet<WorkerPost> WorkerPosts { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<WorkerPrize> WorkerPrizes { get; set; }

        public DbSet<Prize> Prizes { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<WriteOffProduct> WriteOffProducts { get; set; }

        public DbSet<Cause> Causes { get; set; }

        public DbSet<SupplyProduct> SupplyProducts { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

    }

}