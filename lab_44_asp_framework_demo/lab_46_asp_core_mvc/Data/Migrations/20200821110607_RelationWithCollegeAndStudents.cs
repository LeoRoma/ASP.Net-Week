using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_46_asp_core_mvc.Data.Migrations
{
    public partial class RelationWithCollegeAndStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CollegeId",
                table: "Student",
                column: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_College_CollegeId",
                table: "Student",
                column: "CollegeId",
                principalTable: "College",
                principalColumn: "CollegeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_College_CollegeId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CollegeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "Student");
        }
    }
}
