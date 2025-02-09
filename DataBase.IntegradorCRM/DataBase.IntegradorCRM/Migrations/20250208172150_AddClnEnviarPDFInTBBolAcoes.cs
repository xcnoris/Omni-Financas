using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddClnEnviarPDFInTBBolAcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnviarPDF",
                table: "boletoAcoes_CRM",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnviarPDF",
                table: "boletoAcoes_CRM");
        }
    }
}
