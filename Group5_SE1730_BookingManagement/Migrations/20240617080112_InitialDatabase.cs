using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group5_SE1730_BookingManagement.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MaxUser = table.Column<int>(type: "int", nullable: true),
                    CurrentUses = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: false),
                    MiddleName = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Password = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Homestay",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Rating = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    HotelImage = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homestay", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HomstayFeature",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomstayFeature", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Guest_UserId",
                        column: x => x.UserId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Guest_UserId",
                        column: x => x.UserId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Guest_UserId",
                        column: x => x.UserId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    HomestayFeatureID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomType_HomstayFeature",
                        column: x => x.HomestayFeatureID,
                        principalTable: "HomstayFeature",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Guest_UserId",
                        column: x => x.UserId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    MaxGuests = table.Column<int>(type: "int", nullable: true),
                    RoomTypeID = table.Column<long>(type: "bigint", nullable: true),
                    HomestayID = table.Column<long>(type: "bigint", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Room_Homestay",
                        column: x => x.HomestayID,
                        principalTable: "Homestay",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Room_RoomType",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomestayID = table.Column<long>(type: "bigint", nullable: true),
                    GuestID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomID = table.Column<long>(type: "bigint", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CheckOutDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NumAdults = table.Column<int>(type: "int", nullable: true),
                    NumChildren = table.Column<int>(type: "int", nullable: true),
                    SpecialReq = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_Guest",
                        column: x => x.GuestID,
                        principalTable: "Guest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booking_Homestay",
                        column: x => x.HomestayID,
                        principalTable: "Homestay",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Booking_Room",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Rating = table.Column<byte>(type: "tinyint", nullable: true),
                    ReviewText = table.Column<long>(type: "bigint", nullable: true),
                    RoomID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_Guest",
                        column: x => x.GuestID,
                        principalTable: "Guest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_Room",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RoomDiscount",
                columns: table => new
                {
                    RoomID = table.Column<long>(type: "bigint", nullable: false),
                    DiscountID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDiscount", x => new { x.RoomID, x.DiscountID });
                    table.ForeignKey(
                        name: "FK_RoomDiscount_Discount",
                        column: x => x.DiscountID,
                        principalTable: "Discount",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RoomDiscount_Room",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<long>(type: "bigint", nullable: true),
                    GuestID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notify = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    DiscountID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_Booking",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Invoice_Discount",
                        column: x => x.DiscountID,
                        principalTable: "Discount",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_GuestID",
                table: "Booking",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_HomestayID",
                table: "Booking",
                column: "HomestayID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomID",
                table: "Booking",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Guest",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Guest",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BookingID",
                table: "Invoice",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_DiscountID",
                table: "Invoice",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_GuestID",
                table: "Review",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_RoomID",
                table: "Review",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HomestayID",
                table: "Room",
                column: "HomestayID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeID",
                table: "Room",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDiscount_DiscountID",
                table: "RoomDiscount",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_HomestayFeatureID",
                table: "RoomType",
                column: "HomestayFeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "RoomDiscount");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Homestay");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "HomstayFeature");
        }
    }
}
