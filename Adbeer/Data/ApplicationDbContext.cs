﻿using Adbeer.Data.Constrains;
using Adbeer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection.Emit;

namespace Adbeer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            

            //Applay constrains
            Builder.ApplyConfiguration(new BusStudentsConstrains());

            //GUID
            string Admin_Role_Id = "9a00de05-ab2c-4692-82b2-d33f0f50eb7e";
            string Admin_User_Id = "f1446937-109c-4e1a-97ce-0560442484f5";


            //Add Role
            Builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Admin_Role_Id,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = Admin_Role_Id

            });

            //Add Admin User
            var adminUser = new ApplicationUser
            {
                Id = Admin_User_Id,
                FullName = "System Administrator",
                Email = "Administrator@admin.com",
                NormalizedEmail = "ADMINISTRATOR@ADMIN.COM",
                UserName = "System_Administrator",
                Phone = "97259000000"
            };

            //Password Hasher
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123456");
            Builder.Entity<ApplicationUser>().HasData(adminUser);
            //Add Role To AdminUser
            Builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = Admin_Role_Id,
                    UserId = Admin_User_Id
                }
                );

            base.OnModelCreating(Builder);
        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusStudents> BusStudents { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<School> Schools { get; set; }

    }
}