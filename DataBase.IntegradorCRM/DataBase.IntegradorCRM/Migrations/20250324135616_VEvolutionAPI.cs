using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class VEvolutionAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mensagem_Acao",
                table: "acaoSituacao_OS_CRM",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Mensagem_Acao",
                table: "acaoSituacao_Boleto_CRM",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Instancia",
                table: "DadosAPI_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mensagem",
                table: "acaoSituacao_OS_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mensagem",
                table: "acaoSituacao_Boleto_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instancia",
                table: "DadosAPI_CRM");

            migrationBuilder.DropColumn(
                name: "Mensagem",
                table: "acaoSituacao_OS_CRM");

            migrationBuilder.DropColumn(
                name: "Mensagem",
                table: "acaoSituacao_Boleto_CRM");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "acaoSituacao_OS_CRM",
                newName: "Mensagem_Acao");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "acaoSituacao_Boleto_CRM",
                newName: "Mensagem_Acao");
        }
    }
}
