using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace beerpongapi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pool",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    TournamentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pool", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pool_Tournament_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BeerAgainst = table.Column<int>(nullable: false),
                    BeerFor = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    PoolID = table.Column<int>(nullable: true),
                    TournamentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Team_Pool_PoolID",
                        column: x => x.PoolID,
                        principalTable: "Pool",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Tournament_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BeerFor1 = table.Column<int>(nullable: false),
                    BeerFor2 = table.Column<int>(nullable: false),
                    PoolID = table.Column<int>(nullable: true),
                    Team1ID = table.Column<int>(nullable: true),
                    Team2ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Match_Pool_PoolID",
                        column: x => x.PoolID,
                        principalTable: "Pool",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_Team1ID",
                        column: x => x.Team1ID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_Team2ID",
                        column: x => x.Team2ID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_PoolID",
                table: "Match",
                column: "PoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Team1ID",
                table: "Match",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Team2ID",
                table: "Match",
                column: "Team2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pool_TournamentID",
                table: "Pool",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_PoolID",
                table: "Team",
                column: "PoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TournamentID",
                table: "Team",
                column: "TournamentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Pool");

            migrationBuilder.DropTable(
                name: "Tournament");
        }
    }
}
