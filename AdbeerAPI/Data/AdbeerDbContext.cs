using System;
using System.Collections.Generic;
using AdbeerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdbeerAPI.Data;

public partial class AdbeerDbContext : DbContext
{
    public AdbeerDbContext()
    {
    }

    public AdbeerDbContext(DbContextOptions<AdbeerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<BusStudent> BusStudents { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Guardian> Guardians { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-1JOJCUNM\\SQLEXPRESS;Database=AdbeerDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.Property(e => e.ApplicationUserId).HasMaxLength(450);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Discriminator).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_by");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasIndex(e => e.DriverId, "IX_Buses_DriverId").IsUnique();

            entity.HasIndex(e => e.SchoolId, "IX_Buses_SchoolId");

            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

            entity.HasOne(d => d.Driver).WithOne(p => p.Bus)
                .HasForeignKey<Bus>(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("test");

            entity.HasOne(d => d.School).WithMany(p => p.Buses).HasForeignKey(d => d.SchoolId);
        });

        modelBuilder.Entity<BusStudent>(entity =>
        {
            entity.HasIndex(e => e.BusId, "IX_BusStudents_BusId");

            entity.HasIndex(e => e.DriverId, "IX_BusStudents_DriverId");

            entity.HasIndex(e => e.StudentId, "IX_BusStudents_StudentId");

            entity.HasOne(d => d.Bus).WithMany(p => p.BusStudents).HasForeignKey(d => d.BusId);

            entity.HasOne(d => d.Driver).WithMany(p => p.BusStudents).HasForeignKey(d => d.DriverId);

            entity.HasOne(d => d.Student).WithMany(p => p.BusStudents).HasForeignKey(d => d.StudentId);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasIndex(e => e.ApplicationUserId, "IX_Drivers_ApplicationUserId");

            entity.HasIndex(e => e.SchoolId, "IX_Drivers_SchoolId");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.Drivers).HasForeignKey(d => d.ApplicationUserId);

            entity.HasOne(d => d.School).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Guardian>(entity =>
        {
            entity.ToTable("Guardian");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasIndex(e => e.SchoolId, "IX_Notifications__SchoolId");

            entity.HasIndex(e => e.SenderId1, "IX_Notifications__SenderId");

            entity.Property(e => e.SchoolId).HasColumnName("_SchoolId");
            entity.Property(e => e.SenderId1).HasColumnName("_SenderId");

            entity.HasOne(d => d.School).WithMany(p => p.Notifications).HasForeignKey(d => d.SchoolId);

            entity.HasOne(d => d.SenderId1Navigation).WithMany(p => p.Notifications).HasForeignKey(d => d.SenderId1);
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasIndex(e => e.AdministratorId, "IX_Schools_AdministratorId").IsUnique();

            entity.Property(e => e.AdministratorName).HasDefaultValueSql("(N'')");
            entity.Property(e => e.City).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Country).HasDefaultValueSql("(N'')");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Email).HasDefaultValueSql("(N'')");
            entity.Property(e => e.MobileNumber).HasDefaultValueSql("(N'')");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");

            entity.HasOne(d => d.Administrator).WithOne(p => p.School)
                .HasForeignKey<School>(d => d.AdministratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("test1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.ApplicationUserId, "IX_Students_ApplicationUserId");

            entity.HasIndex(e => e.GuardianId, "IX_Students_GuardianId");

            entity.HasIndex(e => e.SchoolId, "IX_Students_SchoolId");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.Students).HasForeignKey(d => d.ApplicationUserId);

            entity.HasOne(d => d.Guardian).WithMany(p => p.Students).HasForeignKey(d => d.GuardianId);

            entity.HasOne(d => d.School).WithMany(p => p.Students)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
