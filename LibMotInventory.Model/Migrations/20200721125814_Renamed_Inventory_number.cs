using Microsoft.EntityFrameworkCore.Migrations;

namespace LibMotInventory.Model.Migrations
{
    public partial class Renamed_Inventory_number : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventroyNumber",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfItem",
                table: "Inventories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventoryNumber",
                table: "Inventories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryNumber",
                table: "Inventories");

            migrationBuilder.AlterColumn<string>(
                name: "NumberOfItem",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "InventroyNumber",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
