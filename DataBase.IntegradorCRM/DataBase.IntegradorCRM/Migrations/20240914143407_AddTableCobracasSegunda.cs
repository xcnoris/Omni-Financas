using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCobracasSegunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobrancas_Na_Segunda_CRM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoJornada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoletoId = table.Column<int>(type: "int", nullable: false),
                    NovoAtrasoBoleto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobrancas_Na_Segunda_CRM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobrancas_Na_Segunda_CRM_RelacaoBoletoCRM_BoletoId",
                        column: x => x.BoletoId,
                        principalTable: "RelacaoBoletoCRM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_Na_Segunda_CRM_BoletoId",
                table: "Cobrancas_Na_Segunda_CRM",
                column: "BoletoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobrancas_Na_Segunda_CRM");
        }
    }
}
