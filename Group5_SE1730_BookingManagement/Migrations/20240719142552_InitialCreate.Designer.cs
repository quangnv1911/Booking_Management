﻿// <auto-generated />
using System;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Group5_SE1730_BookingManagement.Migrations
{
    [DbContext(typeof(Group_5_SE1730_BookingManagementContext))]
    [Migration("20240719142552_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CheckInDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CheckOutDate")
                        .HasColumnType("datetime");

                    b.Property<string>("GuestId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("GuestID");

                    b.Property<long?>("HomestayId")
                        .HasColumnType("bigint")
                        .HasColumnName("HomestayID");

                    b.Property<int?>("NumAdults")
                        .HasColumnType("int");

                    b.Property<int?>("NumChildren")
                        .HasColumnType("int");

                    b.Property<long?>("RoomId")
                        .HasColumnType("bigint")
                        .HasColumnName("RoomID");

                    b.Property<string>("SpecialReq")
                        .HasColumnType("text");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("HomestayId");

                    b.HasIndex("RoomId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Discount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CurrentUses")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("MaxUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("Discount", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FAQs");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Guest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Guest", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Homestay", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("GuestId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("GuestID");

                    b.Property<string>("HotelName")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<string>("Rating")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.ToTable("Homestay", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.HomstayFeature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("HomstayFeature", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Inbox", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FirstUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecondUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FirstUserId");

                    b.HasIndex("SecondUserId");

                    b.ToTable("Inbox", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("BookingId")
                        .HasColumnType("bigint")
                        .HasColumnName("BookingID");

                    b.Property<long?>("DiscountId")
                        .HasColumnType("bigint")
                        .HasColumnName("DiscountID");

                    b.Property<string>("GuestId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GuestID");

                    b.Property<string>("Notify")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique()
                        .HasFilter("[BookingID] IS NOT NULL");

                    b.HasIndex("DiscountId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<string>("GuestId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long?>("InboxId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("InboxId");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("GuestId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("GuestID");

                    b.Property<byte?>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<string>("ReviewText")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReviewText");

                    b.Property<long?>("RoomId")
                        .HasColumnType("bigint")
                        .HasColumnName("RoomID");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("HomestayId")
                        .HasColumnType("bigint")
                        .HasColumnName("HomestayID");

                    b.Property<string>("Img")
                        .HasColumnType("text")
                        .HasColumnName("Img");

                    b.Property<int?>("MaxGuests")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<long?>("RoomTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("RoomTypeID");

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("HomestayId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.RoomType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<long?>("HomestayFeatureId")
                        .HasColumnType("bigint")
                        .HasColumnName("HomestayFeatureID");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<bool?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("HomestayFeatureId");

                    b.ToTable("RoomType", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.SiteSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaviconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivacyText")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SiteSettings", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("RoomDiscount", b =>
                {
                    b.Property<long>("RoomId")
                        .HasColumnType("bigint")
                        .HasColumnName("RoomID");

                    b.Property<long>("DiscountId")
                        .HasColumnType("bigint")
                        .HasColumnName("DiscountID");

                    b.HasKey("RoomId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.ToTable("RoomDiscount", (string)null);
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Booking", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId")
                        .HasConstraintName("FK_Booking_Guest");

                    b.HasOne("Group5_SE1730_BookingManagement.Models.Homestay", "Homestay")
                        .WithMany("Bookings")
                        .HasForeignKey("HomestayId")
                        .HasConstraintName("FK_Booking_Homestay");

                    b.HasOne("Group5_SE1730_BookingManagement.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_Booking_Room");

                    b.Navigation("Guest");

                    b.Navigation("Homestay");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Homestay", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", "Guest")
                        .WithMany("Homestays")
                        .HasForeignKey("GuestId")
                        .HasConstraintName("FK_HomeStay_Guest");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Inbox", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", "FirstUser")
                        .WithMany("InboxFirstUsers")
                        .HasForeignKey("FirstUserId")
                        .HasConstraintName("FK__Inbox__FirstUser__398D8EEE");

                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", "SecondUser")
                        .WithMany("InboxSecondUsers")
                        .HasForeignKey("SecondUserId")
                        .HasConstraintName("FK__Inbox__SecondUse__3A81B327");

                    b.Navigation("FirstUser");

                    b.Navigation("SecondUser");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Invoice", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Booking", "Booking")
                        .WithOne("Invoices")
                        .HasForeignKey("Group5_SE1730_BookingManagement.Models.Invoice", "BookingId")
                        .HasConstraintName("FK_Invoice_Booking");

                    b.HasOne("Group5_SE1730_BookingManagement.Models.Discount", "Discount")
                        .WithMany("Invoices")
                        .HasForeignKey("DiscountId")
                        .HasConstraintName("FK_Invoice_Discount");

                    b.Navigation("Booking");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Message", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", "Guest")
                        .WithMany("Messages")
                        .HasForeignKey("GuestId")
                        .HasConstraintName("FK__Message__GuestId__3D5E1FD2");

                    b.HasOne("Group5_SE1730_BookingManagement.Models.Inbox", "Inbox")
                        .WithMany("Messages")
                        .HasForeignKey("InboxId")
                        .HasConstraintName("FK__Message__InboxId__3E52440B");

                    b.Navigation("Guest");

                    b.Navigation("Inbox");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Review", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", "Guest")
                        .WithMany("Reviews")
                        .HasForeignKey("GuestId")
                        .HasConstraintName("FK_Review_Guest");

                    b.HasOne("Group5_SE1730_BookingManagement.Models.Room", "Room")
                        .WithMany("Reviews")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_Review_Room");

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Room", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Homestay", "Homestay")
                        .WithMany("Rooms")
                        .HasForeignKey("HomestayId")
                        .HasConstraintName("FK_Room_Homestay");

                    b.HasOne("Group5_SE1730_BookingManagement.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .HasConstraintName("FK_Room_RoomType");

                    b.Navigation("Homestay");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.RoomType", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.HomstayFeature", "HomestayFeature")
                        .WithMany("RoomTypes")
                        .HasForeignKey("HomestayFeatureId")
                        .HasConstraintName("FK_RoomType_HomstayFeature");

                    b.Navigation("HomestayFeature");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Guest", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoomDiscount", b =>
                {
                    b.HasOne("Group5_SE1730_BookingManagement.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .IsRequired()
                        .HasConstraintName("FK_RoomDiscount_Discount");

                    b.HasOne("Group5_SE1730_BookingManagement.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK_RoomDiscount_Room");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Booking", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Discount", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Guest", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Homestays");

                    b.Navigation("InboxFirstUsers");

                    b.Navigation("InboxSecondUsers");

                    b.Navigation("Messages");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Homestay", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.HomstayFeature", b =>
                {
                    b.Navigation("RoomTypes");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Inbox", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Group5_SE1730_BookingManagement.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}