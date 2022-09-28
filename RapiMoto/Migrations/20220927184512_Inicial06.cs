using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapiMoto.Migrations
{
    public partial class Inicial06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoAdminId",
                table: "Administrador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipoadmini = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAdmin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_TipoAdminId",
                table: "Administrador",
                column: "TipoAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrador_TipoAdmin_TipoAdminId",
                table: "Administrador",
                column: "TipoAdminId",
                principalTable: "TipoAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrador_TipoAdmin_TipoAdminId",
                table: "Administrador");

            migrationBuilder.DropTable(
                name: "TipoAdmin");

            migrationBuilder.DropIndex(
                name: "IX_Administrador_TipoAdminId",
                table: "Administrador");

            migrationBuilder.DropColumn(
                name: "TipoAdminId",
                table: "Administrador");
        }
    }
}
