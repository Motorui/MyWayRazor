using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class AddTablesForAnalise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssistenciasPRMS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aeroporto = table.Column<string>(nullable: true),
                    Msg = table.Column<string>(nullable: true),
                    Notif = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Voo = table.Column<string>(nullable: false),
                    Mov = table.Column<string>(nullable: true),
                    OrigDest = table.Column<string>(nullable: true),
                    Pax = table.Column<string>(nullable: false),
                    SSR = table.Column<string>(nullable: true),
                    AC = table.Column<string>(nullable: true),
                    Stand = table.Column<string>(nullable: true),
                    Exit = table.Column<string>(nullable: true),
                    CkIn = table.Column<string>(nullable: true),
                    Gate = table.Column<string>(nullable: true),
                    Transferencia = table.Column<string>(nullable: true),
                    HoraEmbarque = table.Column<DateTime>(nullable: false),
                    SaidaStaging = table.Column<DateTime>(nullable: false),
                    EstimaApresentacao = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistenciasPRMS", x => x.ID);
                });

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
                name: "Parametros",
                columns: table => new
                {
                    ParamID = table.Column<string>(nullable: false),
                    ParamNome = table.Column<string>(nullable: false),
                    ParamDesc = table.Column<string>(nullable: false),
                    ParamValue = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.ParamID);
                });

            migrationBuilder.CreateTable(
                name: "Piers",
                columns: table => new
                {
                    PierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PierNome = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piers", x => x.PierID);
                });

            migrationBuilder.CreateTable(
                name: "Plataformas",
                columns: table => new
                {
                    PlataformaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlataformaN = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataformas", x => x.PlataformaId);
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
                name: "ToDos",
                columns: table => new
                {
                    ToDoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ToDoTittle = table.Column<string>(nullable: false),
                    ToDoText = table.Column<string>(nullable: false),
                    Done = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ToDoId);
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
                name: "Portas",
                columns: table => new
                {
                    PortaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PortaNum = table.Column<string>(nullable: false),
                    PortaTempo = table.Column<int>(nullable: false),
                    Schengen = table.Column<bool>(nullable: false),
                    Terminal = table.Column<bool>(nullable: false),
                    Remoto = table.Column<bool>(nullable: false),
                    PierID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portas", x => x.PortaID);
                    table.ForeignKey(
                        name: "FK_Portas_Piers_PierID",
                        column: x => x.PierID,
                        principalTable: "Piers",
                        principalColumn: "PierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stands",
                columns: table => new
                {
                    StandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StandN = table.Column<int>(nullable: false),
                    Remoto = table.Column<bool>(nullable: false),
                    PlataformaId = table.Column<int>(nullable: false),
                    PierID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stands", x => x.StandId);
                    table.ForeignKey(
                        name: "FK_Stands_Piers_PierID",
                        column: x => x.PierID,
                        principalTable: "Piers",
                        principalColumn: "PierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stands_Plataformas_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataformas",
                        principalColumn: "PlataformaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stagings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Msg = table.Column<string>(nullable: true),
                    Notif = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Voo = table.Column<string>(nullable: false),
                    Mov = table.Column<string>(nullable: true),
                    OrigemDestino = table.Column<string>(nullable: true),
                    Pax = table.Column<string>(nullable: false),
                    Ssr = table.Column<string>(nullable: true),
                    AirCraft = table.Column<string>(nullable: true),
                    Stand = table.Column<string>(nullable: true),
                    CheckIn = table.Column<string>(nullable: true),
                    Gate = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Etd = table.Column<DateTime>(nullable: false),
                    HoraEmbarque = table.Column<DateTime>(nullable: false),
                    SaidaStaging = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Destino = table.Column<bool>(nullable: false),
                    Alerta = table.Column<bool>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stagings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stagings_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
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
                    DataAdmissao = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    ContratoId = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
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
                        name: "FK_Colaborador_Uh_UhId",
                        column: x => x.UhId,
                        principalTable: "Uh",
                        principalColumn: "UhId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "CategoriaNome", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[,]
                {
                    { 1, "ASSISTENTE A PASSAGEIROS DE MOBILIDADE REDUZIDA", new DateTime(2018, 10, 25, 11, 23, 36, 413, DateTimeKind.Unspecified).AddTicks(6761), "SISTEMA", null, null },
                    { 2, "TECNICO TRAFEGO ASSISTENCIA ESCALA", new DateTime(2018, 10, 25, 11, 23, 36, 475, DateTimeKind.Unspecified).AddTicks(8668), "SISTEMA", null, null },
                    { 3, "OPERADOR ASSISTENCIA ESCALA", new DateTime(2018, 10, 25, 11, 23, 36, 515, DateTimeKind.Unspecified).AddTicks(6390), "SISTEMA", null, null },
                    { 4, "TECNICO", new DateTime(2018, 10, 25, 11, 23, 36, 565, DateTimeKind.Unspecified).AddTicks(6321), "SISTEMA", null, null }
                });

            migrationBuilder.InsertData(
                table: "Contrato",
                columns: new[] { "ContratoId", "ContratoTipo", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[,]
                {
                    { 1, "PERMANENTE", new DateTime(2018, 10, 25, 11, 23, 36, 637, DateTimeKind.Unspecified).AddTicks(1940), "SISTEMA", null, null },
                    { 2, "TERMO CERTO", new DateTime(2018, 10, 25, 11, 23, 36, 712, DateTimeKind.Unspecified).AddTicks(1040), "SISTEMA", null, null },
                    { 3, "TERMO INCERTO", new DateTime(2018, 10, 25, 11, 23, 36, 794, DateTimeKind.Unspecified).AddTicks(3570), "SISTEMA", null, null },
                    { 4, "MULTITEMPO", new DateTime(2018, 10, 25, 11, 23, 36, 892, DateTimeKind.Unspecified).AddTicks(9403), "SISTEMA", null, null }
                });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "DepartamentoId", "CreatedAt", "CreatedBy", "DepartamentoNome", "DepartamentoNumero", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[] { 1, new DateTime(2018, 10, 25, 11, 23, 37, 6, DateTimeKind.Unspecified).AddTicks(4466), "SISTEMA", "Lisboa - PMRs", 71680, null, null });

            migrationBuilder.InsertData(
                table: "Equipa",
                columns: new[] { "EquipaId", "CreatedAt", "CreatedBy", "EquipaNome", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[,]
                {
                    { 3, new DateTime(2018, 10, 25, 11, 23, 37, 387, DateTimeKind.Unspecified).AddTicks(4794), "SISTEMA", "B", null, null },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 37, 523, DateTimeKind.Unspecified).AddTicks(7759), "SISTEMA", "C", null, null },
                    { 1, new DateTime(2018, 10, 25, 11, 23, 37, 137, DateTimeKind.Unspecified).AddTicks(1391), "SISTEMA", "N/A", null, null },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 37, 257, DateTimeKind.Unspecified).AddTicks(725), "SISTEMA", "A", null, null }
                });

            migrationBuilder.InsertData(
                table: "Funcao",
                columns: new[] { "FuncaoId", "CreatedAt", "CreatedBy", "FuncaoNome", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 25, 11, 23, 37, 682, DateTimeKind.Unspecified).AddTicks(4260), "SISTEMA", "COORDENADOR", null, null },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 37, 847, DateTimeKind.Unspecified).AddTicks(417), "SISTEMA", "ASSISTENTE ADMINISTRATIVA", null, null },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 38, 13, DateTimeKind.Unspecified).AddTicks(4061), "SISTEMA", "SUPERVISOR", null, null },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 38, 188, DateTimeKind.Unspecified).AddTicks(5485), "SISTEMA", "ALOCADOR", null, null },
                    { 5, new DateTime(2018, 10, 25, 11, 23, 38, 377, DateTimeKind.Unspecified).AddTicks(2507), "SISTEMA", "ASSISTENTE PMR", null, null },
                    { 6, new DateTime(2018, 10, 25, 11, 23, 38, 572, DateTimeKind.Unspecified).AddTicks(7291), "SISTEMA", "ASSISTENTE PMR PART-TIME", null, null },
                    { 7, new DateTime(2018, 10, 25, 11, 23, 38, 780, DateTimeKind.Unspecified).AddTicks(8562), "SISTEMA", "MOTORISTA", null, null },
                    { 8, new DateTime(2018, 10, 25, 11, 23, 38, 997, DateTimeKind.Unspecified).AddTicks(5488), "SISTEMA", "MOTORISTA AMBULIFT", null, null },
                    { 9, new DateTime(2018, 10, 25, 11, 23, 39, 222, DateTimeKind.Unspecified).AddTicks(6702), "SISTEMA", "PLANEAMENTO", null, null },
                    { 10, new DateTime(2018, 10, 25, 11, 23, 39, 461, DateTimeKind.Unspecified).AddTicks(6495), "SISTEMA", "QUALIDADE", null, null }
                });

            migrationBuilder.InsertData(
                table: "Horario",
                columns: new[] { "HorarioId", "CreatedAt", "CreatedBy", "HorarioHora", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[,]
                {
                    { 6, new DateTime(2018, 10, 25, 11, 23, 41, 98, DateTimeKind.Unspecified).AddTicks(7970), "SISTEMA", 18, null, null },
                    { 7, new DateTime(2018, 10, 25, 11, 23, 41, 413, DateTimeKind.Unspecified).AddTicks(8488), "SISTEMA", 12, null, null },
                    { 5, new DateTime(2018, 10, 25, 11, 23, 40, 800, DateTimeKind.Unspecified).AddTicks(3868), "SISTEMA", 20, null, null },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 40, 518, DateTimeKind.Unspecified).AddTicks(3892), "SISTEMA", 25, null, null },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 40, 241, DateTimeKind.Unspecified).AddTicks(7707), "SISTEMA", 36, null, null },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 39, 977, DateTimeKind.Unspecified).AddTicks(9922), "SISTEMA", 38, null, null },
                    { 1, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", 40, null, null }
                });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "ParamID", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "ParamDesc", "ParamNome", "ParamValue" },
                values: new object[,]
                {
                    { "1", new DateTime(2019, 2, 26, 15, 35, 0, 0, DateTimeKind.Unspecified), "SISTEMA", null, null, "Chegada PAX Schengen ao aeroporto", "CPS", 0 },
                    { "2", new DateTime(2019, 2, 26, 15, 35, 0, 0, DateTimeKind.Unspecified), "SISTEMA", null, null, "Chegada PAX Não Schengen ao aeroporto", "CPN", 0 }
                });

            migrationBuilder.InsertData(
                table: "Piers",
                columns: new[] { "PierID", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "PierNome" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Pier Sul" },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Pier Norte" },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Pier 14" },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Terminal 2" },
                    { 5, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Remoto" }
                });

            migrationBuilder.InsertData(
                table: "Plataformas",
                columns: new[] { "PlataformaId", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "PlataformaN" },
                values: new object[,]
                {
                    { 6, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas70a80" },
                    { 5, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas41a60" },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas30a40" },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas22" },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas20" },
                    { 1, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas10a14" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusID", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "Statuses" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "" },
                    { 2, null, null, null, null, "Espera" },
                    { 3, null, null, null, null, "Cancelado" },
                    { 4, null, null, null, null, "Encaminhado" },
                    { 5, null, null, null, null, "Finalizado" },
                    { 6, null, null, null, null, "Ausente" }
                });

            migrationBuilder.InsertData(
                table: "Uh",
                columns: new[] { "UhId", "CreatedAt", "CreatedBy", "IATA", "LastUpdatedAt", "LastUpdatedBy", "UhNome" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 25, 11, 23, 42, 437, DateTimeKind.Unspecified).AddTicks(1089), "SISTEMA", "LIS", null, null, "LISBOA" },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 42, 784, DateTimeKind.Unspecified).AddTicks(4907), "SISTEMA", "OPO", null, null, "PORTO" },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 43, 144, DateTimeKind.Unspecified).AddTicks(8285), "SISTEMA", "FAO", null, null, "FARO" },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 43, 537, DateTimeKind.Unspecified).AddTicks(6776), "SISTEMA", "FNC", null, null, "FUNCHAL" }
                });

            migrationBuilder.InsertData(
                table: "Colaborador",
                columns: new[] { "ColaboradorID", "Ativo", "CategoriaId", "ContratoId", "CreatedAt", "CreatedBy", "DataAdmissao", "DataFim", "DepartamentoId", "EquipaId", "FuncaoId", "HorarioContratadoId", "HorarioPraticadoId", "LastUpdatedAt", "LastUpdatedBy", "Nome", "NumCartao", "NumPw", "UhId" },
                values: new object[,]
                {
                    { 53, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2013, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "RUI PEDRO DE OLIVEIRA CARDOSO", 46699, 5758, 1 },
                    { 124, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "ANDRE FILIPE VENTURA", 77817, 9201359, 1 },
                    { 123, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "ANDRE BENTO VERDE", 81243, 9201534, 1 },
                    { 122, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "ANABELA FERNANDES CONCEIÇÃO", 80415, 9201464, 1 },
                    { 121, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 1, 1, null, "", "ANA RITA PEIXOTO DA COSTA PEREIRA DA SILVA", 99, 99, 1 },
                    { 120, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "ANA PAULA DA RIBEIRA RAMOS", 81179, 9201493, 1 },
                    { 119, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "ANA FILIPA SILVA RODRIGUES PEREIRA", 81022, 9201492, 1 },
                    { 118, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 1, 4, null, "", "ANA FILIPA MARTINHO RAMOS", 77774, 9201358, 1 },
                    { 117, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "ANA CATARINA DA FONSECA FERNANDES", 99, 99, 1 },
                    { 116, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "AMILCAR JORGE COIMBRA DOS SANTOS", 81242, 9201528, 1 },
                    { 125, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "ANDRE MORAIS CARNEIRO", 71289, 9201300, 1 },
                    { 115, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "ALINE PEREZ GARCIA", 76802, 9201303, 1 },
                    { 113, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 1, 1, null, "", "TIAGO FILIPE DE BARROS MORAIS LINHARES", 37095, 5014, 1 },
                    { 112, false, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "RUI SAMUEL VENANCIO LEITÃO", 36922, 5013, 1 },
                    { 111, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2005, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 6, 2, null, "", "RUI ALEXANDRE ALVES PEREIRA", 24899, 4065, 1 },
                    { 110, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2007, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 6, 2, null, "", "RICARDO JOSÉ RIBEIRO DOS SANTOS", 28030, 4500, 1 },
                    { 109, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 1, 1, null, "", "RICARDO JORGE MARQUES BARROCAS", 37066, 5010, 1 },
                    { 108, false, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2013, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "PAULO JORGE DE OLIVEIRA SANTOS", 46781, 5669, 1 },
                    { 107, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 10, 6, 2, null, "", "PAULO FABRICIO VIEIRA MENEZES CATANHO", 99, 6425, 1 },
                    { 106, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "NUNO RICARDO MONTEIRO LOPES", 37069, 5006, 1 },
                    { 105, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "MIGUEL FILIPE PACHECO ELIAS", 23989, 5003, 1 },
                    { 114, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "VALDEMIRO VEIGA FERNANDES", 45373, 5015, 1 },
                    { 126, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 6, 4, 4, null, "", "ANGELA SOFIA GOMES FERREIRA", 99, 99, 1 },
                    { 127, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "ANTONIO JOSE PEREIRA RAMALHO", 75315, 9201215, 1 },
                    { 128, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "ANTÓNIO JOSÉ RIBEIRO MARQUES", 53548, 9200965, 1 },
                    { 149, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 1, 1, null, "", "DIOGO PIRES", 99, 99, 1 },
                    { 148, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "DIOGO MIGUEL ROSARIO ALMEIDA", 81306, 9201530, 1 },
                    { 147, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "DIOGO FILIPE DE PINHO MENDES MIRANDA", 77359, 9201332, 1 },
                    { 146, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "DEISY IRINA VEIGA DE FERNANDES DA SILVA", 80417, 9201495, 1 },
                    { 145, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "DAVID LUÍS ALVES NOBRE", 76718, 9201282, 1 },
                    { 144, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "DAVID JOSE AMARO MADEIRA", 77559, 9201320, 1 },
                    { 143, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "DAVID EMANUEL CONDE BARROS", 58743, 9201270, 1 },
                    { 142, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "DALILA MARIA FERREIRA MARCÃO", 81304, 9201625, 1 },
                    { 141, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "CLAUDIA CRISTINA RODRIGUES MARQUES", 81916, 9201548, 1 },
                    { 140, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "CATARINA PEREIRA BUAL VALENTE SALVADO", 81067, 9201520, 1 },
                    { 139, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "CATARINA LUISA BRAGA BATISTA", 99, 99, 1 },
                    { 138, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "CATARINA FILIPE CID SIMOES", 76571, 9201271, 1 },
                    { 137, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "CATARINA FILIPA MARQUES PEREIRA", 81302, 9201527, 1 },
                    { 136, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "CAROLINA CARDOSO FERREIRA CHAVES", 78309, 9201390, 1 },
                    { 135, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "BRUNO RAFAEL BARRADAS AFONSO", 80737, 9201474, 1 },
                    { 134, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "BRUNO DA COSTA ALBUQUERQUE", 80736, 9201508, 1 },
                    { 133, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "BRUNA ANDREIA DA CONCEIÇÃO HENRIQUES", 80781, 9201507, 1 },
                    { 132, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "BRENO MICAEL GODINHO FILIPE", 82043, 9201549, 1 },
                    { 131, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "BERNARDO MIGUEL TOMAS CORREIA", 99, 99, 1 },
                    { 130, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "ANTÓNIO TOVAR DE CARVALHO PATRICIO", 80831, 9201494, 1 },
                    { 129, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "ANTÓNIO MIGUEL DE MATOS PINTO", 75812, 9201231, 1 },
                    { 104, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, 6, 1, null, "", "MARIA DA CONCEIÇÃO SANTOS PEREIRA RODRIGUES", 99, 5064, 1 },
                    { 150, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "DIONISIO SERGIO DE MATOS VALENTE GONÇALVES", 77361, 9201324, 1 },
                    { 103, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2009, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 5, 1, null, "", "MARCO PAULO DE ANDRADE RODRIGUES", 33948, 4840, 1 },
                    { 101, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 3, 2, null, "", "MANUEL FRANCISCO CORREIA MATA LANÇA", 633, 3010, 1 },
                    { 75, false, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "MÁRCIO IVO FERNANDES DOS SANTOS", 58450, 8223, 1 },
                    { 74, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "LEANDRO DE SOUSA MARTINS", 71831, 8298, 1 },
                    { 73, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "JORGE MANUEL TEIXEIRA NETO", 70452, 8297, 1 },
                    { 72, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 6, 1, null, "", "JOÃO JOSÉ HORTA NOBRE", 58439, 6811, 1 },
                    { 71, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "HUGO MIGUEL RODRIGUES MENDES", 71826, 8319, 1 },
                    { 70, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "HÉLIO MIGUEL MAGALHAES BARBOSA", 49732, 8338, 1 },
                    { 69, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 1, 1, null, "", "GONÇALO LOPES FONSECA", 71824, 8295, 1 },
                    { 68, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "EDILSON CARLOS BORGES BARROS SILVA", 71903, 8337, 1 },
                    { 67, false, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "DENISE ALEXANDRA MADUENO FERNANDES", 58443, 8222, 1 },
                    { 76, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "PAULO JORGE ANTUNES DA SILVA", 58452, 8325, 1 },
                    { 66, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "ANDRÉ DE SOUSA FARIA COSTA", 71821, 8324, 1 },
                    { 64, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "WILLIAM SILVA GOMES JUNIOR", 46212, 6601, 1 },
                    { 63, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 7, 1, null, "", "VITOR HUGO CARRILHO DA SILVA", 43826, 5379, 1 },
                    { 62, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 6, 1, null, "", "VASCO ANDRÉ FIGUEIREDO DA SILVA", 46137, 6624, 1 },
                    { 61, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 7, 1, null, "", "TIAGO PIMENTA CORTEGAÇA", 48887, 6065, 1 },
                    { 60, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2013, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "TIAGO LUIS FERRÃO DA SILVA", 43825, 5419, 1 },
                    { 59, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 1, null, "", "SUSANA CRISTINA PEREIRA DA LUZ", 52180, 6763, 1 },
                    { 58, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 1, null, "", "SÉRGIO MIGUEL MARIA PEREIRA", 52177, 6764, 1 },
                    { 57, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "SERGIO MIGUEL DOS SANTOS HENRIQUE", 42778, 5328, 1 },
                    { 56, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "SÉRGIO LUÍS BRITO FARINHA", 51721, 6600, 1 },
                    { 65, true, 4, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 9, 2, 2, null, "", "ANA RITA DE MELO SANTOS DA CRUZ", 99, 8356, 1 },
                    { 77, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "PAULO JORGE DE AGUAIR ROSALIS", 71104, 8336, 1 },
                    { 78, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "PAULO JORGE DE BRITO DUARTE", 47309, 8355, 1 },
                    { 79, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 1, 1, null, "", "PAULO JORGE MILEU TEIXEIRA", 71105, 8226, 1 },
                    { 100, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "JULIO AUGUSTO DA CRUZ", 37011, 5001, 1 },
                    { 99, false, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1985, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 3, 2, null, "", "JOSÉ MANUEL CARDOSO DA COSTA LEONARDO", 3902, 2062, 1 },
                    { 98, false, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1984, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 3, 2, null, "", "JOSÉ ANTÓNIO DIAS CRUZ", 629, 2055, 1 },
                    { 97, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1995, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 3, 2, null, "", "JOÃO MANUEL SIMÃO CARRILHO", 1171, 2045, 1 },
                    { 96, true, 3, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 3, 2, null, "", "JOÃO DANIEL ALÍPIO GUERREIRO TEOTÓNIO", 13122, 3258, 1 },
                    { 95, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2011, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 5, 1, null, "", "JOAO CARLOS QUITERIO ALVES", 36882, 5097, 1 },
                    { 94, false, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "IVAN DANIEL LOURENÇO GARCIA CORREIA", 37062, 4999, 1 },
                    { 93, true, 3, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2001, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 3, 2, null, "", "GHEORGHE ADELIN MEDISAN", 14643, 3445, 1 },
                    { 92, false, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "ELDER CARLOS BORGES", 36414, 5025, 1 },
                    { 91, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "BUBACAR DJASSI", 37107, 4980, 1 },
                    { 90, false, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "BRUNO MIGUEL CARDOSO BATISTA", 37093, 4964, 1 },
                    { 89, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "BRUNO DANIEL VEIGA MIRA", 37100, 4975, 1 },
                    { 88, true, 3, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 3, 2, null, "", "ANTÓNIO FERNANDO LOPES FIDALGO", 1143, 2013, 1 },
                    { 87, false, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "ANGELO CARLOS SIXPENCE CAZANÇA", 37126, 4979, 1 },
                    { 86, true, 2, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 7, 1, null, "", "ALEXANDRE PEREIRA RAPOSO", 40512, 5212, 1 },
                    { 85, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "VÍTOR MANUEL DOS SANTOS LAMEIRAS", 54236, 8317, 1 },
                    { 84, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "VERA MÓNICA MOREIRA MARTINS", 71106, 8227, 1 },
                    { 83, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "SÍLVIA CARLA MIRANDA DE SOUSA", 55249, 8294, 1 },
                    { 82, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "RICARDO RUA SOL", 58167, 8224, 1 },
                    { 81, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "PEDRO DIOGO DOS SANTOS AMARAL", 71841, 6102, 1 },
                    { 80, true, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "PEDRO CARVALHO SANDE", 51401, 8229, 1 },
                    { 102, true, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "MARCO ANTONIO SILVA FRAGOSO", 36920, 5002, 1 },
                    { 151, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "DORA MARISA RIBEIRO", 75318, 9201197, 1 },
                    { 152, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "DULCE MARIA FIALHO DA SILVA SILVA", 80742, 9201467, 1 },
                    { 153, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "ELISIO MIGUEL SEMEDO SOARES", 99, 99, 1 },
                    { 224, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "PEDRO TELMO FERNANDES COSTA", 51651, 9201168, 1 },
                    { 223, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 7, 1, 1, null, "", "PEDRO RICARDO ROCHA FERRO PIRES", 99, 99, 1 },
                    { 222, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "PEDRO DUARTE DOS SANTOS BARQUINHA", 81327, 9201626, 1 },
                    { 221, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "PEDRO CELESTINO SOARES DE OLIVEIRA PINTO", 99, 99, 1 },
                    { 220, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "PEDRO ALEXANDRE MARTINS NETO RIBEIRO", 35849, 9201415, 1 },
                    { 219, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "PAULO JOSÉ MIGUEL RIBEIRO", 75317, 9201229, 1 },
                    { 218, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "PATRICIA ALEXANDRA DE JESUS COELHO", 80440, 9201466, 1 },
                    { 217, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "NUNO MIGUEL MORAIS DE ALMEIDA", 81326, 9201531, 1 },
                    { 216, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "NUNO MIGUEL BUGADA PINTO", 31157, 9201009, 1 },
                    { 225, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "RAFAEL MARQUES ESTANQUE", 72737, 9201264, 1 },
                    { 215, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "NUNO FILIPE VIEIRA CUSTODIO", 81987, 9201545, 1 }
                });

            migrationBuilder.InsertData(
                table: "Colaborador",
                columns: new[] { "ColaboradorID", "Ativo", "CategoriaId", "ContratoId", "CreatedAt", "CreatedBy", "DataAdmissao", "DataFim", "DepartamentoId", "EquipaId", "FuncaoId", "HorarioContratadoId", "HorarioPraticadoId", "LastUpdatedAt", "LastUpdatedBy", "Nome", "NumCartao", "NumPw", "UhId" },
                values: new object[,]
                {
                    { 213, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "NUNO ANDRÉ CORDEIRO DE SOUSA", 73830, 9201184, 1 },
                    { 212, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "NILTON ALEXANDRE BRITO", 81933, 9201542, 1 },
                    { 211, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "NELSON FILIPE CONCEIÇÃO CARVALHO", 81931, 9201551, 1 },
                    { 210, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "NELSON BONITO PITA", 81325, 9201524, 1 },
                    { 209, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "NANCY SANTOS BALCÃO", 58451, 9201028, 1 },
                    { 208, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "MONICA SOFIA SANTOS FERREIRA TRINDADE", 76680, 9201267, 1 },
                    { 207, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "MIGUEL LOURENÇO GERALDES FREIRE DE CARVALHO", 80759, 9201504, 1 },
                    { 206, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "MIGUEL CONSOLADO OLIVEIRA", 71840, 9201104, 1 },
                    { 205, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 1, 1, null, "", "MIGUEL ALEXANDRE TEIXEIRA COUTINHO", 76570, 9201281, 1 },
                    { 214, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "NUNO FILIPE DINIZ RAIMUNDO", 75311, 9201242, 1 },
                    { 226, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "RAQUEL ALEXANDRA SILVA", 75300, 9201200, 1 },
                    { 227, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "RUI FILIPE FERNANDES PAULINO", 75682, 9201249, 1 },
                    { 228, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "RUI MANUEL SOUSA PINTO", 80441, 9201505, 1 },
                    { 249, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "VERA LUCIA CARDOSO MARTINS DA SILVA", 99, 99, 1 },
                    { 248, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "VASCO RAFAEL SIMÃO DA SILVA RAMOS", 99, 99, 1 },
                    { 247, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "VASCO RAFAEL CORDEIRO MARTINS TAPADAS", 81148, 9201463, 1 },
                    { 246, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 4, 4, null, "", "VANESSA CRISTINA DA PONTE PAJUEL NUNES", 99, 99, 1 },
                    { 245, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "TIAGO MIGUEL SOUSA ALVES", 77377, 9201331, 1 },
                    { 244, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "TIAGO FILIPE DA SILVA GUERREIRO", 76569, 9201278, 1 },
                    { 243, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "TIAGO FERREIRA RAIMUNDO", 81330, 9201529, 1 },
                    { 242, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "TIAGO FERREIRA MANGAS DUARTE JORGE", 76565, 9201276, 1 },
                    { 241, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "TIAGO FERNANDO MORAIS DA CUNHA FIGUEIRA", 99, 99, 1 },
                    { 240, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "Susana Trindade M. Raimundo Silva", 77806, 9201357, 1 },
                    { 239, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "SERGIO MIGUEL SILVA HENRIQUES", 82011, 9201541, 1 },
                    { 238, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 1, 1, null, "", "SÉRGIO EDUARDO MOUTINHO DA SILVA CASTANHO CANDEIAS", 99, 99, 1 },
                    { 237, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "SERGIO BRUNO VELHO VANDER KELLEN", 81953, 9201546, 1 },
                    { 236, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "SARA RAQUEL MARTINHO FERNANDES", 81329, 9201519, 1 },
                    { 235, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "SARA DIAS AFONSO", 76575, 9201266, 1 },
                    { 234, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "SARA CATARINA DOS SANTOS AREDE", 80442, 9201506, 1 },
                    { 233, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "SANDRA PATRICIA DE ALMEIDA LOPES FERREIRA", 76564, 9201279, 1 },
                    { 232, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "Rute Maria Dinis Costa", 78331, 9201385, 1 },
                    { 231, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "Rui Ricardo dos Santos Pereira Dias  ", 71941, 9201084, 1 },
                    { 230, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "RUI MIGUEL REMIGIO DA CRUZ BENTO", 81139, 9201533, 1 },
                    { 229, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "Rui Miguel A. C. Afonso Madeira", 77414, 9201356, 1 },
                    { 204, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "MAURO ANDRÉ CRUZ DIAS", 74430, 9201185, 1 },
                    { 203, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "MARTA INES RIBEIRO DA SILVA", 80474, 9201475, 1 },
                    { 202, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "MARTA ALEXANDRA MALVEIRO DA SILVA", 99, 99, 1 },
                    { 201, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "MARIANA CAETANO FERNANDES", 99, 99, 1 },
                    { 174, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "JESSICA ANDREIA CALADO COSTA", 77372, 9201328, 1 },
                    { 173, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "IVO RAFAEL HENRINQUES RAMOS", 72254, 9201171, 1 },
                    { 172, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "IVAN EMANUEL ARRULO PEDROSO DA SILVA", 80748, 9201498, 1 },
                    { 171, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 1, 1, null, "", "Isabel Maria Nobre Batata", 77413, 9201321, 1 },
                    { 170, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "HUGO ALEXANDRE FERREIRA LOPES", 77365, 9201322, 1 },
                    { 169, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "HELTON ANDRADE D'SANTANA", 76418, 9201327, 1 },
                    { 168, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "HELIBERTO EDUARDO QUARESMA CASTRO", 81315, 9201525, 1 },
                    { 167, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 1, 1, null, "", "GONÇALO SILVA SANTA BARBARA", 57800, 9201277, 1 },
                    { 166, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "GONÇALO MADEIRA CARDOSO BRITO", 74417, 9201175, 1 },
                    { 165, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "GONÇALO CARLOS DE BRITO BRAVO GUIMARAES CABANELAS", 81314, 9201521, 1 },
                    { 164, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "FREDERICO MIGUEL DUARTE ROSA", 77362, 9201326, 1 },
                    { 163, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "FREDERICO EMANUEL RIBEIRO CARVALHINHO", 80745, 9201487, 1 },
                    { 162, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "FRANCISCO MANUEL ABREU PEREIRA", 58414, 9201522, 1 },
                    { 161, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "FLÁVIA SANTOS TAMBELINI", 80477, 9201497, 1 },
                    { 160, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "FILIPE ANDRÉ PEREIRA PINTO DA PALMA CORDEIRO", 48592, 9200967, 1 },
                    { 159, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "FERDINANDO DIAMANTINO RODRIGUES DE MATOS", 46443, 9201465, 1 },
                    { 158, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "FÁBIO MIGUEL BERRONES CARDOSO", 80429, 9201496, 1 },
                    { 157, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "FABIO JORGE SILVA SANTOS", 53532, 9201250, 1 },
                    { 156, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "FÁBIO EMANUEL FLORES RESENDE AMARAL", 59727, 9201693, 1 },
                    { 155, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "EUGENIO HENRIQUES AGOSTINHO LOPES RIBEIRO", 79395, 9201422, 1 },
                    { 154, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "EMERSON JORGE LOPES DO ROSÁRIO SEQUEIRA", 75700, 9201230, 1 },
                    { 175, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "JESSICA FILIPA PEREIRA RODRIGUES", 81068, 9201499, 1 },
                    { 55, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 5, 1, null, "", "SÉRGIO FILIPE GOMES RODRIGUES", 53549, 6812, 1 },
                    { 176, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "JESSICA SOUSA SANTOS", 76719, 9201298, 1 },
                    { 178, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "JOÃO CARLOS MADUREIRA GOMES", 99, 99, 1 },
                    { 200, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "MARIA USURELU", 76701, 9201273, 1 },
                    { 199, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "MARIA TERESA CALADO AMADO MARTINS CORREIA", 81929, 9201543, 1 },
                    { 198, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "Maria Helena Prazeres Vanez Paula", 74432, 9201177, 1 },
                    { 197, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "MARIA DE LURDES OLIVEIRA RIBEIRO", 81322, 9201523, 1 },
                    { 195, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "LUISA FORTUNATO FERREIRA", 81073, 9201532, 1 },
                    { 194, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "LUIS MIGUEL SEGURA DA SILVA", 75933, 9201503, 1 },
                    { 193, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "LUIS MIGUEL MARTINS LOPES", 99, 99, 1 },
                    { 192, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "LUIS MIGUEL GUEIFÃO GODINHO", 80785, 9201502, 1 },
                    { 191, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "LEONARDO SANTOS GOMES", 51650, 9201176, 1 },
                    { 190, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "LEE NATHAN SERENO", 74420, 9200118, 1 },
                    { 189, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "LEANDRA SOFIA MORAR NUNES", 55772, 9201692, 1 },
                    { 188, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "LARYSSA DE RESENDE LEMOS", 77472, 9201329, 1 },
                    { 187, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "Karen Andreina Jardin Rojas", 99, 99, 1 },
                    { 186, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "JULIO CESAR RODRIGUES RIBEIRO", 81926, 9201544, 1 },
                    { 185, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "JULIANA MORENO ESPOSITO", 83339, 9201670, 1 },
                    { 184, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "JOJO ANTHONY SABERON MONTANO", 81174, 9201501, 1 },
                    { 183, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "JOAO PAULO POÇAS DE CARVALHO E OLIVEIRA", 76732, 9201274, 1 },
                    { 182, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "JOAO PAULO CARDOSO RODRIGUES", 76721, 9201305, 1 },
                    { 181, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 7, 1, 1, null, "", "JOAO FERNANDO LAGUGAS MORAIS", 99, 99, 1 },
                    { 180, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "JOÃO DE DEUS PEREIRA VIERA LAGINHAS", 57743, 9201208, 1 },
                    { 179, false, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "JOÃO DANIEL COUTO CAMPOS SILVA", 81169, 9201535, 1 },
                    { 177, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "JOÃO ALEXANDRE REIS FIGUEIRAL", 80430, 9201500, 1 },
                    { 54, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 7, 1, null, "", "SANDRO MIGUEL GUINCHO FERREIRA", 50542, 6266, 1 },
                    { 251, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "MARCELO MANUEL MELO RODRIGUES", 81072, 9201473, 1 },
                    { 52, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "RUI MIGUEL MEDINA SILVA", 53540, 6848, 1 },
                    { 23, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 6, 1, null, "", "JOÃO CARLOS VIEIRA CORREIA", 32660, 6625, 1 },
                    { 22, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 7, 1, null, "", "JAIME NELSON DOS SANTOS PINHO", 44598, 5406, 1 },
                    { 21, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2013, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 7, 1, null, "", "JAIME MAGNO MORGADO", 46701, 5756, 1 },
                    { 20, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "HENRIQUE MANUEL DA ENCARNAÇAO RAMIRES DOS SANTOS", 28358, 4513, 1 },
                    { 19, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 4, null, "", "GONÇALO SANTOS NUNES DE VASCONCELOS E MENESES", 22501, 6628, 1 },
                    { 18, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2011, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "GIVANILDO ALVES DA SILVA", 13401, 5213, 1 },
                    { 17, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "FILIPE JOAQUIM ARAUJO DE MELO ALVES", 48511, 6061, 1 },
                    { 16, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 7, 1, null, "", "FERNANDO PEDRO VIDEIRA VIANA RODRIGUES", 48890, 6074, 1 },
                    { 15, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 7, 1, null, "", "FABIO RAFAEL RATO VARELA", 46018, 5855, 1 },
                    { 14, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "FÁBIO MIGUEL FERREIRA MOTA", 48518, 5858, 1 },
                    { 13, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "FÁBIO FILIPE PINTO BRANCO", 52204, 7028, 1 },
                    { 11, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "CARLOS MANUEL NUNES TIAGO", 54526, 7020, 1 },
                    { 10, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "CARLOS ALBERTO DOS SANTOS LAMEIRAS", 49770, 6798, 1 },
                    { 9, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 7, 1, null, "", "BRUNO RICARDO ABADESSO NUNES SILVA", 6296, 6264, 1 },
                    { 8, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "ANTÓNIO MIGUEL RODRIGUES SILVA", 31271, 6070, 1 },
                    { 7, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2011, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 5, 1, null, "", "ANTONIO MIGUEL FERNANDES CAPELO", 51266, 5104, 1 },
                    { 6, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 6, 1, null, "", "ANTÓNIO JOSÉ SANTOS ALVES", 50544, 6627, 1 },
                    { 5, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 1, 1, null, "", "ANTONIO JORGE BAPTISTA DA ROCHA", 37797, 5057, 1 },
                    { 4, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "ANTONIO ANGELO VITORETTI", 43872, 5382, 1 },
                    { 3, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 6, 1, null, "", "ANA FLOR PEREIRA NEVES", 51707, 6622, 1 },
                    { 2, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 6, 1, null, "", "ANA CLARA MARQUES LOPES", 51706, 6619, 1 },
                    { 1, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "ALBERTO MIGUEL FARIA DA COSTA", 53163, 7785, 1 }
                });

            migrationBuilder.InsertData(
                table: "Colaborador",
                columns: new[] { "ColaboradorID", "Ativo", "CategoriaId", "ContratoId", "CreatedAt", "CreatedBy", "DataAdmissao", "DataFim", "DepartamentoId", "EquipaId", "FuncaoId", "HorarioContratadoId", "HorarioPraticadoId", "LastUpdatedAt", "LastUpdatedBy", "Nome", "NumCartao", "NumPw", "UhId" },
                values: new object[,]
                {
                    { 250, true, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2018, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "VITOR HUGO RAMOS SOARES", 73352, 9201540, 1 },
                    { 24, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2013, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 7, 1, null, "", "JOAO PEDRO MARQUES GERARDO", 99, 5675, 1 },
                    { 25, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "JOÃO PEDRO QUINTELA ALVES SILVA", 56158, 7600, 1 },
                    { 12, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 7, 1, null, "", "CIPRIAN GAVRILIUC", 44662, 5402, 1 },
                    { 27, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 7, 1, null, "", "LUÍS EDUARDO BARRETO GONÇALVES", 37315, 6077, 1 },
                    { 26, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2013, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 7, 1, null, "", "JORGE MANUEL BERNARDO RIBEIRO", 47307, 5772, 1 },
                    { 50, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 7, 1, null, "", "RUBEN SAMUEL DE OLIVEIRA ROCHA", 42556, 5324, 1 },
                    { 49, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "RODRIGO NASCIMENTO SILVA LEMOS", 54610, 7022, 1 },
                    { 48, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 6, 1, null, "", "RODOLFO GOMES SANTOS", 28935, 5012, 1 },
                    { 47, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "RICARDO MIGUEL SUBTIL PAULINO", 50549, 6296, 1 },
                    { 46, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2013, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "PEDRO RICARDO GAMBOA PEREIRA", 17068, 3564, 1 },
                    { 44, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "PEDRO FILIPE RAPOSO SANTOS", 42704, 5326, 1 },
                    { 43, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2014, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 7, 1, null, "", "PAULO MIGUEL CARMONA GROU", 47316, 5907, 1 },
                    { 42, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 4, null, "", "PAULO JORGE PIRES LOUREIRO", 51718, 6599, 1 },
                    { 41, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "PAULO JORGE DE CARVALHO VALERIO", 53556, 7017, 1 },
                    { 40, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 6, 1, null, "", "PAULO ALEXANDRE MIRANDA DE MATOS", 48948, 6767, 1 },
                    { 45, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 7, 1, null, "", "PEDRO MIGUEL LOUREIRO DOS SANTOS", 40516, 5383, 1 },
                    { 51, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 6, 1, null, "", "RUI MANUEL CAMELO QUINTAS", 21869, 6765, 1 },
                    { 28, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 6, 1, null, "", "LUÍS FERNANDO MARTINS DIAS", 16048, 6621, 1 },
                    { 39, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "PAULO ADRIANO MATEUS RIBEIRO", 58138, 7975, 1 },
                    { 29, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 1, null, "", "LUÍS FILIPE OLIVEIRA DE SOUSA", 52174, 6766, 1 },
                    { 30, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 1, 1, null, "", "MÁRCIA DOS SANTOS MENDES", 38881, 7599, 1 },
                    { 31, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 6, 1, null, "", "MARCOS PAULO ANDRADE RODRIGUES", 52178, 6768, 1 },
                    { 33, false, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2011, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 7, 1, null, "", "NELSON PEREIRA DOS SANTOS MARQUES", 40579, 5235, 1 },
                    { 32, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2010, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "MIGUEL BRANDAO DE MACEDO SANTOS", 37099, 5061, 1 },
                    { 34, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2016, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "NUNO CARLOS PEREIRA GODINHO", 54538, 7019, 1 },
                    { 35, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "NUNO GONÇALO VENTURA ROCHA", 57624, 7871, 1 },
                    { 36, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2017, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "NUNO MIGUEL DUARTE GOMES", 57621, 7974, 1 },
                    { 37, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2013, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 7, 1, null, "", "NUNO MIGUEL GONÇALVES FRANCO", 46696, 5757, 1 },
                    { 38, true, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(2012, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 7, 1, null, "", "OSCAR ZEFERINO BARRAL PEREIRA DA SILVA", 36193, 5325, 1 }
                });

            migrationBuilder.InsertData(
                table: "Portas",
                columns: new[] { "PortaID", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "PierID", "PortaNum", "PortaTempo", "Remoto", "Schengen", "Terminal" },
                values: new object[,]
                {
                    { 42, null, null, null, null, 3, "46", 17, false, false, true },
                    { 44, null, null, null, null, 3, "47", 16, false, false, true },
                    { 43, null, null, null, null, 3, "46A", 17, true, false, true },
                    { 45, null, null, null, null, 3, "47A", 16, true, false, true },
                    { 41, null, null, null, null, 3, "45A", 16, true, false, true },
                    { 35, null, null, null, null, 3, "43A", 14, true, false, true },
                    { 39, null, null, null, null, 3, "44B", 15, true, false, true },
                    { 38, null, null, null, null, 3, "44A", 15, true, false, true },
                    { 37, null, null, null, null, 3, "44", 15, false, false, true },
                    { 36, null, null, null, null, 3, "43B", 14, true, false, true },
                    { 46, null, null, null, null, 4, "201", 10, true, true, false },
                    { 40, null, null, null, null, 3, "45", 16, false, false, true },
                    { 34, null, null, null, null, 3, "43", 14, false, false, true },
                    { 58, null, null, null, null, 4, "211A", 10, true, false, false },
                    { 48, null, null, null, null, 4, "203", 10, true, true, false },
                    { 49, null, null, null, null, 4, "204", 10, true, true, false },
                    { 50, null, null, null, null, 4, "205", 10, true, true, false },
                    { 51, null, null, null, null, 4, "206", 10, true, true, false },
                    { 52, null, null, null, null, 4, "207", 10, true, true, false },
                    { 53, null, null, null, null, 4, "208", 10, true, true, false },
                    { 54, null, null, null, null, 4, "209", 10, true, true, false },
                    { 55, null, null, null, null, 4, "209A", 10, true, true, false },
                    { 56, null, null, null, null, 4, "210", 10, true, false, false },
                    { 57, null, null, null, null, 4, "211", 10, true, false, false },
                    { 59, null, null, null, null, 4, "212", 10, true, false, false },
                    { 60, null, null, null, null, 4, "212A", 10, true, false, false },
                    { 33, null, null, null, null, 3, "42A", 13, true, false, true },
                    { 47, null, null, null, null, 4, "202", 10, true, true, false },
                    { 32, null, null, null, null, 3, "42", 13, false, false, true },
                    { 6, null, null, null, null, 1, "11", 10, true, true, true },
                    { 30, null, null, null, null, 3, "41", 13, false, false, true },
                    { 2, null, null, null, null, 1, "08", 12, true, true, true },
                    { 3, null, null, null, null, 1, "8B", 12, true, true, true },
                    { 4, null, null, null, null, 1, "09", 11, true, true, true },
                    { 5, null, null, null, null, 1, "10", 11, true, true, true },
                    { 61, null, null, null, null, 4, "214", 10, true, false, false },
                    { 7, null, null, null, null, 1, "12", 10, true, true, true },
                    { 8, null, null, null, null, 1, "13", 9, true, true, true },
                    { 9, null, null, null, null, 2, "14", 9, false, true, true },
                    { 10, null, null, null, null, 2, "15", 8, false, true, true },
                    { 11, null, null, null, null, 2, "15A", 8, true, true, true },
                    { 12, null, null, null, null, 2, "16", 8, false, true, true },
                    { 13, null, null, null, null, 2, "16A", 8, true, true, true },
                    { 14, null, null, null, null, 2, "17", 7, false, true, true },
                    { 31, null, null, null, null, 3, "41A", 13, true, false, true },
                    { 15, null, null, null, null, 2, "17A", 7, true, true, true },
                    { 17, null, null, null, null, 2, "18A", 7, true, true, true },
                    { 18, null, null, null, null, 2, "18B", 7, true, true, true },
                    { 19, null, null, null, null, 2, "19", 8, true, true, true },
                    { 20, null, null, null, null, 2, "20", 8, true, true, true },
                    { 21, null, null, null, null, 2, "21", 6, true, true, true },
                    { 22, null, null, null, null, 2, "22", 5, false, true, true },
                    { 23, null, null, null, null, 2, "22A", 5, true, true, true },
                    { 24, null, null, null, null, 2, "23", 5, false, true, true },
                    { 25, null, null, null, null, 2, "23A", 5, true, true, true },
                    { 26, null, null, null, null, 2, "24", 7, false, true, true },
                    { 27, null, null, null, null, 2, "25", 7, false, true, true },
                    { 28, null, null, null, null, 2, "26", 12, false, false, true },
                    { 29, null, null, null, null, 2, "27", 12, true, false, true },
                    { 16, null, null, null, null, 2, "18", 7, true, true, true },
                    { 62, null, null, null, null, 4, "214A", 10, true, false, false },
                    { 1, null, null, null, null, 1, "07", 12, false, true, true }
                });

            migrationBuilder.InsertData(
                table: "Stands",
                columns: new[] { "StandId", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "PierID", "PlataformaId", "Remoto", "StandN" },
                values: new object[,]
                {
                    { 20, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, 1, false, 145 },
                    { 64, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 506 },
                    { 62, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 505 },
                    { 61, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 504 },
                    { 60, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 503 },
                    { 59, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 502 },
                    { 58, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 501 },
                    { 57, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 426 },
                    { 65, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 601 },
                    { 56, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 425 },
                    { 54, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 423 },
                    { 53, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 422 },
                    { 52, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 421 },
                    { 51, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 416 },
                    { 50, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 415 },
                    { 49, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 414 },
                    { 48, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 413 },
                    { 55, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 424 },
                    { 66, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 602 },
                    { 67, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 603 },
                    { 68, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 604 },
                    { 85, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 806 },
                    { 84, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 805 },
                    { 83, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 804 },
                    { 82, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 803 },
                    { 81, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 802 },
                    { 80, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 801 },
                    { 79, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 706 },
                    { 78, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 705 },
                    { 77, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 704 },
                    { 76, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 703 },
                    { 75, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 702 },
                    { 74, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 6, true, 701 },
                    { 73, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 609 },
                    { 72, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 608 },
                    { 71, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 607 },
                    { 70, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 606 },
                    { 69, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 605 },
                    { 47, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 412 },
                    { 45, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 5, true, 411 },
                    { 44, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 4, true, 405 },
                    { 43, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 4, true, 404 },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, 1, true, 105 },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, 1, true, 106 },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, 1, false, 107 },
                    { 5, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, 1, true, 108 },
                    { 7, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 114 },
                    { 8, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 115 },
                    { 9, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 116 },
                    { 10, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 117 },
                    { 11, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 122 },
                    { 12, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 123 },
                    { 13, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 124 },
                    { 14, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 125 },
                    { 15, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, 1, false, 126 },
                    { 16, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, 1, false, 141 },
                    { 17, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, 1, false, 142 },
                    { 18, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, 1, false, 143 },
                    { 19, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, 1, false, 144 },
                    { 1, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, 1, true, 104 },
                    { 21, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, 1, false, 146 },
                    { 22, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, 1, false, 147 },
                    { 24, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 201 },
                    { 42, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 4, true, 403 },
                    { 41, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 4, true, 402 },
                    { 40, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 4, true, 401 },
                    { 39, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 4, true, 302 },
                    { 38, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 4, true, 301 },
                    { 36, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 3, true, 224 },
                    { 35, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 3, true, 223 },
                    { 34, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 3, true, 222 },
                    { 33, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 3, true, 221 },
                    { 32, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 209 },
                    { 31, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 208 },
                    { 30, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 207 },
                    { 29, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 206 },
                    { 28, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 205 },
                    { 27, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 204 },
                    { 26, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 203 },
                    { 25, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 202 },
                    { 23, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, 2, true, 200 },
                    { 37, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, 3, true, 225 }
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
                name: "IX_Colaborador_UhId",
                table: "Colaborador",
                column: "UhId");

            migrationBuilder.CreateIndex(
                name: "IX_Portas_PierID",
                table: "Portas",
                column: "PierID");

            migrationBuilder.CreateIndex(
                name: "IX_Stagings_StatusId",
                table: "Stagings",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Stands_PierID",
                table: "Stands",
                column: "PierID");

            migrationBuilder.CreateIndex(
                name: "IX_Stands_PlataformaId",
                table: "Stands",
                column: "PlataformaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stands_StandN",
                table: "Stands",
                column: "StandN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssistenciasPRMS");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Portas");

            migrationBuilder.DropTable(
                name: "Stagings");

            migrationBuilder.DropTable(
                name: "Stands");

            migrationBuilder.DropTable(
                name: "ToDos");

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
                name: "Uh");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Piers");

            migrationBuilder.DropTable(
                name: "Plataformas");
        }
    }
}
