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
    {
        _ = optionsBuilder.UseSqlServer("Server=.;Database=TestingProject;User ID=sa;Password=123;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Customer>(entity =>
        {
            _ = entity.ToTable("Customer");

            _ = entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            _ = entity.Property(e => e.CustomerName).HasMaxLength(50);
            _ = entity.Property(e => e.Email).HasMaxLength(50);
            _ = entity.Property(e => e.Phone).HasMaxLength(50);
        });

        _ = modelBuilder.Entity<Order>(entity =>
        {
            _ = entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("OrderID");
            _ = entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            _ = entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
        });

        _ = modelBuilder.Entity<Product>(entity =>
        {
            _ = entity.ToTable("Product");

            _ = entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            _ = entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            _ = entity.Property(e => e.Price).HasMaxLength(50);
            _ = entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        _ = modelBuilder.Entity<Purchase>(entity =>
        {
            _ = entity.ToTable("Purchase");

            _ = entity.Property(e => e.PurchaseId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseID");
        });

        _ = modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            _ = entity.ToTable("PurchaseDetail");

            _ = entity.Property(e => e.PurchaseDetailId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseDetailID");
            _ = entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            _ = entity.Property(e => e.PurchaseId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseID");
        });

        _ = modelBuilder.Entity<Supplier>(entity =>
        {
            _ = entity.ToTable("Supplier");

            _ = entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("SupplierID");
            _ = entity.Property(e => e.Address).HasMaxLength(50);
            _ = entity.Property(e => e.PhoneNo).HasMaxLength(50);
            _ = entity.Property(e => e.SupplierName).HasMaxLength(50);
        });

        _ = modelBuilder.Entity<ViPurchaseProcess>(entity =>
        {
            _ = entity
                .HasNoKey()
                .ToView("ViPurchaseProcess");

            _ = entity.Property(e => e.CustomerName).HasMaxLength(50);
            _ = entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .HasColumnName("ProductID");
            _ = entity.Property(e => e.ProductName).HasMaxLength(50);
            _ = entity.Property(e => e.PurchaseDetailId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseDetailID");
            _ = entity.Property(e => e.PurchaseId)
                .HasMaxLength(50)
                .HasColumnName("PurchaseID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
