using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopManage.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdShop = table.Column<int>(type: "int", nullable: false),
                    IdProvider = table.Column<int>(type: "int", nullable: false),
                    FriendlyPoint = table.Column<double>(type: "float", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopProvider_Provider_IdProvider",
                        column: x => x.IdProvider,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopProvider_Shop_IdShop",
                        column: x => x.IdShop,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProvider_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provider_Name",
                table: "Provider",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Name",
                table: "Shop",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopProvider_IdProvider",
                table: "ShopProvider",
                column: "IdProvider");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProvider_IdShop",
                table: "ShopProvider",
                column: "IdShop");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProvider_ProviderId",
                table: "ShopProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProvider_ShopId",
                table: "ShopProvider",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopProvider");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Shop");
        }
    }
}
