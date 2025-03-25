using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoTBToIntegracaoWithEvolutionAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cod_Oportunidade",
                table: "Relacao_OS_Com_CRM");

            migrationBuilder.DropColumn(
                name: "Codigo_Acao",
                table: "OSAcao_CRM");

            migrationBuilder.DropColumn(
                name: "Cod_API_Boleto",
                table: "DadosAPI_CRM");

            migrationBuilder.DropColumn(
                name: "Cod_API_OrdemServico",
                table: "DadosAPI_CRM");

            migrationBuilder.DropColumn(
                name: "Cod_Jornada_Boleto",
                table: "DadosAPI_CRM");

            migrationBuilder.DropColumn(
                name: "Cod_Jornada_OrdemServico",
                table: "DadosAPI_CRM");

            migrationBuilder.DropColumn(
                name: "Codigo_Acao",
                table: "boletoAcoes_CRM");

            migrationBuilder.DropColumn(
                name: "CodAcaoCRM",
                table: "acaoSituacao_OS_CRM");

            migrationBuilder.DropColumn(
                name: "CodAcaoCRM",
                table: "acaoSituacao_Boleto_CRM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cod_Oportunidade",
                table: "Relacao_OS_Com_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Codigo_Acao",
                table: "OSAcao_CRM",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cod_API_Boleto",
                table: "DadosAPI_CRM",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cod_API_OrdemServico",
                table: "DadosAPI_CRM",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cod_Jornada_Boleto",
                table: "DadosAPI_CRM",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cod_Jornada_OrdemServico",
                table: "DadosAPI_CRM",
                type: "nvarchar(max)",
                maxLength: 51000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Codigo_Acao",
                table: "boletoAcoes_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodAcaoCRM",
                table: "acaoSituacao_OS_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodAcaoCRM",
                table: "acaoSituacao_Boleto_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
