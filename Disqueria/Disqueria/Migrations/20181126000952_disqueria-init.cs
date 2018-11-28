using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Disqueria.Migrations
{
    public partial class disqueriainit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscoVM");

            migrationBuilder.RenameColumn(
                name: "Disco",
                table: "Discos",
                newName: "Titulo");

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    EntidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoEntidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.EntidadID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Discos",
                newName: "Disco");

            migrationBuilder.CreateTable(
                name: "DiscoVM",
                columns: table => new
                {
                    DiscoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artista = table.Column<string>(nullable: true),
                    ArtistaID = table.Column<int>(nullable: false),
                    Discografica = table.Column<string>(nullable: true),
                    DiscograficaID = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(nullable: true),
                    GeneroID = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoVM", x => x.DiscoID);
                });
        }
    }
}
