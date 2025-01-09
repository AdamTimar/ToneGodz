using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToneGodz.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionToPaymentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Payments",
                type: "nvarchar(max)", // Changed from longtext to nvarchar(max)
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Payments");
        }
    }
}
