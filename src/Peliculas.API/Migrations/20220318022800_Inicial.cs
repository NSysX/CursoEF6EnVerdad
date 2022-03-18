using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Peliculas.API.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "Nombre del Actor"),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Biografia de Actor"),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true, comment: "Fecha de Nacimiento del Actor")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                },
                comment: "Catalogo de Actores");

            migrationBuilder.CreateTable(
                name: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "Nombre del Cine"),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cine", x => x.Id);
                },
                comment: "Catalogo de Cines");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "Nombre del Genero")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                },
                comment: "Catalogo de Generos");

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "Titulo de la Pelicula"),
                    EnCartelera = table.Column<bool>(type: "bit", nullable: false, comment: "Si esta en Cartelera"),
                    FechaEstreno = table.Column<DateTime>(type: "date", nullable: false, comment: "Fecha de Estreno"),
                    PosterURL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "URL de la imagen del Poster")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                },
                comment: "Catalogo de Peliculas");

            migrationBuilder.CreateTable(
                name: "CineOferta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CineId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CineOferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CineOferta_Cine_CineId",
                        column: x => x.CineId,
                        principalTable: "Cine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Catalogo de ofertas por cine");

            migrationBuilder.CreateTable(
                name: "SalaCine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSalaDeCine = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Precio = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false, comment: "El precio de la sala del cine"),
                    CineId = table.Column<int>(type: "int", nullable: false, comment: "El id Consecutivo de la tabla cine")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaCine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaCine_Cine_CineId",
                        column: x => x.CineId,
                        principalTable: "Cine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Salas de cine");

            migrationBuilder.CreateTable(
                name: "GeneroPelicula",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false),
                    PeliculasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroPelicula", x => new { x.GenerosId, x.PeliculasId });
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_Genero_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_Pelicula_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaActor",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "Nombre del personale"),
                    Orden = table.Column<int>(type: "int", nullable: false, comment: "El orden de importancia del persionaje")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaActor", x => new { x.PeliculaId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_PeliculaActor_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaActor_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Relacion entre las tablas Pelicula y Actor");

            migrationBuilder.CreateTable(
                name: "PeliculaSalaCine",
                columns: table => new
                {
                    PeliculasId = table.Column<int>(type: "int", nullable: false),
                    SalaCinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSalaCine", x => new { x.PeliculasId, x.SalaCinesId });
                    table.ForeignKey(
                        name: "FK_PeliculaSalaCine_Pelicula_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaSalaCine_SalaCine_SalaCinesId",
                        column: x => x.SalaCinesId,
                        principalTable: "SalaCine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Ix_ActorNomDup",
                table: "Actor",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ix_CineNomDup",
                table: "Cine",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ix_CineOfertaCinDup",
                table: "CineOferta",
                column: "CineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ix_GeneroNomDupl",
                table: "Genero",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneroPelicula_PeliculasId",
                table: "GeneroPelicula",
                column: "PeliculasId");

            migrationBuilder.CreateIndex(
                name: "Ix_PelTituloDup",
                table: "Pelicula",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaActor_ActorId",
                table: "PeliculaActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSalaCine_SalaCinesId",
                table: "PeliculaSalaCine",
                column: "SalaCinesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaCine_CineId",
                table: "SalaCine",
                column: "CineId");

            migrationBuilder.CreateIndex(
                name: "Ix_SalaCineNoDup",
                table: "SalaCine",
                columns: new[] { "Id", "CineId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CineOferta");

            migrationBuilder.DropTable(
                name: "GeneroPelicula");

            migrationBuilder.DropTable(
                name: "PeliculaActor");

            migrationBuilder.DropTable(
                name: "PeliculaSalaCine");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "SalaCine");

            migrationBuilder.DropTable(
                name: "Cine");
        }
    }
}
