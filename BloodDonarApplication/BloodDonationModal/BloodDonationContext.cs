using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BloodDonarApplication.BloodDonationModal
{
    public partial class BloodDonationContext : DbContext
    {
        public BloodDonationContext()
        {
        }

        public BloodDonationContext(DbContextOptions<BloodDonationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blooddonationcamp> Blooddonationcamps { get; set; }
        public virtual DbSet<Registertbl> Registertbls { get; set; }
        public virtual DbSet<Requirementstbl> Requirementstbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-497\\SQLSERVER2019NAN;Database=BloodDonation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Blooddonationcamp>(entity =>
            {
                entity.ToTable("Blooddonationcamp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateofcamp)
                    .HasColumnType("date")
                    .HasColumnName("dateofcamp");

                entity.Property(e => e.Timing)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("timing");

                entity.Property(e => e.Venue)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("venue");
            });

            modelBuilder.Entity<Registertbl>(entity =>
            {
                entity.ToTable("Registertbl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bloodgroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Requirementstbl>(entity =>
            {
                entity.ToTable("requirementstbl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bloodgroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("bloodgroup");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Contactperson)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contactperson");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Hospital)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hospital");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Patientage).HasColumnName("patientage");

                entity.Property(e => e.Patientgender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patientgender");

                entity.Property(e => e.Patientname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patientname");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("reason");

                entity.Property(e => e.Reqbefore)
                    .HasColumnType("datetime")
                    .HasColumnName("reqbefore");

                entity.Property(e => e.Units).HasColumnName("units");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
