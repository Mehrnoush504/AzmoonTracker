using Microsoft.EntityFrameworkCore.Migrations;

namespace AzmoonTracker.Infrastructure.Migrations
{
    public partial class ExamSearchIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExamSearchId",
                table: "Exams",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExamSearchId",
                table: "Exams",
                column: "ExamSearchId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exams_ExamSearchId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamSearchId",
                table: "Exams");
        }
    }
}
