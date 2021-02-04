using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfChallenge.Data.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Neighborhood = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    City = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    State = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Country = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    ZipCode = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
