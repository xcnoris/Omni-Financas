using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddClnInTBControleLibComissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_hora_emissao_nota",
                table: "Controle_Liberacao_Comissao_OminiService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "id_situacao_documento_fiscal",
                table: "Controle_Liberacao_Comissao_OminiService",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numero_documento_fiscal",
                table: "Controle_Liberacao_Comissao_OminiService",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_hora_emissao_nota",
                table: "Controle_Liberacao_Comissao_OminiService");

            migrationBuilder.DropColumn(
                name: "id_situacao_documento_fiscal",
                table: "Controle_Liberacao_Comissao_OminiService");

            migrationBuilder.DropColumn(
                name: "numero_documento_fiscal",
                table: "Controle_Liberacao_Comissao_OminiService");
        }
    }
}
