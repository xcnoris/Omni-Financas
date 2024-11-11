using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddTBAcaoSitBoleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Atualizacao",
                table: "acaoSituacao_OS_CRM",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Cricao",
                table: "acaoSituacao_OS_CRM",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "acaoSituacao_Boleto_CRM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    CodAcaoCRM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem_Acao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Cricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acaoSituacao_Boleto_CRM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acaoSituacao_Boleto_CRM");

            migrationBuilder.DropColumn(
                name: "Data_Atualizacao",
                table: "acaoSituacao_OS_CRM");

            migrationBuilder.DropColumn(
                name: "Data_Cricao",
                table: "acaoSituacao_OS_CRM");
        }
    }
}
