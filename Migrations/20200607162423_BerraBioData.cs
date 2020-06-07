using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab1ASP.NetCore.Migrations
{
    public partial class BerraBioData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    SeatsLeft = table.Column<int>(nullable: false),
                    Showtime = table.Column<string>(nullable: true),
                    Productionyear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    AmmountTickets = table.Column<int>(nullable: false),
                    MovieTitle = table.Column<string>(nullable: true),
                    MovieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Genre", "Productionyear", "SeatsLeft", "Showtime", "Title" },
                values: new object[,]
                {
                    { 1, "Action", "2017", 50, "Juni 14-2020 17:30 PM", "Black Panther" },
                    { 2, "Action", "2017", 50, "Juni 14-2020 15:00 PM", "Wonder Woman" },
                    { 3, "Action", "2019", 50, "Juni 16-2020 17:00 PM", "Avengers:Endgame " },
                    { 4, "Drama", "2019", 50, "Juni 16-2020 20:00 PM", "The Irishman" },
                    { 5, "Drama", "2018", 50, "Juni 17-2020 15:00 PM", "Lady Bird" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MovieID",
                table: "Orders",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
