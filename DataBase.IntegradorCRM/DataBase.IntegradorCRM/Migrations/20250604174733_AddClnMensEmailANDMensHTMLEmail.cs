using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddClnMensEmailANDMensHTMLEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mensagem_Atualizacao",
                table: "boletoAcoes_OmniService",
                newName: "MensagemAtualizacaoWhats");

            migrationBuilder.RenameColumn(
                name: "EnviarPDF",
                table: "boletoAcoes_OmniService",
                newName: "MensagemEmailEmHTML");

            migrationBuilder.AddColumn<bool>(
                name: "EnviarPDFPorEmail",
                table: "boletoAcoes_OmniService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnviarPDFPorWhats",
                table: "boletoAcoes_OmniService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MensagemAtualizacaoEmail",
                table: "boletoAcoes_OmniService",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnviarPDFPorEmail",
                table: "boletoAcoes_OmniService");

            migrationBuilder.DropColumn(
                name: "EnviarPDFPorWhats",
                table: "boletoAcoes_OmniService");

            migrationBuilder.DropColumn(
                name: "MensagemAtualizacaoEmail",
                table: "boletoAcoes_OmniService");

            migrationBuilder.RenameColumn(
                name: "MensagemEmailEmHTML",
                table: "boletoAcoes_OmniService",
                newName: "EnviarPDF");

            migrationBuilder.RenameColumn(
                name: "MensagemAtualizacaoWhats",
                table: "boletoAcoes_OmniService",
                newName: "Mensagem_Atualizacao");
        }
    }
}
