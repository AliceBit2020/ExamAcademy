using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamAcademy.Migrations
{
    /// <inheritdoc />
    public partial class Curator_Group : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Building",
                table: "Departments");

            migrationBuilder.CreateTable(
                name: "Curators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "N"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "S")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", nullable: false, defaultValue: "G"),
                    Cours = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.UniqueConstraint("AK_Groups_Name", x => x.Name);
                    table.CheckConstraint("CK_Cours", "Cours>=1 and Cours<=5");
                    table.ForeignKey(
                        name: "FK_Groups_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuratorGroup",
                columns: table => new
                {
                    CuratorListId = table.Column<int>(type: "int", nullable: false),
                    GroupsListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuratorGroup", x => new { x.CuratorListId, x.GroupsListId });
                    table.ForeignKey(
                        name: "FK_CuratorGroup_Curators_CuratorListId",
                        column: x => x.CuratorListId,
                        principalTable: "Curators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuratorGroup_Groups_GroupsListId",
                        column: x => x.GroupsListId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Building",
                table: "Departments",
                sql: "Building>=1 and Building<5");

            migrationBuilder.CreateIndex(
                name: "IX_CuratorGroup_GroupsListId",
                table: "CuratorGroup",
                column: "GroupsListId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DepartmentId",
                table: "Groups",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuratorGroup");

            migrationBuilder.DropTable(
                name: "Curators");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Building",
                table: "Departments");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Building",
                table: "Departments",
                sql: "Building>1 and Building<5");
        }
    }
}
