using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Entities;

#nullable disable

namespace WebApi.Data
{
    public partial class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<ServiceWorker> ServiceWorkers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //efter vi byggt db -vi behover inte det
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //      optionsBuilder.UseSqlServer("Server=tcp:dbnat.database.windows.net,1433;Initial Catalog=sqlwebapi;Persist Security Info=False;User ID=natlee;Password=tindra52#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    }
        //}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.IssueDescription).IsRequired();

                entity.Property(e => e.IssueStatus)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ResolveDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issues__Customer__656C112C");

                entity.HasOne(d => d.ServiceWorker)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.ServiceWorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issues__ServiceW__66603565");
            });

            modelBuilder.Entity<ServiceWorker>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
