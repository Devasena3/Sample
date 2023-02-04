using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Domain.Models;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public  DbSet<ClassFeesRelation> ClassFeesRelations { get; set; }

    public  DbSet<ClassName> ClassNames { get; set; }

    public  DbSet<FeesCategory> FeesCategories { get; set; }

    public  DbSet<Payment> Payments { get; set; }

    public  DbSet<Registration> Registrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.2.0.4;Initial Catalog=UniteWorkshop;Persist Security Info=False;User ID=sa;Password=Unitecare!@#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassFeesRelation>(entity =>
        {
            entity.ToTable("ClassFeesRelation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Feescategory)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClassName>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClassName1)
                .HasMaxLength(50)
                .HasColumnName("ClassName");
        });

        modelBuilder.Entity<FeesCategory>(entity =>
        {
            entity.ToTable("FeesCategory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FeesAmount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.FeesCategory1)
                .HasMaxLength(50)
                .HasColumnName("FeesCategory");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.FeesAmount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.FeesCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaymentStaus).HasMaxLength(15);
            entity.Property(e => e.RollNo).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.ToTable("Registration");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ParentName).HasMaxLength(50);
            entity.Property(e => e.RollNo).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
