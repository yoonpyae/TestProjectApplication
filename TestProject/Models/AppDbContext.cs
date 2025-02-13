using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<ViPurchaseProcess> ViPurchaseProcesses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=TestingProject;User ID=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.Price).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.ToTable("Purchase");

            entity.Property(e => e.PurchaseId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseID");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.ToTable("PurchaseDetail");

            entity.Property(e => e.PurchaseDetailId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseDetailID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.PurchaseId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseID");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(50);
        });

        modelBuilder.Entity<ViPurchaseProcess>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViPurchaseProcess");

            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.PurchaseDetailId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseDetailID");
            entity.Property(e => e.PurchaseId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
