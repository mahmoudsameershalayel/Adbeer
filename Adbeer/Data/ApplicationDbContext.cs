

using Adbeer.Data.Constrains;
using Adbeer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Adbeer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Bus>()
                .HasOne(e => e.Driver)
                .WithOne()
                .HasConstraintName("test")
                .OnDelete(DeleteBehavior.Restrict);
            Builder.Entity<School>()
                .HasOne(e => e.Administrator)
                .WithOne()
                .HasConstraintName("test1")
                .OnDelete(DeleteBehavior.Restrict);
            //Applay constrains
            Builder.ApplyConfiguration(new BusStudentsConstrains());
            Builder.ApplyConfiguration(new DriversSchoolConstrains());
            Builder.ApplyConfiguration(new StudentsSchoolConstrains());


            //GUID
            string Admin_Role_Id = "9a00de05-ab2c-4692-82b2-d33f0f50eb7e";
            string Driver_Role_Id = "6472ca7d-4acb-4550-9b9f-2d03321ad5e6";
            string Admin_User_Id = "f1446937-109c-4e1a-97ce-0560442484f5";


            //Add Administrator Role
            Builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Admin_Role_Id,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = Admin_Role_Id

            });

            //Add Driver Role
            Builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Driver_Role_Id,
                Name = "Driver",
                NormalizedName = "DRIVER",
                ConcurrencyStamp = Driver_Role_Id
            });
            //Add Admin User
            var adminUser = new ApplicationUser
            {
                Id = Admin_User_Id,
                FullName = "System Administrator",
                Email = "Administrator@admin.com",
                NormalizedEmail = "ADMINISTRATOR@ADMIN.COM",
                UserName = "System_Administrator",
                Phone = "97259000000",
                ImageName = ""
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
            //Add Admin to Administrator Table
            var administrator = new Administrator
            {
                Id = 8,
                ApplicationUserId = Admin_User_Id
            };
            Builder.Entity<Administrator>().HasData(administrator);

            //Add School To Administrator
            var school = new School
            {
                Id = 8,
                Name = "AdminSchool",
                AdministratorName = "System_Administrator",
                AdministratorId = administrator.Id,
                Address = "test",
                MobileNumber = "45626541851",
                Country = "Palestine",
                City = "Rafah",
                Email = "Administrator@admin.com",
                Password = "123456"
            };
            Builder.Entity<School>().HasData(school);

            base.OnModelCreating(Builder);
        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusStudents> BusStudents { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

    }
}