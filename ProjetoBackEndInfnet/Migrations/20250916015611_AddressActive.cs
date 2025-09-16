using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBackEndInfnet.Migrations
{
    /// <inheritdoc />
    public partial class AddressActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Addresses");
        }
    }
}
