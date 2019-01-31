using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class FirstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaNome = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    ContratoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContratoTipo = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.ContratoId);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartamentoNumero = table.Column<int>(nullable: false),
                    DepartamentoNome = table.Column<string>(maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Equipa",
                columns: table => new
                {
                    EquipaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipaNome = table.Column<string>(maxLength: 5, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipa", x => x.EquipaId);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    FuncaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FuncaoNome = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.FuncaoId);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HorarioHora = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Statuses = table.Column<string>(maxLength: 25, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Uh",
                columns: table => new
                {
                    UhId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IATA = table.Column<string>(maxLength: 5, nullable: false),
                    UhNome = table.Column<string>(maxLength: 25, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uh", x => x.UhId);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UhId = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    NumCartao = table.Column<int>(nullable: false),
                    NumPw = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    FuncaoId = table.Column<int>(nullable: false),
                    EquipaId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    HorarioPraticadoId = table.Column<int>(nullable: true),
                    HorarioContratadoId = table.Column<int>(nullable: true),
                    DataAdmissão = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    ContratoId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.ColaboradorID);
                    table.ForeignKey(
                        name: "FK_Colaborador_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Equipa_EquipaId",
                        column: x => x.EquipaId,
                        principalTable: "Equipa",
                        principalColumn: "EquipaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Funcao_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcao",
                        principalColumn: "FuncaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Horario_HorarioContratadoId",
                        column: x => x.HorarioContratadoId,
                        principalTable: "Horario",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_Horario_HorarioPraticadoId",
                        column: x => x.HorarioPraticadoId,
                        principalTable: "Horario",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Uh_UhId",
                        column: x => x.UhId,
                        principalTable: "Uh",
                        principalColumn: "UhId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_CategoriaId",
                table: "Colaborador",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_ContratoId",
                table: "Colaborador",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_DepartamentoId",
                table: "Colaborador",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_EquipaId",
                table: "Colaborador",
                column: "EquipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_FuncaoId",
                table: "Colaborador",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_HorarioContratadoId",
                table: "Colaborador",
                column: "HorarioContratadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_HorarioPraticadoId",
                table: "Colaborador",
                column: "HorarioPraticadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_StatusId",
                table: "Colaborador",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_UhId",
                table: "Colaborador",
                column: "UhId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Equipa");

            migrationBuilder.DropTable(
                name: "Funcao");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Uh");
        }
    }
}
