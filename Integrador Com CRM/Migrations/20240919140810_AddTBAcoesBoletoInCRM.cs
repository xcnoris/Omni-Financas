using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddTBAcoesBoletoInCRM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "boletoAcoes_CRM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dias_Cobrancas = table.Column<int>(type: "int", maxLength: 300, nullable: false),
                    Codigo_Acao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boletoAcoes_CRM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boletoAcoes_CRM");
        }
    }
}
