using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodyBuildingLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainerIdMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Trainers_TrainerId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonTrainers_Trainers_TrainerId",
                table: "PersonTrainers");

            migrationBuilder.DropIndex(
                name: "IX_Persons_TrainerId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TraionerId",
                table: "PersonTrainers");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "PersonTrainers",
                newName: "TrainerID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonTrainers_TrainerId",
                table: "PersonTrainers",
                newName: "IX_PersonTrainers_TrainerID");

            migrationBuilder.AlterColumn<long>(
                name: "TrainerID",
                table: "PersonTrainers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTrainers_Trainers_TrainerID",
                table: "PersonTrainers",
                column: "TrainerID",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonTrainers_Trainers_TrainerID",
                table: "PersonTrainers");

            migrationBuilder.RenameColumn(
                name: "TrainerID",
                table: "PersonTrainers",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonTrainers_TrainerID",
                table: "PersonTrainers",
                newName: "IX_PersonTrainers_TrainerId");

            migrationBuilder.AlterColumn<long>(
                name: "TrainerId",
                table: "PersonTrainers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "TraionerId",
                table: "PersonTrainers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TrainerId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TrainerId",
                table: "Persons",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Trainers_TrainerId",
                table: "Persons",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonTrainers_Trainers_TrainerId",
                table: "PersonTrainers",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }
    }
}
