using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenDataBase.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Primary Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remain_SignedIn = table.Column<bool>(type: "bit", nullable: false),
                    roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Primary Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Primary Users",
                columns: new[] { "Id", "Email", "First_Name", "Last_Name", "PasswordHash", "Remain_SignedIn", "roles" },
                values: new object[] { new Guid("f65dee5c-a3bb-4b8e-a12c-78b6e3e7e517"), "ben10@gmail.com", "Ben", "Tennyson", "Paashw", true, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Primary Users");
        }
    }
}
