using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CinemaGlushkovApi.Models
{
    public partial class CinemaGlushkovContext : DbContext
    {
        public CinemaGlushkovContext()
        {
        }

        public CinemaGlushkovContext(DbContextOptions<CinemaGlushkovContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buffet> Buffets { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=K27-10\\SQLEXPRESS;Database=CinemaGlushkov;user id=sa;password=111;encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buffet>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("Buffet");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("Employee");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.EmployeePost).HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdMovie);

                entity.Property(e => e.IdMovie).HasColumnName("idMovie");

                entity.Property(e => e.FilmCompany).HasMaxLength(50);

                entity.Property(e => e.MovieLenght).HasMaxLength(50);

                entity.Property(e => e.MovieName).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("idOrder");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.IdTicket).HasColumnName("idTicket");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Employee");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Orders_Buffet");

                entity.HasOne(d => d.IdTicketNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdTicket)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Tickets");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket);

                entity.Property(e => e.IdTicket).HasColumnName("idTicket");

                entity.Property(e => e.IdMovie).HasColumnName("idMovie");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Time).HasColumnType("time(5)");

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Movies");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
