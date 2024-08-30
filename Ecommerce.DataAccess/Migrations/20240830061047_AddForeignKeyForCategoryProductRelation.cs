using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForCategoryProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Adventure" },
                    { 3, 3, "Comedy" },
                    { 4, 4, "Drama" },
                    { 5, 5, "Fantasy" },
                    { 6, 6, "Horror" },
                    { 7, 7, "Mystery" },
                    { 8, 8, "Romance" },
                    { 9, 9, "Sci-Fi" },
                    { 10, 10, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "J. R. R. Tolkien", 5, "The Lord of the Rings is an epic high-fantasy novel written by English author and scholar J. R. R. Tolkien.", "978-0-395-19395-7", 19.989999999999998, 14.99, 12.99, 13.99, "The Lord of the Rings" },
                    { 2, "J. K. Rowling", 5, "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling.", "978-0-7475-3269-6", 14.99, 9.9900000000000002, 7.9900000000000002, 8.9900000000000002, "Harry Potter and the Philosopher's Stone" },
                    { 3, "Dan Brown", 7, "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown.", "978-0-385-50420-5", 12.99, 7.9900000000000002, 5.9900000000000002, 6.9900000000000002, "The Da Vinci Code" },
                    { 4, "Stephen King", 7, "The Shining is a horror novel by American author Stephen King.", "978-0-385-12167-5", 9.9900000000000002, 4.9900000000000002, 2.9900000000000002, 3.9900000000000002, "The Shining" },
                    { 5, "Nicholas Sparks", 8, "The Notebook is a 1996 romantic novel by American novelist Nicholas Sparks.", "978-0-446-52080-5", 7.9900000000000002, 2.9900000000000002, 0.98999999999999999, 1.99, "The Notebook" },
                    { 6, "Suzanne Collins", 1, "The Hunger Games is a 2008 dystopian novel by the American writer Suzanne Collins.", "978-0-439-02348-1", 11.99, 6.9900000000000002, 4.9900000000000002, 5.9900000000000002, "The Hunger Games" },
                    { 7, "George R. R. Martin", 5, "Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by the American author George R. R. Martin.", "978-0-553-57340-4", 15.99, 10.99, 8.9900000000000002, 9.9900000000000002, "Game of Thrones" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
