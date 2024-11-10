using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddTBOSACAO1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OSAcao_CRM_IdCategoria",
                table: "OSAcao_CRM");

            migrationBuilder.DropIndex(
                name: "IX_boletoAcoes_CRM_Dias_Cobrancas",
                table: "boletoAcoes_CRM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OSAcao_CRM_IdCategoria",
                table: "OSAcao_CRM",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_boletoAcoes_CRM_Dias_Cobrancas",
                table: "boletoAcoes_CRM",
                column: "Dias_Cobrancas");
        }
    }
}
