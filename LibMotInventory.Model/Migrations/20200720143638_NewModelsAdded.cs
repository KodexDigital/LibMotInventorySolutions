using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibMotInventory.Model.Migrations
{
    public partial class NewModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    InventoryNumber = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    NumberOfItem = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    InventroyNumber = table.Column<string>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    EstimatedValue = table.Column<double>(nullable: false),
                    VendorLesser = table.Column<string>(nullable: true),
                    DateAquired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    TotalInSotck = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
