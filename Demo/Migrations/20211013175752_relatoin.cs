using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class relatoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DormId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dorm",
                columns: table => new
                {
                    DormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dorm", x => x.DormId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DormId",
                table: "Students",
                column: "DormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Dorm_DormId",
                table: "Students",
                column: "DormId",
                principalTable: "Dorm",
                principalColumn: "DormId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Dorm_DormId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Dorm");

            migrationBuilder.DropIndex(
                name: "IX_Students_DormId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DormId",
                table: "Students");
        }
    }
}
