using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMedicineStore.Models;

namespace OnlineMedicineStore.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        ////public DbSet<DrugStore> DrugStores { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //	base.OnModelCreating(modelBuilder);
        //	modelBuilder.Entity<Stores>()
        //  .HasKey(x =>x.Id );
        //	modelBuilder.Entity<Drugs>()
        //  .HasKey(x => x.Id);
        //	modelBuilder.Entity<DrugStore>()
        //  .HasKey(x => new { x.StoresId,x.DrugsId});
        //	modelBuilder.Entity<DrugStore>()
        //		.HasOne(bc => bc.Drugs)
        //		.WithMany(b => b.Stores)
        //		.HasForeignKey(bc => bc.StoresId);
        //	modelBuilder.Entity<DrugStore>()
        //		.HasOne(bc => bc.Stores)
        //		.WithMany(c => c.Drugs)
        //		.HasForeignKey(bc => bc.DrugsId);
        //}
        public DbSet<Stores> Stores { get; set; }
		public DbSet<Drugs> Drugs { get; set; }
        public DbSet<StoreOwnerDetails> StoreOwnerDetails { get; set; }

	}

}
