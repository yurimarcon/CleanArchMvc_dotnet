using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProduct2 : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.AlterColumn<decimal>(
                name: "Stock",
                table: "Products",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Stock",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
