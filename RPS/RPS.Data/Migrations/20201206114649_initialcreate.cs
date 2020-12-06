using Microsoft.EntityFrameworkCore.Migrations;

namespace RPS.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerScore = table.Column<int>(type: "int", nullable: false),
                    ComputerScore = table.Column<int>(type: "int", nullable: false),
                    PointsToWin = table.Column<int>(type: "int", nullable: false),
                    MostUsedItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MostUsedAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
