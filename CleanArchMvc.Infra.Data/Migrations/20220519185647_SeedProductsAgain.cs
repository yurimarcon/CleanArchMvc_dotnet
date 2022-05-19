using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProductsAgain : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES ('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50.00, 'caderno1.jpg', 1)"
            );
            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES ('Estojo escolar', 'Estojo escolar conza', 5.65, 70.00, 'estojo1.jpg', 1)"
            );
            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES ('Borracha escolar', 'Borracha branca pequena', 3.25, 80.00, 'borrracha1.jpg', 1)"
            );
            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES ('Calculadora escolar', 'Calculadora simples', 15.39, 20.00, 'calculadora1.jpg', 2)"
            );
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
