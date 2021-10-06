using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practies.DataLayer.Entities.Course;
using Practies.DataLayer.Entities.FoodPrograms;
using Practies.DataLayer.Entities.Permissions;
using Practies.DataLayer.Entities.Users;
using Practies.DataLayer.Entities.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practies.DataLayer.Context
{
    public class PractiesContext : DbContext
    {
        public PractiesContext(DbContextOptions<PractiesContext>options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<SalseOrderDetail> SalseOrderDetails { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.IsDelete);

            modelBuilder.Entity<CourseGroup>()
                .HasQueryFilter(g => !g.IsDelete);

            modelBuilder.Entity<Factor>()
                .HasOne(f => f.User).WithMany(f => f.Factors).HasForeignKey(f => f.User_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
