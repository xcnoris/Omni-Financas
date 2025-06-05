using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddClnEnviarEmailEWhatsEHTMLINTBSitBol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mensagem",
                table: "acaoSituacao_Boleto_OmniService",
                newName: "MensagemAtualizacaoWhats");

            migrationBuilder.AddColumn<bool>(
                name: "EnviarPDFPorEmail",
                table: "acaoSituacao_Boleto_OmniService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnviarPDFPorWhats",
                table: "acaoSituacao_Boleto_OmniService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MensagemAtualizacaoEmail",
                table: "acaoSituacao_Boleto_OmniService",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "MensagemEmailEmHTML",
                table: "acaoSituacao_Boleto_OmniService",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnviarPDFPorEmail",
                table: "acaoSituacao_Boleto_OmniService");

            migrationBuilder.DropColumn(
                name: "EnviarPDFPorWhats",
                table: "acaoSituacao_Boleto_OmniService");

            migrationBuilder.DropColumn(
                name: "MensagemAtualizacaoEmail",
                table: "acaoSituacao_Boleto_OmniService");

            migrationBuilder.DropColumn(
                name: "MensagemEmailEmHTML",
                table: "acaoSituacao_Boleto_OmniService");

            migrationBuilder.RenameColumn(
                name: "MensagemAtualizacaoWhats",
                table: "acaoSituacao_Boleto_OmniService",
                newName: "Mensagem");
        }
    }
}
