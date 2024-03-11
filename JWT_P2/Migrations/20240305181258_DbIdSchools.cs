using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWT_P2.Migrations
{
    /// <inheritdoc />
    public partial class DbIdSchools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Schools",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Schools",
                newName: "Guid");
        }
    }
}
