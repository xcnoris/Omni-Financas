using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AltNMControleComissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Controle_Liberacao_Comissao",
                table: "Controle_Liberacao_Comissao");

            migrationBuilder.RenameTable(
                name: "Controle_Liberacao_Comissao",
                newName: "Controle_Liberacao_Comissao_OminiService");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Controle_Liberacao_Comissao_OminiService",
                table: "Controle_Liberacao_Comissao_OminiService",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Controle_Liberacao_Comissao_OminiService",
                table: "Controle_Liberacao_Comissao_OminiService");

            migrationBuilder.RenameTable(
                name: "Controle_Liberacao_Comissao_OminiService",
                newName: "Controle_Liberacao_Comissao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Controle_Liberacao_Comissao",
                table: "Controle_Liberacao_Comissao",
                column: "Id");
        }
    }
}
