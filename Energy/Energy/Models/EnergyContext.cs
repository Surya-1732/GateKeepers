using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Energy.Models;

public partial class EnergyContext : DbContext
{
    public EnergyContext()
    {
    }

    public EnergyContext(DbContextOptions<EnergyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appliance> Appliances { get; set; }

    public virtual DbSet<Consumption> Consumptions { get; set; }

    public virtual DbSet<Cost> Costs { get; set; }

    public virtual DbSet<EnergyType> EnergyTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:hexathon2023server.database.windows.net,1433;Initial Catalog=Energy;Persist Security Info=False;User ID=hexathon2023;Password=Hexathon@2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appliance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Appliances");

            entity.ToTable("Appliance");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<Consumption>(entity =>
        {
            entity.ToTable("Consumption");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Cost>(entity =>
        {
            entity.ToTable("Cost");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EnergyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__energy_t__3213E83F2298000B");

            entity.ToTable("EnergyType");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
