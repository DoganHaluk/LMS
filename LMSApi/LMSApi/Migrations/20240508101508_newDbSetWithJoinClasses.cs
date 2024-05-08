using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSApi.Migrations
{
    /// <inheritdoc />
    public partial class newDbSetWithJoinClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoachSchoolClass_Coaches_CoachId",
                table: "CoachSchoolClass");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachSchoolClass_SchoolClasses_SchoolClassId",
                table: "CoachSchoolClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCodelab_Codelabs_CodelabId",
                table: "StudentCodelab");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCodelab_Statuses_StatusId",
                table: "StudentCodelab");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCodelab_Students_UserId",
                table: "StudentCodelab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCodelab",
                table: "StudentCodelab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachSchoolClass",
                table: "CoachSchoolClass");

            migrationBuilder.RenameTable(
                name: "StudentCodelab",
                newName: "StudentCodeLabs");

            migrationBuilder.RenameTable(
                name: "CoachSchoolClass",
                newName: "CoachSchoolClasses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCodelab_UserId",
                table: "StudentCodeLabs",
                newName: "IX_StudentCodeLabs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCodelab_StatusId",
                table: "StudentCodeLabs",
                newName: "IX_StudentCodeLabs_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCodelab_CodelabId",
                table: "StudentCodeLabs",
                newName: "IX_StudentCodeLabs_CodelabId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSchoolClass_SchoolClassId",
                table: "CoachSchoolClasses",
                newName: "IX_CoachSchoolClasses_SchoolClassId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSchoolClass_CoachId",
                table: "CoachSchoolClasses",
                newName: "IX_CoachSchoolClasses_CoachId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCodeLabs",
                table: "StudentCodeLabs",
                column: "StudentCodelabId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachSchoolClasses",
                table: "CoachSchoolClasses",
                column: "CoachSchoolClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSchoolClasses_Coaches_CoachId",
                table: "CoachSchoolClasses",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSchoolClasses_SchoolClasses_SchoolClassId",
                table: "CoachSchoolClasses",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "SchoolClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCodeLabs_Codelabs_CodelabId",
                table: "StudentCodeLabs",
                column: "CodelabId",
                principalTable: "Codelabs",
                principalColumn: "CodelabId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCodeLabs_Statuses_StatusId",
                table: "StudentCodeLabs",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCodeLabs_Students_UserId",
                table: "StudentCodeLabs",
                column: "UserId",
                principalTable: "Students",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoachSchoolClasses_Coaches_CoachId",
                table: "CoachSchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachSchoolClasses_SchoolClasses_SchoolClassId",
                table: "CoachSchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCodeLabs_Codelabs_CodelabId",
                table: "StudentCodeLabs");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCodeLabs_Statuses_StatusId",
                table: "StudentCodeLabs");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCodeLabs_Students_UserId",
                table: "StudentCodeLabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCodeLabs",
                table: "StudentCodeLabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoachSchoolClasses",
                table: "CoachSchoolClasses");

            migrationBuilder.RenameTable(
                name: "StudentCodeLabs",
                newName: "StudentCodelab");

            migrationBuilder.RenameTable(
                name: "CoachSchoolClasses",
                newName: "CoachSchoolClass");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCodeLabs_UserId",
                table: "StudentCodelab",
                newName: "IX_StudentCodelab_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCodeLabs_StatusId",
                table: "StudentCodelab",
                newName: "IX_StudentCodelab_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCodeLabs_CodelabId",
                table: "StudentCodelab",
                newName: "IX_StudentCodelab_CodelabId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSchoolClasses_SchoolClassId",
                table: "CoachSchoolClass",
                newName: "IX_CoachSchoolClass_SchoolClassId");

            migrationBuilder.RenameIndex(
                name: "IX_CoachSchoolClasses_CoachId",
                table: "CoachSchoolClass",
                newName: "IX_CoachSchoolClass_CoachId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCodelab",
                table: "StudentCodelab",
                column: "StudentCodelabId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoachSchoolClass",
                table: "CoachSchoolClass",
                column: "CoachSchoolClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSchoolClass_Coaches_CoachId",
                table: "CoachSchoolClass",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachSchoolClass_SchoolClasses_SchoolClassId",
                table: "CoachSchoolClass",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "SchoolClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCodelab_Codelabs_CodelabId",
                table: "StudentCodelab",
                column: "CodelabId",
                principalTable: "Codelabs",
                principalColumn: "CodelabId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCodelab_Statuses_StatusId",
                table: "StudentCodelab",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCodelab_Students_UserId",
                table: "StudentCodelab",
                column: "UserId",
                principalTable: "Students",
                principalColumn: "UserId");
        }
    }
}
