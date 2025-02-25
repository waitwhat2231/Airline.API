using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airline.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRelationshipName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Airlines",
                newName: "ManagerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManagerID",
                table: "Airlines",
                newName: "AdminId");
        }
    }
}
