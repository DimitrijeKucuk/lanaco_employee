using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForPossiblePosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeJobPosition",
                columns: table => new
                {
                    PossibleEmployeePositionId = table.Column<int>(type: "int", nullable: false),
                    PossibleEmployeePositionId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJobPosition", x => new { x.PossibleEmployeePositionId, x.PossibleEmployeePositionId1 });
                    table.ForeignKey(
                        name: "FK_EmployeeJobPosition_Employee_PossibleEmployeePositionId",
                        column: x => x.PossibleEmployeePositionId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJobPosition_JobPosition_PossibleEmployeePositionId1",
                        column: x => x.PossibleEmployeePositionId1,
                        principalTable: "JobPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobPosition_PossibleEmployeePositionId1",
                table: "EmployeeJobPosition",
                column: "PossibleEmployeePositionId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeJobPosition");
        }
    }
}
