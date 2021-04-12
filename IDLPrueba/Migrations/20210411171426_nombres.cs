using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDLPrueba.Migrations
{
    public partial class nombres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisCodigo = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<int>(type: "int", nullable: false),
                    FCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiudadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<int>(type: "int", nullable: false),
                    FCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_DepartamentoId",
                table: "Ciudad",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
