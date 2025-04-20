using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceProductSorting.Migrations
{
    /// <inheritdoc />
    public partial class final1Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 829m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "MacBook Air1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Dell XPSf");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 5, "Apple", "Phones", "iPhone 15", 989m, 4.5 },
                    { 6, "Samsung", "Phones", "Galaxy S24", 859m, 4.2999999999999998 },
                    { 7, "Apple", "Laptops", "MacBook Air2", 1599m, 4.7999999999999998 },
                    { 8, "Dell", "Laptops", "Dell XPSd", 1099m, 4.5999999999999996 },
                    { 9, "Apple", "Phones", "iPhone 16", 979m, 4.5 },
                    { 10, "Samsung", "Phones", "Galaxy S25", 809m, 4.2999999999999998 },
                    { 11, "Apple", "Laptops", "MacBook Air3", 1499m, 4.7999999999999998 },
                    { 12, "Dell", "Laptops", "Dell XPSw", 1099m, 4.5999999999999996 },
                    { 13, "Apple", "Phones", "iPhone 17", 969m, 4.5 },
                    { 14, "Samsung", "Phones", "Galaxy S28", 819m, 4.2999999999999998 },
                    { 15, "Apple", "Laptops", "MacBook Air4", 1399m, 4.7999999999999998 },
                    { 16, "Dell", "Laptops", "Dell XPSe", 1099m, 4.5999999999999996 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 899m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "MacBook Air");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Dell XPS");
        }
    }
}
