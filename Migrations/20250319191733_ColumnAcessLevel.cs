using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAcessLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcessLevel",
                table: "UserAccounts",
                type: "INT",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TaskItems",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcessLevel",
                table: "UserAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TaskItems",
                type: "NVARCHAR(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)");
        }
    }
}
