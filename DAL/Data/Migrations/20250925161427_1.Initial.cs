using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Apple iPhone 15", 999m },
                    { 2, "Samsung Galaxy S23", 899m },
                    { 3, "Sony WH-1000XM5 Headphones", 349m },
                    { 4, "Apple MacBook Pro 14", 1999m },
                    { 5, "Dell XPS 13 Laptop", 1299m },
                    { 6, "Logitech MX Master 3 Mouse", 99m },
                    { 7, "Apple iPad Air", 599m },
                    { 8, "Amazon Kindle Paperwhite", 139m },
                    { 9, "Google Pixel 8", 799m },
                    { 10, "Bose SoundLink Speaker", 129m },
                    { 11, "Nintendo Switch", 299m },
                    { 12, "PlayStation 5", 499m },
                    { 13, "Xbox Series X", 499m },
                    { 14, "Fitbit Charge 6", 149m },
                    { 15, "GoPro HERO12", 399m },
                    { 16, "Canon EOS R10 Camera", 979m },
                    { 17, "Apple Watch Series 9", 399m },
                    { 18, "Samsung Galaxy Watch 6", 329m },
                    { 19, "JBL Flip 6 Bluetooth Speaker", 119m },
                    { 20, "Anker PowerCore 20000mAh", 49m },
                    { 21, "Razer BlackWidow V4 Keyboard", 179m },
                    { 22, "HP Envy 6055e Printer", 129m },
                    { 23, "Apple AirPods Pro (2nd Gen)", 249m },
                    { 24, "Samsung T7 Portable SSD 1TB", 109m },
                    { 25, "Philips Hue Smart Bulb", 49m },
                    { 26, "Instant Pot Duo 7-in-1", 89m },
                    { 27, "Dyson V11 Vacuum Cleaner", 599m },
                    { 28, "KitchenAid Stand Mixer", 429m },
                    { 29, "Sony PlayStation DualSense Controller", 69m },
                    { 30, "Google Nest Thermostat", 129m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
