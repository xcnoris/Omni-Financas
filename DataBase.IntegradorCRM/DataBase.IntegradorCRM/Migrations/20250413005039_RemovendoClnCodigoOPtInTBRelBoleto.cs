using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoClnCodigoOPtInTBRelBoleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cod_Oportunidade",
                table: "RelacaoBoletoCRM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cod_Oportunidade",
                table: "RelacaoBoletoCRM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
