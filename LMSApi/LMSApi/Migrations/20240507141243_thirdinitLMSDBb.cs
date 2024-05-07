using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSApi.Migrations
{
    /// <inheritdoc />
    public partial class thirdinitLMSDBb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Coaches_CoachId",
                table: "SchoolClasses");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClasses_CoachId",
                table: "SchoolClasses");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "SchoolClasses");

            migrationBuilder.CreateTable(
                name: "CoachSchoolClass",
                columns: table => new
                {
                    CoachSchoolClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    SchoolClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachSchoolClass", x => x.CoachSchoolClassId);
                    table.ForeignKey(
                        name: "FK_CoachSchoolClass_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachSchoolClass_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "SchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachSchoolClass_CoachId",
                table: "CoachSchoolClass",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachSchoolClass_SchoolClassId",
                table: "CoachSchoolClass",
                column: "SchoolClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachSchoolClass");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "SchoolClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_CoachId",
                table: "SchoolClasses",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Coaches_CoachId",
                table: "SchoolClasses",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
