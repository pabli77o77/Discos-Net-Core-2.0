using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Disqueria.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discograficas",
                columns: table => new
                {
                    DiscograficaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discografica = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discograficas", x => x.DiscograficaID);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Genero = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    ArtistaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artista = table.Column<string>(maxLength: 100, nullable: false),
                    GeneroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.ArtistaID);
                    table.ForeignKey(
                        name: "FK_Artistas_Generos_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Generos",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    DiscoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Disco = table.Column<string>(maxLength: 100, nullable: false),
                    ArtistaID = table.Column<int>(nullable: false),
                    GeneroID = table.Column<int>(nullable: false),
                    DiscograficaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.DiscoID);
                    table.ForeignKey(
                        name: "FK_Discos_Artistas_ArtistaID",
                        column: x => x.ArtistaID,
                        principalTable: "Artistas",
                        principalColumn: "ArtistaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discos_Discograficas_DiscograficaID",
                        column: x => x.DiscograficaID,
                        principalTable: "Discograficas",
                        principalColumn: "DiscograficaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discos_Generos_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Generos",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    CancionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cancion = table.Column<string>(maxLength: 100, nullable: false),
                    Duracion = table.Column<string>(nullable: true),
                    DiscoID = table.Column<int>(nullable: true)
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
                name: "IX_Artistas_GeneroID",
                table: "Artistas",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_DiscoID",
                table: "Canciones",
                column: "DiscoID");

            migrationBuilder.CreateIndex(
                name: "IX_Discos_ArtistaID",
                table: "Discos",
                column: "ArtistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Discos_DiscograficaID",
                table: "Discos",
                column: "DiscograficaID");

            migrationBuilder.CreateIndex(
                name: "IX_Discos_GeneroID",
                table: "Discos",
                column: "GeneroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Discos");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Discograficas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
