using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Migrations.MywayDb
{
    public partial class Big : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assistencias",
                columns: table => new
                {
                    AssistenciaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoMensagem = table.Column<string>(maxLength: 6, nullable: false),
                    Aeroporto = table.Column<string>(maxLength: 4, nullable: false),
                    Notificacao = table.Column<string>(maxLength: 6, nullable: false),
                    HoraVoo = table.Column<DateTime>(nullable: false),
                    HoraContacto = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraFim = table.Column<DateTime>(nullable: false),
                    Voo = table.Column<string>(maxLength: 10, nullable: false),
                    Movimento = table.Column<string>(maxLength: 1, nullable: false),
                    OrigemDestino = table.Column<string>(maxLength: 6, nullable: false),
                    NomePax = table.Column<string>(maxLength: 150, nullable: false),
                    Tipologia = table.Column<string>(maxLength: 30, nullable: false),
                    Aircraft = table.Column<string>(maxLength: 3, nullable: false),
                    Stand = table.Column<string>(maxLength: 3, nullable: false),
                    Exit = table.Column<string>(maxLength: 1, nullable: true),
                    CheckIn = table.Column<string>(maxLength: 10, nullable: true),
                    Gate = table.Column<string>(maxLength: 5, nullable: true),
                    Transferencia = table.Column<string>(maxLength: 1, nullable: true),
                    Equipamentos = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistencias", x => x.AssistenciaId);
                });

            migrationBuilder.CreateTable(
                name: "BolsasHoras",
                columns: table => new
                {
                    BolsaHorasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColaboradorId = table.Column<int>(nullable: false),
                    BolsaHorasData = table.Column<DateTime>(nullable: false),
                    BolsaHorasTipo = table.Column<byte[]>(nullable: true),
                    BolsaHorasHoras = table.Column<int>(nullable: false),
                    BolsaHorasMinutos = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolsasHoras", x => x.BolsaHorasId);
                    table.ForeignKey(
                        name: "FK_BolsasHoras_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "ColaboradorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CargasHorarias",
                columns: table => new
                {
                    CargaHorariaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CargaHorariaDescricao = table.Column<string>(nullable: true),
                    CargaHorariaHoras = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargasHorarias", x => x.CargaHorariaId);
                });

            migrationBuilder.CreateTable(
                name: "CentrosCusto",
                columns: table => new
                {
                    CentroCustoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CentroCustoNum = table.Column<int>(nullable: false),
                    CentroCustoNome = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosCusto", x => x.CentroCustoId);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ContratoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContratoNome = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                });

            migrationBuilder.CreateTable(
                name: "DadosPessoais",
                columns: table => new
                {
                    DadosPessoaisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColaboradorId = table.Column<int>(nullable: false),
                    ColaboradorIdentificacao = table.Column<string>(nullable: true),
                    ColaboradorIdentificacaoValidade = table.Column<DateTime>(nullable: true),
                    DadosPessoaisMorada = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPessoais", x => x.DadosPessoaisId);
                    table.ForeignKey(
                        name: "FK_DadosPessoais_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "ColaboradorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formacoes",
                columns: table => new
                {
                    FormacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormacaoNome = table.Column<string>(nullable: true),
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
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FornecedorNome = table.Column<string>(nullable: true),
                    FornecedorMorada = table.Column<string>(nullable: true),
                    FornecedorContribuinte = table.Column<int>(nullable: true),
                    FornecedorTelefone = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "Observacoes",
                columns: table => new
                {
                    ObservacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColaboradorId = table.Column<int>(nullable: false),
                    ObservacaoTitulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacoes", x => x.ObservacaoId);
                    table.ForeignKey(
                        name: "FK_Observacoes_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "ColaboradorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resumos",
                columns: table => new
                {
                    ResumoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataResumo = table.Column<DateTime>(nullable: false),
                    StaffEscala = table.Column<int>(nullable: false),
                    StaffDuty = table.Column<int>(nullable: false),
                    TotalAssistencias = table.Column<int>(nullable: false),
                    IncumprimentosSla = table.Column<int>(nullable: false),
                    EquipamentosOkVta = table.Column<int>(nullable: false),
                    EquipamentosOkAmbulift = table.Column<int>(nullable: false),
                    EquipamentosInopVta = table.Column<int>(nullable: false),
                    EquipamentosInopAmbulift = table.Column<int>(nullable: false),
                    TotalVoos = table.Column<int>(nullable: false),
                    AtrasosImputados = table.Column<int>(nullable: false),
                    AtrasosAceites = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumos", x => x.ResumoId);
                });

            migrationBuilder.CreateTable(
                name: "Slas",
                columns: table => new
                {
                    SlaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSla = table.Column<DateTime>(nullable: false),
                    PcMenorIgual10 = table.Column<int>(nullable: false),
                    PcMaior10MenorIgual20 = table.Column<int>(nullable: false),
                    PcMaior20MenorIgual30 = table.Column<int>(nullable: false),
                    PcMaior30 = table.Column<int>(nullable: false),
                    PsMenorIgual25 = table.Column<int>(nullable: false),
                    PsMaior25MenorIgual35 = table.Column<int>(nullable: false),
                    PsMaior35MenorIgual45 = table.Column<int>(nullable: false),
                    PsMaior45 = table.Column<int>(nullable: false),
                    CcMenorIgual5 = table.Column<int>(nullable: false),
                    CcMaior5MenorIgual10 = table.Column<int>(nullable: false),
                    CcMaior10MenorIgual20 = table.Column<int>(nullable: false),
                    CcMaior20 = table.Column<int>(nullable: false),
                    CsMenorIgual25 = table.Column<int>(nullable: false),
                    CsMaior25MenorIgual35 = table.Column<int>(nullable: false),
                    CsMaior35MenorIgual45 = table.Column<int>(nullable: false),
                    CsMaior45 = table.Column<int>(nullable: false),
                    C90MenorIgual15 = table.Column<int>(nullable: false),
                    C90Maior15MenorIgual20 = table.Column<int>(nullable: false),
                    C90Maior20MenorIgual30 = table.Column<int>(nullable: false),
                    C90Maior30 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slas", x => x.SlaId);
                });

            migrationBuilder.CreateTable(
                name: "VinculosLaborais",
                columns: table => new
                {
                    VinculoLaboralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColaboradorId = table.Column<int>(nullable: false),
                    NumPw = table.Column<int>(nullable: true),
                    NumCartao = table.Column<int>(nullable: true),
                    CartaoValidade = table.Column<DateTime>(nullable: true),
                    ContratoId = table.Column<int>(nullable: false),
                    ContratoInicio = table.Column<DateTime>(nullable: true),
                    ContratoFim = table.Column<DateTime>(nullable: true),
                    CargaHorariaId = table.Column<int>(nullable: true),
                    CentroCustoId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculosLaborais", x => x.VinculoLaboralId);
                    table.ForeignKey(
                        name: "FK_VinculosLaborais_CargasHorarias_CargaHorariaId",
                        column: x => x.CargaHorariaId,
                        principalTable: "CargasHorarias",
                        principalColumn: "CargaHorariaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VinculosLaborais_CentrosCusto_CentroCustoId",
                        column: x => x.CentroCustoId,
                        principalTable: "CentrosCusto",
                        principalColumn: "CentroCustoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VinculosLaborais_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "ColaboradorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculosLaborais_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    EmailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DadosPessoaisId = table.Column<int>(nullable: false),
                    EmailEmail = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Emails_DadosPessoais_DadosPessoaisId",
                        column: x => x.DadosPessoaisId,
                        principalTable: "DadosPessoais",
                        principalColumn: "DadosPessoaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DadosPessoaisId = table.Column<int>(nullable: false),
                    TelefoneNumero = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.TelefoneId);
                    table.ForeignKey(
                        name: "FK_Telefones_DadosPessoais_DadosPessoaisId",
                        column: x => x.DadosPessoaisId,
                        principalTable: "DadosPessoais",
                        principalColumn: "DadosPessoaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormacoesColaboradores",
                columns: table => new
                {
                    FormacaoColaboradorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormacaoId = table.Column<int>(nullable: false),
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
                        name: "FK_FormacoesColaboradores_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "ColaboradorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormacoesColaboradores_Formacoes_FormacaoId",
                        column: x => x.FormacaoId,
                        principalTable: "Formacoes",
                        principalColumn: "FormacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    FaturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CentroCustoId = table.Column<int>(nullable: true),
                    FornecedorId = table.Column<int>(nullable: false),
                    FaturaTipo = table.Column<byte[]>(nullable: true),
                    FaturaNum = table.Column<string>(nullable: true),
                    FaturaValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => x.FaturaId);
                    table.ForeignKey(
                        name: "FK_Faturas_CentrosCusto_CentroCustoId",
                        column: x => x.CentroCustoId,
                        principalTable: "CentrosCusto",
                        principalColumn: "CentroCustoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faturas_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BolsasHoras_ColaboradorId",
                table: "BolsasHoras",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosPessoais_ColaboradorId",
                table: "DadosPessoais",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_DadosPessoaisId",
                table: "Emails",
                column: "DadosPessoaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturas_CentroCustoId",
                table: "Faturas",
                column: "CentroCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturas_FornecedorId",
                table: "Faturas",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_FormacoesColaboradores_ColaboradorId",
                table: "FormacoesColaboradores",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_FormacoesColaboradores_FormacaoId",
                table: "FormacoesColaboradores",
                column: "FormacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacoes_ColaboradorId",
                table: "Observacoes",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_DadosPessoaisId",
                table: "Telefones",
                column: "DadosPessoaisId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculosLaborais_CargaHorariaId",
                table: "VinculosLaborais",
                column: "CargaHorariaId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculosLaborais_CentroCustoId",
                table: "VinculosLaborais",
                column: "CentroCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculosLaborais_ColaboradorId",
                table: "VinculosLaborais",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculosLaborais_ContratoId",
                table: "VinculosLaborais",
                column: "ContratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistencias");

            migrationBuilder.DropTable(
                name: "BolsasHoras");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Faturas");

            migrationBuilder.DropTable(
                name: "FormacoesColaboradores");

            migrationBuilder.DropTable(
                name: "Observacoes");

            migrationBuilder.DropTable(
                name: "Resumos");

            migrationBuilder.DropTable(
                name: "Slas");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "VinculosLaborais");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Formacoes");

            migrationBuilder.DropTable(
                name: "DadosPessoais");

            migrationBuilder.DropTable(
                name: "CargasHorarias");

            migrationBuilder.DropTable(
                name: "CentrosCusto");

            migrationBuilder.DropTable(
                name: "Contratos");
        }
    }
}
