using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace beerpongapi.Migrations
{
    public partial class AddRound1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundID",
                table: "Match",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TournamentID = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_RoundID",
                table: "Match",
                column: "RoundID");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Round_RoundID",
                table: "Match",
                column: "RoundID",
                principalTable: "Round",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Round_RoundID",
                table: "Match");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropIndex(
                name: "IX_Match_RoundID",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "RoundID",
                table: "Match");
        }
    }
}
