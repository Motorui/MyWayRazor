using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class Formacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formacoes",
                columns: table => new
                {
                    FormacaoId = table.Column<Guid>(nullable: false),
                    FormacaoNome = table.Column<string>(nullable: false),
                    FormacaoCod = table.Column<string>(nullable: false),
                    FormacaoValidade = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacoes", x => x.FormacaoId);
                });

            migrationBuilder.CreateTable(
                name: "FormacoesColaboradores",
                columns: table => new
                {
                    FormacaoColaboradorId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_FormacoesColaboradores", x => x.FormacaoColaboradorId);
                    table.ForeignKey(
                        name: "FK_FormacoesColaboradores_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormacoesColaboradores_Formacoes_FormacaoId",
                        column: x => x.FormacaoId,
                        principalTable: "Formacoes",
                        principalColumn: "FormacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Formacoes",
                columns: new[] { "FormacaoId", "CreatedAt", "CreatedBy", "FormacaoCod", "FormacaoNome", "FormacaoValidade", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[,]
                {
                    { new Guid("8589e164-206b-4d2e-bb7d-0db86888333a"), new DateTime(2019, 7, 5, 14, 2, 47, 717, DateTimeKind.Utc).AddTicks(2319), "SISTEMA", "BPMR", "BÁSICO DE PMR", 1, null, null },
                    { new Guid("33f02418-28cf-4c9e-b3a8-026ae7a04a68"), new DateTime(2019, 7, 5, 14, 2, 47, 717, DateTimeKind.Utc).AddTicks(3143), "SISTEMA", "RS", "RAMP SAFETY", 3, null, null },
                    { new Guid("8733f9f2-62de-421e-8d46-e531621ee866"), new DateTime(2019, 7, 5, 14, 2, 47, 717, DateTimeKind.Utc).AddTicks(3151), "SISTEMA", "SEC.13", "SEGURANÇA NÍVEL 13", 3, null, null },
                    { new Guid("414963de-a919-4153-b38a-2097d10a4999"), new DateTime(2019, 7, 5, 14, 2, 47, 717, DateTimeKind.Utc).AddTicks(3153), "SISTEMA", "DGR CAT.9", "DANGEROUS GOODS CAT.9", 2, null, null },
                    { new Guid("8b641059-391b-4c62-aa07-48a8c487f70e"), new DateTime(2019, 7, 5, 14, 2, 47, 717, DateTimeKind.Utc).AddTicks(3154), "SISTEMA", "HF", "HUMAN FACTOR", 3, null, null },
                    { new Guid("1be07f96-4fe3-44e0-8518-9a0e8118b3b5"), new DateTime(2019, 7, 5, 14, 2, 47, 717, DateTimeKind.Utc).AddTicks(3165), "SISTEMA", "SST", "SAÚDE E SEGURANÇA NO TRABALHO", 3, null, null },
                    { new Guid("eeb04d48-676a-4a0f-abb7-dddfed6df1f6"), new DateTime(2019, 7, 5, 14, 2, 47, 717, DateTimeKind.Utc).AddTicks(3208), "SISTEMA", "ENB", "ESCOLA NACIONAL DE BOMBEIROS", 2, null, null },
                    { new Guid("8333494e-fe57-4b48-b26f-8c47314afa9e"), new DateTime(2019, 7, 5, 14, 2, 47, 717, DateTimeKind.Utc).AddTicks(3210), "SISTEMA", "GSE", "GSE AMBULIFTS", 3, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "AlternateKey_Nome",
                table: "Colaborador",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AlternateKey_Cod",
                table: "Formacoes",
                column: "FormacaoCod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AlternateKey_Nome",
                table: "Formacoes",
                column: "FormacaoNome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormacoesColaboradores_ColaboradorId",
                table: "FormacoesColaboradores",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_FormacoesColaboradores_FormacaoId",
                table: "FormacoesColaboradores",
                column: "FormacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormacoesColaboradores");

            migrationBuilder.DropTable(
                name: "Formacoes");

            migrationBuilder.DropIndex(
                name: "AlternateKey_Nome",
                table: "Colaborador");
        }
    }
}
