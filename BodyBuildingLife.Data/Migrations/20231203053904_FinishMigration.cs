using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodyBuildingLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinishMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonProtains");

            migrationBuilder.DropTable(
                name: "Protains");

            migrationBuilder.AddColumn<long>(
                name: "TrainerId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PersonId",
                table: "Cards",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Proteins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volume = table.Column<long>(type: "bigint", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProteinStandardsId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAtt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAtt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proteins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proteins_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonProteins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProteinId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAtt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAtt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProteins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonProteins_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProteins_Proteins_ProteinId",
                        column: x => x.ProteinId,
                        principalTable: "Proteins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProteinStandards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumptionTimes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumptionVolume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<long>(type: "bigint", nullable: true),
                    ProteinId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAtt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAtt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinStandards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProteinStandards_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProteinStandards_Proteins_ProteinId",
                        column: x => x.ProteinId,
                        principalTable: "Proteins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TrainerId",
                table: "Persons",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PersonId",
                table: "Cards",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProteins_PersonId",
                table: "PersonProteins",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProteins_ProteinId",
                table: "PersonProteins",
                column: "ProteinId");

            migrationBuilder.CreateIndex(
                name: "IX_Proteins_PersonId",
                table: "Proteins",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteinStandards_PersonId",
                table: "ProteinStandards",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteinStandards_ProteinId",
                table: "ProteinStandards",
                column: "ProteinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Persons_PersonId",
                table: "Cards",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Trainers_TrainerId",
                table: "Persons",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Persons_PersonId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Trainers_TrainerId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "PersonProteins");

            migrationBuilder.DropTable(
                name: "ProteinStandards");

            migrationBuilder.DropTable(
                name: "Proteins");

            migrationBuilder.DropIndex(
                name: "IX_Persons_TrainerId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PersonId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "Protains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAtt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAtt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidityPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volume = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonProtains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    ProtainId = table.Column<long>(type: "bigint", nullable: false),
                    CreateAtt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdateAtt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProtains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonProtains_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProtains_Protains_ProtainId",
                        column: x => x.ProtainId,
                        principalTable: "Protains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonProtains_PersonId",
                table: "PersonProtains",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProtains_ProtainId",
                table: "PersonProtains",
                column: "ProtainId");
        }
    }
}
