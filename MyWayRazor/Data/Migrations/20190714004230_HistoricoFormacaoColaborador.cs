using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class HistoricoFormacaoColaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoFormacoesColaboradores",
                columns: table => new
                {
                    HistoricoFormacaoColaboradorId = table.Column<Guid>(nullable: false),
                    FormacaoId = table.Column<Guid>(nullable: false),
                    ColaboradorId = table.Column<int>(nullable: false),
                    FormacaoData = table.Column<DateTime>(nullable: false),
                    FormacaoCaducidade = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoFormacoesColaboradores", x => x.HistoricoFormacaoColaboradorId);
                    table.ForeignKey(
                        name: "FK_HistoricoFormacoesColaboradores_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoFormacoesColaboradores_Formacoes_FormacaoId",
                        column: x => x.FormacaoId,
                        principalTable: "Formacoes",
                        principalColumn: "FormacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFormacoesColaboradores_ColaboradorId",
                table: "HistoricoFormacoesColaboradores",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFormacoesColaboradores_FormacaoId",
                table: "HistoricoFormacoesColaboradores",
                column: "FormacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoFormacoesColaboradores");
        }
    }
}
