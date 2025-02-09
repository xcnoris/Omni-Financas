using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddClnCodAPIPDFInTBDDAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodAPI_EnvioPDF",
                table: "DadosAPI_CRM",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodAPI_EnvioPDF",
                table: "DadosAPI_CRM");
        }
    }
}
