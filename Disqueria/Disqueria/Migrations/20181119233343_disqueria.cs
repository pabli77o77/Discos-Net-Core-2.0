using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Disqueria.Migrations
{
    public partial class disqueria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Generos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "DiscoVM",
                columns: table => new
                {
                    DiscoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 100, nullable: false),
                    Artista = table.Column<string>(nullable: true),
                    ArtistaID = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(nullable: true),
                    GeneroID = table.Column<int>(nullable: false),
                    Discografica = table.Column<string>(nullable: true),
                    DiscograficaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoVM", x => x.DiscoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscoVM");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Generos",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    CancionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscoID = table.Column<int>(nullable: true),
                    Duracion = table.Column<string>(nullable: true),
                    Cancion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.CancionID);
                    table.ForeignKey(
                        name: "FK_Canciones_Discos_DiscoID",
                        column: x => x.DiscoID,
                        principalTable: "Discos",
                        principalColumn: "DiscoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_DiscoID",
                table: "Canciones",
                column: "DiscoID");
        }
    }
}
