using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopManage.Migrations
{
    /// <inheritdoc />
    public partial class Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopProvider_Provider_ProviderId",
                table: "ShopProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProvider_Shop_ShopId",
                table: "ShopProvider");

            migrationBuilder.DropIndex(
                name: "IX_ShopProvider_ProviderId",
                table: "ShopProvider");

            migrationBuilder.DropIndex(
                name: "IX_ShopProvider_ShopId",
                table: "ShopProvider");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "ShopProvider");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "ShopProvider");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "ShopProvider",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "ShopProvider",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopProvider_ProviderId",
                table: "ShopProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProvider_ShopId",
                table: "ShopProvider",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProvider_Provider_ProviderId",
                table: "ShopProvider",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProvider_Shop_ShopId",
                table: "ShopProvider",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id");
        }
    }
}
