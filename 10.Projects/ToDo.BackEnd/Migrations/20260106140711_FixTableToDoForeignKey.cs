using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class FixTableToDoForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Severities_SeverityId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "SeveriryId",
                table: "ToDos");

            migrationBuilder.AlterColumn<int>(
                name: "SeverityId",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Severities_SeverityId",
                table: "ToDos",
                column: "SeverityId",
                principalTable: "Severities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Severities_SeverityId",
                table: "ToDos");

            migrationBuilder.AlterColumn<int>(
                name: "SeverityId",
                table: "ToDos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SeveriryId",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Severities_SeverityId",
                table: "ToDos",
                column: "SeverityId",
                principalTable: "Severities",
                principalColumn: "Id");
        }
    }
}
