using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtExchange.Modules.ArtMeetings.API.Data.Migrations;

/// <inheritdoc />
public partial class Create_Database : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "meetings");

        migrationBuilder.CreateTable(
            name: "Meetings",
            schema: "meetings",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Description = table.Column<string>(type: "text", nullable: false),
                Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                Location = table.Column<string>(type: "text", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: false),
                Type = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Meetings", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Meetings",
            schema: "meetings");
    }
}
