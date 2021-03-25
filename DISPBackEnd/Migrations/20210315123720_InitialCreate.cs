using Microsoft.EntityFrameworkCore.Migrations;

namespace DISPBackEnd.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HaandVaerkers",
                columns: table => new
                {
                    HaandVaerkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaandVaerkers", x => x.HaandVaerkerId);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejskasses",
                columns: table => new
                {
                    VaerktoejskasseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VTKanskaffet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTKEjesAf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTKFabrikat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTKFarve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTKModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTKSerieNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HaandVaerkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejskasses", x => x.VaerktoejskasseId);
                    table.ForeignKey(
                        name: "FK_Vaerktoejskasses_HaandVaerkers_HaandVaerkerId",
                        column: x => x.HaandVaerkerId,
                        principalTable: "HaandVaerkers",
                        principalColumn: "HaandVaerkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejs",
                columns: table => new
                {
                    VaerktoejId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Liggerlvtk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTAnskaffet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTFabrikat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTSerieNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VTType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaerktoejskasseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejs", x => x.VaerktoejId);
                    table.ForeignKey(
                        name: "FK_Vaerktoejs_Vaerktoejskasses_VaerktoejskasseId",
                        column: x => x.VaerktoejskasseId,
                        principalTable: "Vaerktoejskasses",
                        principalColumn: "VaerktoejskasseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejs_VaerktoejskasseId",
                table: "Vaerktoejs",
                column: "VaerktoejskasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejskasses_HaandVaerkerId",
                table: "Vaerktoejskasses",
                column: "HaandVaerkerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaerktoejs");

            migrationBuilder.DropTable(
                name: "Vaerktoejskasses");

            migrationBuilder.DropTable(
                name: "HaandVaerkers");
        }
    }
}
