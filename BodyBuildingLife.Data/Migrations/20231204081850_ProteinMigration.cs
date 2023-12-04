using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodyBuildingLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProteinMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProteinId",
                table: "Persons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProteinId",
                table: "Persons");
        }
    }
}
