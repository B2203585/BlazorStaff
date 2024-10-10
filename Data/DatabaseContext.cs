using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorStaff.Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost; database=database; uid=root; password=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DerparmentName).HasMaxLength(45);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(45)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.FirstName).HasMaxLength(45);
            entity.Property(e => e.GenderId)
                .HasMaxLength(45)
                .HasColumnName("GenderID");
            entity.Property(e => e.LastName).HasMaxLength(45);
            entity.Property(e => e.StartingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PRIMARY");

            entity.ToTable("gender");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GenderName).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
