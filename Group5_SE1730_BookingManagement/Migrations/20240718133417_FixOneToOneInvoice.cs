using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group5_SE1730_BookingManagement.Migrations
{
    public partial class FixOneToOneInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_BookingID",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BookingID",
                table: "Invoice",
                column: "BookingID",
                unique: true,
                filter: "[BookingID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_BookingID",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BookingID",
                table: "Invoice",
                column: "BookingID");
        }
    }
}
