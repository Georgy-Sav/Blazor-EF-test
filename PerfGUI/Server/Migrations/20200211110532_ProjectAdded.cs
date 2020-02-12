using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfGUI.Server.Migrations
{
    public partial class ProjectAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "PerfData",
                table: "Environment");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                schema: "PerfData",
                table: "Environment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "PerfData",
                columns: table => new
                {
                    ProjectId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Environment_ProjectId",
                schema: "PerfData",
                table: "Environment",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Environment_Project_ProjectId",
                schema: "PerfData",
                table: "Environment",
                column: "ProjectId",
                principalSchema: "PerfData",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Environment_Project_ProjectId",
                schema: "PerfData",
                table: "Environment");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "PerfData");

            migrationBuilder.DropIndex(
                name: "IX_Environment_ProjectId",
                schema: "PerfData",
                table: "Environment");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "PerfData",
                table: "Environment");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "PerfData",
                table: "Environment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
