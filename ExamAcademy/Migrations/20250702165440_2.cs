using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamAcademy.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuratorGroup");

            migrationBuilder.CreateTable(
                name: "CuratorGroups",
                columns: table => new
                {
                    CuratorListId = table.Column<int>(type: "int", nullable: false),
                    GroupsListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuratorGroups", x => new { x.CuratorListId, x.GroupsListId });
                    table.ForeignKey(
                        name: "FK_CuratorGroups_Curators_CuratorListId",
                        column: x => x.CuratorListId,
                        principalTable: "Curators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuratorGroups_Groups_GroupsListId",
                        column: x => x.GroupsListId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuratorGroups_GroupsListId",
                table: "CuratorGroups",
                column: "GroupsListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuratorGroups");

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

            migrationBuilder.CreateIndex(
                name: "IX_CuratorGroup_GroupsListId",
                table: "CuratorGroup",
                column: "GroupsListId");
        }
    }
}
