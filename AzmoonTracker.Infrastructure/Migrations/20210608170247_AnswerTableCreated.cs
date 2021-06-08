using Microsoft.EntityFrameworkCore.Migrations;

namespace AzmoonTracker.Infrastructure.Migrations
{
    public partial class AnswerTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersParticipateInExams",
                columns: table => new
                {
                    ExamParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamFK = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersParticipateInExams", x => x.ExamParticipantId);
                    table.UniqueConstraint("AK_UsersParticipateInExams_ExamFK_ParticipantFK", x => new { x.ExamFK, x.ParticipantFK });
                    table.ForeignKey(
                        name: "FK_UsersParticipateInExams_AspNetUsers_ParticipantFK",
                        column: x => x.ParticipantFK,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersParticipateInExams_Exams_ExamFK",
                        column: x => x.ExamFK,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    ExamParticipantId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => new { x.ExamId, x.QuestionId, x.ExamParticipantId });
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId_ExamId",
                        columns: x => new { x.QuestionId, x.ExamId },
                        principalTable: "Questions",
                        principalColumns: new[] { "QuestionNum", "ExamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_UsersParticipateInExams_ExamParticipantId",
                        column: x => x.ExamParticipantId,
                        principalTable: "UsersParticipateInExams",
                        principalColumn: "ExamParticipantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ExamParticipantId",
                table: "Answers",
                column: "ExamParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId_ExamId",
                table: "Answers",
                columns: new[] { "QuestionId", "ExamId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersParticipateInExams_ParticipantFK",
                table: "UsersParticipateInExams",
                column: "ParticipantFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "UsersParticipateInExams");
        }
    }
}
