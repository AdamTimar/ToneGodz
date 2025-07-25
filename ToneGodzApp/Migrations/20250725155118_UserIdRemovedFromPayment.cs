using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToneGodz.Migrations
{
    /// <inheritdoc />
    public partial class UserIdRemovedFromPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Payments",
                newName: "UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                newName: "IX_Payments_UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserEntityId",
                table: "Payments",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserEntityId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "Payments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserEntityId",
                table: "Payments",
                newName: "IX_Payments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
