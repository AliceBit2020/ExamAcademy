using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamAcademy.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facultys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultys", x => x.Id);
                    table.UniqueConstraint("AK_Facultys_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building = table.Column<int>(type: "int", nullable: false),
                    Financing = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.UniqueConstraint("AK_Departments_Name", x => x.Name);
                    table.CheckConstraint("CK_Building", "Building>1 and Building<5");
                    table.CheckConstraint("CK_Financing", "Financing >=0");
                    table.ForeignKey(
                        name: "FK_Departments_Facultys_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Facultys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Facultys");
        }
    }
}
