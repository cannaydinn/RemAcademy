using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemAcademy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalAmountToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 6, 18, 4, 32, 863, DateTimeKind.Local).AddTicks(3201));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TeacherId",
                table: "Orders",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_TeacherId",
                table: "Orders",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_TeacherId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TeacherId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 6, 15, 0, 27, 835, DateTimeKind.Local).AddTicks(3009));
        }
    }
}
