using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddTBControlLiberacaoComiss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Controle_Liberacao_Comissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Usuario_Vendedor = table.Column<int>(type: "int", nullable: false),
                    Nome_Vendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Documento_Receber = table.Column<int>(type: "int", nullable: true),
                    Numero_Documento_Receber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Vencimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data_Quitacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true),
                    DR_Total_Gerados = table.Column<int>(type: "int", nullable: false),
                    Valor_Comissao_Por_Parcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pago_para_Vendedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controle_Liberacao_Comissao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Controle_Liberacao_Comissao");
        }
    }
}
