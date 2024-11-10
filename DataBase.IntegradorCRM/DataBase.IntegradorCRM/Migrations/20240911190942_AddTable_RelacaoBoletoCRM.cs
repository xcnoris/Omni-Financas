using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Integrador_Com_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_RelacaoBoletoCRM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelacaoBoletoCRM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Documento = table.Column<int>(type: "int", nullable: false),
                    Numero_Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Entidade = table.Column<int>(type: "int", nullable: false),
                    Nome_Entidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular_Entidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Entidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    Data_Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cod_Oportunidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quitado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacaoBoletoCRM", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacaoBoletoCRM");
        }
    }
}
