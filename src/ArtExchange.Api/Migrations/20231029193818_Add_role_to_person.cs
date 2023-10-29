using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtExchange.Api.Migrations
{
    /// <inheritdoc />
    public partial class Add_role_to_person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Persons");
        }
    }
}
