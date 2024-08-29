using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "J. R. R. Tolkien", "The Lord of the Rings is an epic high-fantasy novel written by English author and scholar J. R. R. Tolkien.", "978-0-395-19395-7", 19.989999999999998, 14.99, 12.99, 13.99, "The Lord of the Rings" },
                    { 2, "J. K. Rowling", "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling.", "978-0-7475-3269-6", 14.99, 9.9900000000000002, 7.9900000000000002, 8.9900000000000002, "Harry Potter and the Philosopher's Stone" },
                    { 3, "Dan Brown", "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown.", "978-0-385-50420-5", 12.99, 7.9900000000000002, 5.9900000000000002, 6.9900000000000002, "The Da Vinci Code" },
                    { 4, "Stephen King", "The Shining is a horror novel by American author Stephen King.", "978-0-385-12167-5", 9.9900000000000002, 4.9900000000000002, 2.9900000000000002, 3.9900000000000002, "The Shining" },
                    { 5, "Nicholas Sparks", "The Notebook is a 1996 romantic novel by American novelist Nicholas Sparks.", "978-0-446-52080-5", 7.9900000000000002, 2.9900000000000002, 0.98999999999999999, 1.99, "The Notebook" },
                    { 6, "Suzanne Collins", "The Hunger Games is a 2008 dystopian novel by the American writer Suzanne Collins.", "978-0-439-02348-1", 11.99, 6.9900000000000002, 4.9900000000000002, 5.9900000000000002, "The Hunger Games" },
                    { 7, "George R. R. Martin", "Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by the American author George R. R. Martin.", "978-0-553-57340-4", 15.99, 10.99, 8.9900000000000002, 9.9900000000000002, "Game of Thrones" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
