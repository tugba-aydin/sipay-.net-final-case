using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedUsers(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUserRoles(modelBuilder);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User user = new User() {Id="1", Name = "Tuğba", Surname = "Aydın", Email = "tugba.aydinn.94@gmail.com",NormalizedEmail="TUGBA.AYDINN.94@GMAIL.COM", Role = "Admin", PasswordHash = passwordHasher.HashPassword(null, "Admin*123"), UserName = "tugbaa", NormalizedUserName="TUGBAA",Phone="05462825451",IdentityNumber="12345678998" };
            builder.Entity<User>().HasData(user);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "1" },
                        new IdentityRole() { Id = "2", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "2" });
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "1",
                    RoleId = "1"
                }
                );
        }
    }
}
