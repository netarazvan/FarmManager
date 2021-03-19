using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FarmManager.Models;

#nullable disable

namespace FarmManager.Models
{
    public partial class mngArendaContext : DbContext
    {
        public mngArendaContext()
        {
        }

        public mngArendaContext(DbContextOptions<mngArendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cereale> Cereales { get; set; }
        public virtual DbSet<Clienti> Clientis { get; set; }
        public virtual DbSet<Defectiuni> Defectiunis { get; set; }
        public virtual DbSet<Inputuri> Inputuris { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Produse> Produses { get; set; }
        public virtual DbSet<Utilaje> Utilajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=mngArenda;user=neta; password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cereale>(entity =>
            {
                entity.ToTable("Cereale");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CantitateTone)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("Cantitate_Tone");

                entity.Property(e => e.IdProdus)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("idProdus");

                entity.HasOne(d => d.IdProdusNavigation)
                    .WithMany(p => p.Cereales)
                    .HasForeignKey(d => d.IdProdus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cereale_Produse");
            });

            modelBuilder.Entity<Clienti>(entity =>
            {
                entity.ToTable("Clienti");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Nume).HasMaxLength(50);

                entity.Property(e => e.SuprafataHa)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("Suprafata_ha");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Defectiuni>(entity =>
            {
                entity.ToTable("Defectiuni");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CostReparatie)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("Cost_Reparatie");

                entity.Property(e => e.Detalii).HasMaxLength(50);

                entity.Property(e => e.IdUtilaj)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("idUtilaj");

                entity.HasOne(d => d.IdUtilajNavigation)
                    .WithMany(p => p.Defectiunis)
                    .HasForeignKey(d => d.IdUtilaj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Defectiuni_Utilaje");
            });

            modelBuilder.Entity<Inputuri>(entity =>
            {
                entity.ToTable("Inputuri");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CantitateUm)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("Cantitate_UM");

                entity.Property(e => e.PretUm)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("Pret_UM");

                entity.Property(e => e.Producator)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Tip)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UnitateDeMasura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Unitate_de_masura");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Cantitate).HasColumnType("numeric(6, 0)");

                entity.Property(e => e.IdClient)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("idClient");

                entity.Property(e => e.IdProdus)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("idProdus");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Orders");

                entity.HasOne(d => d.IdProdusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdProdus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Produse");
            });

            modelBuilder.Entity<Produse>(entity =>
            {
                entity.ToTable("Produse");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PretKg)
                    .HasColumnType("numeric(3, 1)")
                    .HasColumnName("Pret_kg");

                entity.Property(e => e.Produs)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Utilaje>(entity =>
            {
                entity.ToTable("Utilaje");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.An).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Tip)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}