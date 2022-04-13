using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoData.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderBookUpdateId = table.Column<long>(type: "bigint", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestBidPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BestBidQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BestAskPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BestAskQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoData");
        }
    }
}
