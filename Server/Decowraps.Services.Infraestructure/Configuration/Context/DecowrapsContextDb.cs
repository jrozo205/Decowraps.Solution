using Decowraps.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Decowraps.Services.Infraestructure.Configuration.Context;

public partial class DecowrapsContextDb : DbContext
{
    public DecowrapsContextDb()
    {
    }

    public DecowrapsContextDb(DbContextOptions<DecowrapsContextDb> options)
        : base(options)
    {
    }

    public virtual DbSet<SellerEntity> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M2QAA4I;Database=DecowrapsDB;Trusted_Connection=True;User id=DecowrapsLogin; password=admin123; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SellerEntity>(entity =>
        {
            entity.HasKey(e => e.SellerId).HasName("PK__Sellers__7FE3DB815EF24E4F");

            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
