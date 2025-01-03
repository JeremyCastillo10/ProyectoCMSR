﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoCMSR.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: true),
                    Contenido = table.Column<string>(type: "longtext", nullable: true),
                    Autor = table.Column<string>(type: "longtext", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Categoria = table.Column<string>(type: "longtext", nullable: true),
                    ImagenPrincipal = table.Column<byte[]>(type: "longblob", nullable: true),
                    ImagenContenido = table.Column<byte[]>(type: "longblob", nullable: true),
                    visible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Slug = table.Column<string>(type: "longtext", nullable: true),
                    Visitas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    ImagenMedico = table.Column<byte[]>(type: "longblob", nullable: true),
                    Visible = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Anestesia General" },
                    { 2, "Anestesia Pediátrica" },
                    { 3, "Cardiología/Hemodinamista" },
                    { 4, "Cardiología Pediátrica" },
                    { 5, "Cirugía Vascular" },
                    { 6, "Cirugía General" },
                    { 7, "Cirugía Pediátrica" },
                    { 8, "Cirugía Maxilofacial" },
                    { 9, "Dermatología" },
                    { 10, "Cirugía Facial" },
                    { 11, "Diabetología" },
                    { 12, "Endocrinología" },
                    { 13, "Gastroenterología Pediátrico" },
                    { 14, "Gastroenterología" },
                    { 15, "Geriatría" },
                    { 16, "Gineco-Obstetricia" },
                    { 17, "Intensivista" },
                    { 18, "Medicina Interna" },
                    { 19, "Medicina Familiar" },
                    { 20, "Neonatología" },
                    { 21, "Neumología" },
                    { 22, "Neurología" },
                    { 23, "Neurocirugía" },
                    { 24, "Ortopedia" },
                    { 25, "Traumatología" },
                    { 26, "Ortopedia Pediátrica" },
                    { 27, "Otorrinolaringología" },
                    { 28, "Oftalmología" },
                    { 29, "Pediatría" },
                    { 30, "Psiquiatría" },
                    { 31, "Psicología" },
                    { 32, "Urología" },
                    { 33, "Nefrología" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadId",
                table: "Medicos",
                column: "EspecialidadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
