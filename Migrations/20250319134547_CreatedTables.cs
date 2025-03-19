using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Login = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    Done = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    CreatedOn = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    UserId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskItems_UserAccounts_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Unique_UserAccount_Email",
                table: "UserAccounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_UserAccount_Login",
                table: "UserAccounts",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_UserAccount_PhoneNumber",
                table: "UserAccounts",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
