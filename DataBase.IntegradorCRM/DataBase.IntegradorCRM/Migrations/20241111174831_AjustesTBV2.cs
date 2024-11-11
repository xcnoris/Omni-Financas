using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AjustesTBV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cod_API_Boleto",
                table: "DadosAPI_CRM",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cod_API_OrdemServico",
                table: "DadosAPI_CRM",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cod_Jornada_Boleto",
                table: "DadosAPI_CRM",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cod_Jornada_OrdemServico",
                table: "DadosAPI_CRM",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "acaoSituacao_OS_CRM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    CodAcaoCRM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem_Acao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acaoSituacao_OS_CRM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acaoSituacao_OS_CRM");

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
        }
    }
}
