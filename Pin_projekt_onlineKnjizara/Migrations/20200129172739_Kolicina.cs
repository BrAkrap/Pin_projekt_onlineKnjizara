using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pin_projekt_onlineKnjizara.Migrations
{
    public partial class Kolicina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kosarice");

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Knjige",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Knjige");

            migrationBuilder.CreateTable(
                name: "Kosarice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KnjigaId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    KosaricaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kosarice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kosarice_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kosarice_KnjigaId",
                table: "Kosarice",
                column: "KnjigaId");
        }
    }
}
