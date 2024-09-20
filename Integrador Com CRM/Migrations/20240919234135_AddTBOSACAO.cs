using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddTBOSACAO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Criacao",
                table: "boletoAcoes_CRM",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "OSAcao_CRM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Codigo_Acao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Mensagem_Atualizacao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Data_Criacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSAcao_CRM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_boletoAcoes_CRM_Dias_Cobrancas",
                table: "boletoAcoes_CRM",
                column: "Dias_Cobrancas");

            migrationBuilder.CreateIndex(
                name: "IX_OSAcao_CRM_IdCategoria",
                table: "OSAcao_CRM",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OSAcao_CRM");

            migrationBuilder.DropIndex(
                name: "IX_boletoAcoes_CRM_Dias_Cobrancas",
                table: "boletoAcoes_CRM");

            migrationBuilder.DropColumn(
                name: "Data_Criacao",
                table: "boletoAcoes_CRM");
        }
    }
}
