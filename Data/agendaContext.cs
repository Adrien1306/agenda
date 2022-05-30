using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using agenda.Models;

namespace agenda.Data
{
    public partial class agendaContext : DbContext
    {
        public agendaContext()
        {
        }

        public agendaContext(DbContextOptions<agendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Broker> Brokers { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DELL_ADRIEN\\SQLEXPRESS;Database=agenda;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateHour)
                    .HasColumnType("datetime")
                    .HasColumnName("dateHour");

                entity.Property(e => e.IdBrokers).HasColumnName("id_brokers");

                entity.Property(e => e.IdCustomers).HasColumnName("id_customers");

                entity.Property(e => e.Subject)
                    .HasColumnType("text")
                    .HasColumnName("subject");

                entity.HasOne(d => d.IdBrokersNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdBrokers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_brokers0_FK");

                entity.HasOne(d => d.IdCustomersNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCustomers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_customers_FK");
            });

            modelBuilder.Entity<Broker>(entity =>
            {
                entity.ToTable("brokers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
