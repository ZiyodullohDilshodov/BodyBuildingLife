using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodyBuildingLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasportSerialNumber",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasportSerialNumber",
                table: "Trainers");
        }
    }
}
