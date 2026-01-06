using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class FixTableToDo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SevetiryId",
                table: "ToDos",
                newName: "SeveriryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeveriryId",
                table: "ToDos",
                newName: "SevetiryId");
        }
    }
}
