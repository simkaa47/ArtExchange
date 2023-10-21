using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtExchange.Api.Migrations
{
    /// <inheritdoc />
    public partial class Add_Login_and_Password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Persons");
        }
    }
}
