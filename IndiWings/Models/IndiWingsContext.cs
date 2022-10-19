using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IndiWings.Models
{
    public partial class IndiWingsContext : DbContext
    {
        public IndiWingsContext()
        {
        }

        public IndiWingsContext(DbContextOptions<IndiWingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; } = null!;
        public virtual DbSet<AirlineDetail> AirlineDetails { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Code> Codes { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Loginpage> Loginpages { get; set; } = null!;
        public virtual DbSet<Passengerchart> Passengercharts { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=IndiWings;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.Flightid)
                    .HasName("PK_Fid");

                entity.ToTable("Airline");

                entity.Property(e => e.Flightid)
                    .ValueGeneratedNever()
                    .HasColumnName("flightid");

                entity.Property(e => e.Arrival)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.AvailableDates).HasColumnType("date");

                entity.Property(e => e.Cid).ValueGeneratedOnAdd();

                entity.Property(e => e.Departure)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Departurecode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FlightTimings)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stat).HasColumnName("stat");
            });

            modelBuilder.Entity<AirlineDetail>(entity =>
            {
                entity.HasKey(e => e.Flightname)
                    .HasName("PK_Fname");

                entity.Property(e => e.Flightname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("flightname");

                entity.Property(e => e.Arrival)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("arrival");

                entity.Property(e => e.Availableseats).HasColumnName("availableseats");

                entity.Property(e => e.Departure)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("departure");

                entity.Property(e => e.Flightid).HasColumnName("flightid");

                entity.Property(e => e.Seatno).HasColumnName("seatno");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.AirlineDetails)
                    .HasForeignKey(d => d.Flightid)
                    .HasConstraintName("FK_Fid");

                entity.HasOne(d => d.SeatnoNavigation)
                    .WithMany(p => p.AirlineDetails)
                    .HasForeignKey(d => d.Seatno)
                    .HasConstraintName("FK_seatno");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Booking");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookingId).ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.ClassType)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.PassangerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode).HasColumnName("pincode");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.HasKey(e => e.Citycode)
                    .HasName("PK_CityCode");

                entity.Property(e => e.Citycode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Logins__536C85E5C8A80EE1");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Loginpage>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__Loginpag__CA1FE4643DB3F958");

                entity.ToTable("Loginpage");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Passengerchart>(entity =>
            {
                entity.HasKey(e => e.Seatno)
                    .HasName("PK_seatno");

                entity.ToTable("Passengerchart");

                entity.Property(e => e.Seatno).HasColumnName("seatno");

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Passengercharts)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_Passengerid");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Bookingid)
                    .HasName("PK_BookingId");

                entity.ToTable("Payment");

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Cvv).HasColumnName("cvv");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("date")
                    .HasColumnName("expirydate");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK_id");

                entity.ToTable("Registration");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
