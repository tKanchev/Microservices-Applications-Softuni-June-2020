using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoices.Logger.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Arguments = table.Column<string>(nullable: true),
                    ExceptionMessage = table.Column<string>(nullable: true),
                    ExceptionType = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
