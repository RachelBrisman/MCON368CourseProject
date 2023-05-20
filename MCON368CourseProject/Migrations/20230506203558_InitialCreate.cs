using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCON368CourseProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rebbi",
                columns: table => new
                {
                    RebbiID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rebbi", x => x.RebbiID);
                });

            migrationBuilder.CreateTable(
                name: "Shiur",
                columns: table => new
                {
                    ShiurID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RebbiId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shiur", x => x.ShiurID);
                    table.ForeignKey(
                        name: "FK_Shiur_Rebbi_RebbiId",
                        column: x => x.RebbiId,
                        principalTable: "Rebbi",
                        principalColumn: "RebbiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    ShiurID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_Shiur_ShiurID",
                        column: x => x.ShiurID,
                        principalTable: "Shiur",
                        principalColumn: "ShiurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shiur_RebbiId",
                table: "Shiur",
                column: "RebbiId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ShiurID",
                table: "Student",
                column: "ShiurID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Shiur");

            migrationBuilder.DropTable(
                name: "Rebbi");
        }
    }
}
