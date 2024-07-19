using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group5_SE1730_BookingManagement.Migrations
{
    public partial class UpdateImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Message__InboxId__3E52440B",
                table: "Message");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Room",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InboxId",
                table: "Message",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Message",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Message",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Homestay",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Message__InboxId__3E52440B",
                table: "Message",
                column: "InboxId",
                principalTable: "Inbox",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Message__InboxId__3E52440B",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Homestay");

            migrationBuilder.AlterColumn<long>(
                name: "InboxId",
                table: "Message",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Message",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Message",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Message__InboxId__3E52440B",
                table: "Message",
                column: "InboxId",
                principalTable: "Inbox",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
