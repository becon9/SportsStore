using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.DAL.Migrations
{
    public partial class IEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Orders_OrderId",
                table: "CartLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Products_ProductId",
                table: "CartLine");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Image_ImageId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartLine",
                table: "CartLine");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "CartLineId",
                table: "CartLine");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Products",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Orders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Image",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CartLine",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartLine",
                table: "CartLine",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Watersports", "A boat for one person", null, "Kayak", 275m },
                    { 2, "Watersports", "Protective and fashionable", null, "Lifejacket", 48.95m },
                    { 3, "Soccer", "FIFA-approved size and weight", null, "Soccer Ball", 19.50m },
                    { 4, "Soccer", "Give your playing field a professional touch", null, "Corner Flags", 39.95m },
                    { 5, "Soccer", "Flat-packed 35,000-seat stadium", null, "Stadium", 79500m },
                    { 6, "Chess", "Improve brain efficiency by 75%", null, "Thinking Cap", 16m },
                    { 7, "Chess", "Secretly give your opponent a disadvantage", null, "Unsteady Chair", 29.95m },
                    { 8, "Chess", "A fun game for family", null, "Human Chess Board", 75m },
                    { 9, "Chess", "Gold-plated, diamong-studded King", null, "Bling-Bling King", 1200m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Orders_OrderId",
                table: "CartLine",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Products_ProductId",
                table: "CartLine",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Image_ImageId",
                table: "Products",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Orders_OrderId",
                table: "CartLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Products_ProductId",
                table: "CartLine");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Image_ImageId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartLine",
                table: "CartLine");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartLine");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CartLineId",
                table: "CartLine",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartLine",
                table: "CartLine",
                column: "CartLineId");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "ImageId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Watersports", "A boat for one person", null, "Kayak", 275m },
                    { 2, "Watersports", "Protective and fashionable", null, "Lifejacket", 48.95m },
                    { 3, "Soccer", "FIFA-approved size and weight", null, "Soccer Ball", 19.50m },
                    { 4, "Soccer", "Give your playing field a professional touch", null, "Corner Flags", 39.95m },
                    { 5, "Soccer", "Flat-packed 35,000-seat stadium", null, "Stadium", 79500m },
                    { 6, "Chess", "Improve brain efficiency by 75%", null, "Thinking Cap", 16m },
                    { 7, "Chess", "Secretly give your opponent a disadvantage", null, "Unsteady Chair", 29.95m },
                    { 8, "Chess", "A fun game for family", null, "Human Chess Board", 75m },
                    { 9, "Chess", "Gold-plated, diamong-studded King", null, "Bling-Bling King", 1200m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Orders_OrderId",
                table: "CartLine",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Products_ProductId",
                table: "CartLine",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Image_ImageId",
                table: "Products",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
