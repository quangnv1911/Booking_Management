using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group5_SE1730_BookingManagement.Migrations
{
    public partial class UpdateForeginKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuestID",
                table: "Homestay",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homestay_GuestID",
                table: "Homestay",
                column: "GuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStay_Guest",
                table: "Homestay",
                column: "GuestID",
                principalTable: "Guest",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeStay_Guest",
                table: "Homestay");

            migrationBuilder.DropIndex(
                name: "IX_Homestay_GuestID",
                table: "Homestay");

            migrationBuilder.DropColumn(
                name: "GuestID",
                table: "Homestay");
        }
    }
}
