using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSApi.Migrations
{
    /// <inheritdoc />
    public partial class FourthLMSDbCreateSchoolClassCoursesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_SchoolClasses_SchoolClassId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Statuses_StatusId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SchoolClassId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StatusId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SchoolClassId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "SchoolClassCourses",
                columns: table => new
                {
                    SchoolClassCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    SchoolClassId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClassCourses", x => x.SchoolClassCourseId);
                    table.ForeignKey(
                        name: "FK_SchoolClassCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClassCourses_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "SchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClassCourses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassCourses_CourseId",
                table: "SchoolClassCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassCourses_SchoolClassId",
                table: "SchoolClassCourses",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassCourses_StatusId",
                table: "SchoolClassCourses",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolClassCourses");

            migrationBuilder.AddColumn<int>(
                name: "SchoolClassId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SchoolClassId",
                table: "Courses",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StatusId",
                table: "Courses",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_SchoolClasses_SchoolClassId",
                table: "Courses",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "SchoolClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Statuses_StatusId",
                table: "Courses",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
