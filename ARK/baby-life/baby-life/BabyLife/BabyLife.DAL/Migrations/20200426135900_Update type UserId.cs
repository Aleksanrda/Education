using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyLife.DAL.Migrations
{
    public partial class UpdatetypeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Babies_AspNetUsers_UserId1",
                table: "Babies");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_AspNetUsers_UserId1",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_UserId1",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Babies_UserId1",
                table: "Babies");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Babies");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reminders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Babies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_UserId",
                table: "Reminders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Babies_UserId",
                table: "Babies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Babies_AspNetUsers_UserId",
                table: "Babies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_AspNetUsers_UserId",
                table: "Reminders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Babies_AspNetUsers_UserId",
                table: "Babies");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_AspNetUsers_UserId",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_UserId",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Babies_UserId",
                table: "Babies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reminders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Reminders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Babies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Babies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_UserId1",
                table: "Reminders",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Babies_UserId1",
                table: "Babies",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Babies_AspNetUsers_UserId1",
                table: "Babies",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_AspNetUsers_UserId1",
                table: "Reminders",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
