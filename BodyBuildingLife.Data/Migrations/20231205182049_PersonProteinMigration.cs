using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodyBuildingLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonProteinMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proteins_Persons_PersonId",
                table: "Proteins");

            migrationBuilder.DropIndex(
                name: "IX_Proteins_PersonId",
                table: "Proteins");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Proteins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PersonId",
                table: "Proteins",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proteins_PersonId",
                table: "Proteins",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proteins_Persons_PersonId",
                table: "Proteins",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
