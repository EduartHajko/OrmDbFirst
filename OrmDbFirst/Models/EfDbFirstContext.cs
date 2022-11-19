using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrmDbFirst.Models;

public partial class EfDbFirstContext : DbContext
{
    public EfDbFirstContext()
    {
    }

    public EfDbFirstContext(DbContextOptions<EfDbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<CallOutcome> CallOutcomes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=Ef_DbFirst;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Call>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("call_pk");

            entity.ToTable("call");

            entity.HasIndex(e => new { e.EmployeeId, e.StartTime }, "call_ak_1").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CallOutcomeId).HasColumnName("call_outcome_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");

            entity.HasOne(d => d.CallOutcome).WithMany(p => p.Calls)
                .HasForeignKey(d => d.CallOutcomeId)
                .HasConstraintName("call_call_outcome");

            entity.HasOne(d => d.Customer).WithMany(p => p.Calls)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("call_customer");

            entity.HasOne(d => d.Employee).WithMany(p => p.Calls)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("call_employee");
        });

        modelBuilder.Entity<CallOutcome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("call_outcome_pk");

            entity.ToTable("call_outcome");

            entity.HasIndex(e => e.OutcomeText, "call_outcome_ak_1").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OutcomeText)
                .HasMaxLength(128)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("outcome_text");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pk");

            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_address");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.NextCallDate)
                .HasColumnType("date")
                .HasColumnName("next_call_date");
            entity.Property(e => e.TsInserted)
                .HasColumnType("datetime")
                .HasColumnName("ts_inserted");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pk");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
