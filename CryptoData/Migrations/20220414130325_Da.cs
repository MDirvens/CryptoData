using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoData.Migrations
{
    public partial class Da : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoData",
                columns: table => new
                {
                    OrderBookUpdateId = table.Column<long>(type: "bigint", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestBidPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BestBidQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BestAskPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BestAskQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoData", x => x.OrderBookUpdateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoData");
        }
    }
}
