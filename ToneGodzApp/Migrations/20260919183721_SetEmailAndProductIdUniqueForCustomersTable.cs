using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToneGodz.Migrations
{
    /// <inheritdoc />
    public partial class SetEmailAndProductIdUniqueForCustomersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Email",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email_ProductId",
                table: "Customers",
                columns: new[] { "Email", "ProductId" },
                unique: true,
                filter: "[ProductId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Email_ProductId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);
        }
    }
}
