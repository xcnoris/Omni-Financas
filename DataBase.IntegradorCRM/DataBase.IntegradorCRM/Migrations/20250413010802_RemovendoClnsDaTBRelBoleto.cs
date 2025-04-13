using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoClnsDaTBRelBoleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cod_Oportunidade",
                table: "Cobrancas_Na_Segunda_CRM");

            migrationBuilder.DropColumn(
                name: "CodigoJornada",
                table: "Cobrancas_Na_Segunda_CRM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cod_Oportunidade",
                table: "Cobrancas_Na_Segunda_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoJornada",
                table: "Cobrancas_Na_Segunda_CRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
