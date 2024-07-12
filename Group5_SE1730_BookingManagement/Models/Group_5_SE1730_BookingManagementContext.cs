using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace Group5_SE1730_BookingManagement.Models
{

    // dotnet aspnet-codegenerator identity -dc Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext
    public partial class Group_5_SE1730_BookingManagementContext : IdentityDbContext<Guest>
    {
        public Group_5_SE1730_BookingManagementContext()
        {
        }

        public Group_5_SE1730_BookingManagementContext(DbContextOptions<Group_5_SE1730_BookingManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Guest> Guests { get; set; } = null!;
        public virtual DbSet<Homestay> Homestays { get; set; } = null!;
        public virtual DbSet<HomstayFeature> HomstayFeatures { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("server=QUANGKHONGWJBU\\SA;database=Group_5_SE1730_BookingManagement;uid=sa;pwd=123456;TrustServerCertificate=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.GuestId).HasColumnName("GuestID");

                entity.Property(e => e.HomestayId).HasColumnName("HomestayID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.SpecialReq).HasColumnType("text");
                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GuestId)
                    .HasConstraintName("FK_Booking_Guest");

                entity.HasOne(d => d.Homestay)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.HomestayId)
                    .HasConstraintName("FK_Booking_Homestay");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Booking_Room");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Code).HasColumnType("text");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.Status).HasDefaultValue(true);
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("Guest");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsFixedLength();
                entity.Property(e => e.Status).HasDefaultValue(true);

            });

            modelBuilder.Entity<Homestay>(entity =>
            {
                entity.ToTable("Homestay");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.HotelImage)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.HotelName)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Rating)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Status).HasDefaultValue(true);
            });

            modelBuilder.Entity<HomstayFeature>(entity =>
            {
                entity.ToTable("HomstayFeature");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Status).HasDefaultValue(true);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.GuestId).HasColumnName("GuestID");

                entity.Property(e => e.Notify).HasColumnType("text");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Invoice_Booking");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_Invoice_Discount");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.Property(e => e.GuestId).HasColumnName("GuestID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.GuestId)
                    .HasConstraintName("FK_Review_Guest");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Review_Room");
            });



            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.HomestayId).HasColumnName("HomestayID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.HasOne(d => d.Homestay)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HomestayId)
                    .HasConstraintName("FK_Room_Homestay");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK_Room_RoomType");

                entity.HasMany(d => d.Discounts)
                    .WithMany(p => p.Rooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoomDiscount",
                        l => l.HasOne<Discount>().WithMany().HasForeignKey("DiscountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RoomDiscount_Discount"),
                        r => r.HasOne<Room>().WithMany().HasForeignKey("RoomId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RoomDiscount_Room"),
                        j =>
                        {
                            j.HasKey("RoomId", "DiscountId");

                            j.ToTable("RoomDiscount");

                            j.IndexerProperty<long>("RoomId").HasColumnName("RoomID");

                            j.IndexerProperty<long>("DiscountId").HasColumnName("DiscountID");
                        });
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.HomestayFeatureId).HasColumnName("HomestayFeatureID");

                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.HasOne(d => d.HomestayFeature)
                    .WithMany(p => p.RoomTypes)
                    .HasForeignKey(d => d.HomestayFeatureId)
                    .HasConstraintName("FK_RoomType_HomstayFeature");
            });

            modelBuilder.Entity<Inbox>(entity =>
            {
                entity.ToTable("Inbox");

                entity.Property(e => e.FirstUserId);

                entity.Property(e => e.SecondUserId);

                entity.HasOne(d => d.FirstUser)
                    .WithMany(p => p.InboxFirstUsers)
                    .HasForeignKey(d => d.FirstUserId)
                    .HasConstraintName("FK__Inbox__FirstUser__398D8EEE");

                entity.HasOne(d => d.SecondUser)
                    .WithMany(p => p.InboxSecondUsers)
                    .HasForeignKey(d => d.SecondUserId)
                    .HasConstraintName("FK__Inbox__SecondUse__3A81B327");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.GuestId);

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.GuestId)
                    .HasConstraintName("FK__Message__GuestId__3D5E1FD2");

                entity.HasOne(d => d.Inbox)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.InboxId)
                    .HasConstraintName("FK__Message__InboxId__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
