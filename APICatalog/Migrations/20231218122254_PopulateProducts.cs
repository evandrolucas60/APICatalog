using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    /// <inheritdoc />
    public partial class PopulateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, RegisterDate, CategoryId) " +
                "Values('Coca-Cola Diet', 'Refrigerante de Cola 350 ml', 5.45, 'cocacola.jpg', 50, GETDATE(), 1)");

            mb.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, RegisterDate, CategoryId) " +
                "Values('Lanche de Atum', 'Lanche de Atum com maionese', 8.50, 'atum.jpg', 10, GETDATE(), 2)");

            mb.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, RegisterDate, CategoryId) " +
                "Values('Pudim 100 g', 'Pudim de leite condensado 100g', 6.75, 'pudim.jpg', 20, GETDATE(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Products");
        }
    }
}
