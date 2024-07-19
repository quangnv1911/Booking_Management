using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group5_SE1730_BookingManagement.Migrations
{
    public partial class UpdateImgName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelImage",
                table: "Homestay");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Homestay",
                type: "nchar(255)",
                fixedLength: true,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img1",
                table: "Homestay",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img1",
                table: "Homestay");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Homestay",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(255)",
                oldFixedLength: true,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HotelImage",
                table: "Homestay",
                type: "nchar(255)",
                fixedLength: true,
                maxLength: 255,
                nullable: true);
        }
    }
}
