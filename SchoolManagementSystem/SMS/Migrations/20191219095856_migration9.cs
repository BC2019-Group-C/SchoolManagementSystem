using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.DataSource.Migrations
{
    public partial class migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherLogins_Teachers_TeacherId",
                table: "TeacherLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherLogins",
                table: "TeacherLogins");

            migrationBuilder.RenameTable(
                name: "TeacherLogins",
                newName: "TeacherLogin");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherLogins_TeacherId",
                table: "TeacherLogin",
                newName: "IX_TeacherLogin_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherLogin",
                table: "TeacherLogin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherLogin_Teachers_TeacherId",
                table: "TeacherLogin",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherLogin_Teachers_TeacherId",
                table: "TeacherLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherLogin",
                table: "TeacherLogin");

            migrationBuilder.RenameTable(
                name: "TeacherLogin",
                newName: "TeacherLogins");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherLogin_TeacherId",
                table: "TeacherLogins",
                newName: "IX_TeacherLogins_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherLogins",
                table: "TeacherLogins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherLogins_Teachers_TeacherId",
                table: "TeacherLogins",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
