using Microsoft.EntityFrameworkCore.Migrations;

namespace IDLPrueba.Migrations
{
    public partial class pais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaisCodigo",
                table: "Departamento",
                newName: "PaisId");

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_PaisId",
                table: "Departamento",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Pais_PaisId",
                table: "Departamento",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Pais_PaisId",
                table: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_PaisId",
                table: "Departamento");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "Departamento",
                newName: "PaisCodigo");
        }
    }
}
