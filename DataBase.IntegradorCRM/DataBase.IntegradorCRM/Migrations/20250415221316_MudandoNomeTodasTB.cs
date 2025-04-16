using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class MudandoNomeTodasTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelacaoBoletoCRM",
                table: "RelacaoBoletoCRM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relacao_OS_Com_CRM",
                table: "Relacao_OS_Com_CRM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OSAcao_CRM",
                table: "OSAcao_CRM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DadosAPI_CRM",
                table: "DadosAPI_CRM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boletoAcoes_CRM",
                table: "boletoAcoes_CRM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_acaoSituacao_OS_CRM",
                table: "acaoSituacao_OS_CRM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_acaoSituacao_Boleto_CRM",
                table: "acaoSituacao_Boleto_CRM");

            migrationBuilder.RenameTable(
                name: "RelacaoBoletoCRM",
                newName: "RelacaoBoleto_OmniService");

            migrationBuilder.RenameTable(
                name: "Relacao_OS_Com_CRM",
                newName: "Relacao_OS_OmniService");

            migrationBuilder.RenameTable(
                name: "OSAcao_CRM",
                newName: "OSAcao_OmniService");

            migrationBuilder.RenameTable(
                name: "DadosAPI_CRM",
                newName: "DadosAPI_OmniService");

            migrationBuilder.RenameTable(
                name: "boletoAcoes_CRM",
                newName: "boletoAcoes_OmniService");

            migrationBuilder.RenameTable(
                name: "acaoSituacao_OS_CRM",
                newName: "acaoSituacao_OS_OmniService");

            migrationBuilder.RenameTable(
                name: "acaoSituacao_Boleto_CRM",
                newName: "acaoSituacao_Boleto_OmniService");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelacaoBoleto_OmniService",
                table: "RelacaoBoleto_OmniService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relacao_OS_OmniService",
                table: "Relacao_OS_OmniService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OSAcao_OmniService",
                table: "OSAcao_OmniService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DadosAPI_OmniService",
                table: "DadosAPI_OmniService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boletoAcoes_OmniService",
                table: "boletoAcoes_OmniService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_acaoSituacao_OS_OmniService",
                table: "acaoSituacao_OS_OmniService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_acaoSituacao_Boleto_OmniService",
                table: "acaoSituacao_Boleto_OmniService",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelacaoBoleto_OmniService",
                table: "RelacaoBoleto_OmniService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relacao_OS_OmniService",
                table: "Relacao_OS_OmniService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OSAcao_OmniService",
                table: "OSAcao_OmniService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DadosAPI_OmniService",
                table: "DadosAPI_OmniService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boletoAcoes_OmniService",
                table: "boletoAcoes_OmniService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_acaoSituacao_OS_OmniService",
                table: "acaoSituacao_OS_OmniService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_acaoSituacao_Boleto_OmniService",
                table: "acaoSituacao_Boleto_OmniService");

            migrationBuilder.RenameTable(
                name: "RelacaoBoleto_OmniService",
                newName: "RelacaoBoletoCRM");

            migrationBuilder.RenameTable(
                name: "Relacao_OS_OmniService",
                newName: "Relacao_OS_Com_CRM");

            migrationBuilder.RenameTable(
                name: "OSAcao_OmniService",
                newName: "OSAcao_CRM");

            migrationBuilder.RenameTable(
                name: "DadosAPI_OmniService",
                newName: "DadosAPI_CRM");

            migrationBuilder.RenameTable(
                name: "boletoAcoes_OmniService",
                newName: "boletoAcoes_CRM");

            migrationBuilder.RenameTable(
                name: "acaoSituacao_OS_OmniService",
                newName: "acaoSituacao_OS_CRM");

            migrationBuilder.RenameTable(
                name: "acaoSituacao_Boleto_OmniService",
                newName: "acaoSituacao_Boleto_CRM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelacaoBoletoCRM",
                table: "RelacaoBoletoCRM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relacao_OS_Com_CRM",
                table: "Relacao_OS_Com_CRM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OSAcao_CRM",
                table: "OSAcao_CRM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DadosAPI_CRM",
                table: "DadosAPI_CRM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boletoAcoes_CRM",
                table: "boletoAcoes_CRM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_acaoSituacao_OS_CRM",
                table: "acaoSituacao_OS_CRM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_acaoSituacao_Boleto_CRM",
                table: "acaoSituacao_Boleto_CRM",
                column: "Id");
        }
    }
}
