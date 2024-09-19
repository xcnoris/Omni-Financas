using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddColumMensagemBoletoAcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mensagem_Atualizacao",
                table: "boletoAcoes_CRM",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mensagem_Atualizacao",
                table: "boletoAcoes_CRM");
        }
    }
}
