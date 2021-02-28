using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EAN = table.Column<string>(type: "char(13)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(120)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
