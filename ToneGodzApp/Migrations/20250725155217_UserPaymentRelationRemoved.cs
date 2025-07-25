using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToneGodz.Migrations
{
    /// <inheritdoc />
    public partial class UserPaymentRelationRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserEntityId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserEntityId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Payments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Payments",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserEntityId",
                table: "Payments",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserEntityId",
                table: "Payments",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
