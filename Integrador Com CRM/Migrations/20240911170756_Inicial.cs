using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relacao_OS_Com_CRM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_OrdemServico = table.Column<int>(type: "int", nullable: false),
                    Cod_Oportunidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_CategoriaOS = table.Column<int>(type: "int", nullable: false),
                    Data_Criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Alteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacao_OS_Com_CRM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relacao_OS_Com_CRM");
        }
    }
}
