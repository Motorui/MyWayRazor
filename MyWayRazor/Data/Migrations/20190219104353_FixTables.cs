using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class FixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_StatusId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Status_StatusId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Colaborador");

            migrationBuilder.AlterColumn<int>(
                name: "StandN",
                table: "Stands",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Portas",
                columns: table => new
                {
                    PortaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PortaNum = table.Column<string>(nullable: false),
                    PortaTempo = table.Column<int>(nullable: false),
                    Schengen = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portas", x => x.PortaID);
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
                    Voo = table.Column<string>(nullable: true),
                    Mov = table.Column<string>(nullable: true),
                    OrigemDestino = table.Column<string>(nullable: true),
                    Pax = table.Column<string>(nullable: true),
                    Ssr = table.Column<string>(nullable: true),
                    AirCraft = table.Column<string>(nullable: true),
                    Stand = table.Column<string>(nullable: true),
                    CheckIn = table.Column<string>(nullable: true),
                    Gate = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Etd = table.Column<DateTime>(nullable: false),
                    Antecipar = table.Column<DateTime>(nullable: false),
                    Horario = table.Column<DateTime>(nullable: false),
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
                name: "ToDos",
                columns: table => new
                {
                    ToDoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ToDoTittle = table.Column<string>(nullable: true),
                    ToDoText = table.Column<string>(nullable: true),
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
                    { 5, new DateTime(2018, 10, 25, 11, 23, 40, 800, DateTimeKind.Unspecified).AddTicks(3868), "SISTEMA", 20, null, null },
                    { 7, new DateTime(2018, 10, 25, 11, 23, 41, 413, DateTimeKind.Unspecified).AddTicks(8488), "SISTEMA", 12, null, null },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 40, 518, DateTimeKind.Unspecified).AddTicks(3892), "SISTEMA", 25, null, null },
                    { 6, new DateTime(2018, 10, 25, 11, 23, 41, 98, DateTimeKind.Unspecified).AddTicks(7970), "SISTEMA", 18, null, null },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 39, 977, DateTimeKind.Unspecified).AddTicks(9922), "SISTEMA", 38, null, null },
                    { 1, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", 40, null, null },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 40, 241, DateTimeKind.Unspecified).AddTicks(7707), "SISTEMA", 36, null, null }
                });

            migrationBuilder.InsertData(
                table: "Plataformas",
                columns: new[] { "PlataformaId", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "PlataformaN" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas10a14" },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas20" },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas22" },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas30a40" },
                    { 5, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas41a60" },
                    { 6, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, "Plataformas70a80" }
                });

            migrationBuilder.InsertData(
                table: "Portas",
                columns: new[] { "PortaID", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "PortaNum", "PortaTempo", "Schengen" },
                values: new object[,]
                {
                    { 33, null, null, null, null, "42A", 13, true },
                    { 32, null, null, null, null, "42", 13, true },
                    { 31, null, null, null, null, "41A", 13, true },
                    { 27, null, null, null, null, "25", 7, false },
                    { 29, null, null, null, null, "27", 12, true },
                    { 28, null, null, null, null, "26", 12, true },
                    { 34, null, null, null, null, "43", 14, true },
                    { 26, null, null, null, null, "24", 7, false },
                    { 30, null, null, null, null, "41", 13, true },
                    { 35, null, null, null, null, "43A", 14, true },
                    { 39, null, null, null, null, "44B", 15, true },
                    { 37, null, null, null, null, "44", 15, true },
                    { 38, null, null, null, null, "44A", 15, true },
                    { 40, null, null, null, null, "45", 16, true },
                    { 41, null, null, null, null, "45A", 16, true },
                    { 42, null, null, null, null, "46", 17, true },
                    { 43, null, null, null, null, "46A", 17, true },
                    { 44, null, null, null, null, "47", 16, true },
                    { 45, null, null, null, null, "47A", 16, true },
                    { 25, null, null, null, null, "23A", 5, false },
                    { 36, null, null, null, null, "43B", 14, true },
                    { 24, null, null, null, null, "23", 5, false },
                    { 10, null, null, null, null, "15", 8, false },
                    { 22, null, null, null, null, "22", 5, false },
                    { 1, null, null, null, null, "7", 12, false },
                    { 2, null, null, null, null, "8", 12, false },
                    { 3, null, null, null, null, "8B", 12, false },
                    { 4, null, null, null, null, "9", 11, false },
                    { 5, null, null, null, null, "10", 11, false },
                    { 6, null, null, null, null, "11", 10, false },
                    { 23, null, null, null, null, "22A", 5, false },
                    { 8, null, null, null, null, "13", 9, false },
                    { 9, null, null, null, null, "14", 9, false },
                    { 11, null, null, null, null, "15A", 8, false },
                    { 7, null, null, null, null, "12", 10, false },
                    { 21, null, null, null, null, "21", 6, false },
                    { 12, null, null, null, null, "16", 8, false },
                    { 19, null, null, null, null, "19", 8, false },
                    { 18, null, null, null, null, "18B", 7, false },
                    { 17, null, null, null, null, "18A", 7, false },
                    { 20, null, null, null, null, "20", 8, false },
                    { 15, null, null, null, null, "17A", 7, false },
                    { 14, null, null, null, null, "17", 7, false },
                    { 13, null, null, null, null, "16A", 8, false },
                    { 16, null, null, null, null, "18", 7, false }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusID", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "Statuses" },
                values: new object[,]
                {
                    { 6, null, null, null, null, "Ausente" },
                    { 1, null, null, null, null, "" },
                    { 2, null, null, null, null, "Espera" },
                    { 3, null, null, null, null, "Cancelado" },
                    { 4, null, null, null, null, "Encaminhado" },
                    { 5, null, null, null, null, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Uh",
                columns: new[] { "UhId", "CreatedAt", "CreatedBy", "IATA", "LastUpdatedAt", "LastUpdatedBy", "UhNome" },
                values: new object[,]
                {
                    { 2, new DateTime(2018, 10, 25, 11, 23, 42, 784, DateTimeKind.Unspecified).AddTicks(4907), "SISTEMA", "OPO", null, null, "PORTO" },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 43, 144, DateTimeKind.Unspecified).AddTicks(8285), "SISTEMA", "FAO", null, null, "FARO" },
                    { 1, new DateTime(2018, 10, 25, 11, 23, 42, 437, DateTimeKind.Unspecified).AddTicks(1089), "SISTEMA", "LIS", null, null, "LISBOA" },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 43, 537, DateTimeKind.Unspecified).AddTicks(6776), "SISTEMA", "FNC", null, null, "FUNCHAL" }
                });

            migrationBuilder.InsertData(
                table: "Colaborador",
                columns: new[] { "ColaboradorID", "CategoriaId", "ContratoId", "CreatedAt", "CreatedBy", "DataAdmissão", "DataFim", "DepartamentoId", "EquipaId", "FuncaoId", "HorarioContratadoId", "HorarioPraticadoId", "LastUpdatedAt", "LastUpdatedBy", "Nome", "NumCartao", "NumPw", "UhId" },
                values: new object[,]
                {
                    { 84, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "VERA M�NICA MOREIRA MARTINS", 71106, 8227, 1 },
                    { 144, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "DAVID JOSE AMARO MADEIRA", 77559, 9201320, 1 },
                    { 143, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "DAVID EMANUEL CONDE BARROS", 58743, 9201270, 1 },
                    { 142, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "DALILA MARIA FERREIRA MARC�O", 81304, 9201625, 1 },
                    { 141, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "CLAUDIA CRISTINA RODRIGUES MARQUES", 81916, 9201548, 1 },
                    { 140, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "CATARINA PEREIRA BUAL VALENTE SALVADO", 81067, 9201520, 1 },
                    { 139, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "CATARINA LUISA BRAGA BATISTA", 99, 99, 1 },
                    { 138, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "CATARINA FILIPE CID SIMOES", 76571, 9201271, 1 },
                    { 145, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "DAVID LU�S ALVES NOBRE", 76718, 9201282, 1 },
                    { 137, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "CATARINA FILIPA MARQUES PEREIRA", 81302, 9201527, 1 },
                    { 135, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "BRUNO RAFAEL BARRADAS AFONSO", 80737, 9201474, 1 },
                    { 134, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "BRUNO DA COSTA ALBUQUERQUE", 80736, 9201508, 1 },
                    { 133, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "BRUNA ANDREIA DA CONCEI��O HENRIQUES", 80781, 9201507, 1 },
                    { 132, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "BRENO MICAEL GODINHO FILIPE", 82043, 9201549, 1 },
                    { 131, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "BERNARDO MIGUEL TOMAS CORREIA", 99, 99, 1 },
                    { 130, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "ANT�NIO TOVAR DE CARVALHO PATRICIO", 80831, 9201494, 1 },
                    { 129, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "ANT�NIO MIGUEL DE MATOS PINTO", 75812, 9201231, 1 },
                    { 136, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "CAROLINA CARDOSO FERREIRA CHAVES", 78309, 9201390, 1 },
                    { 146, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "DEISY IRINA VEIGA DE FERNANDES DA SILVA", 80417, 9201495, 1 },
                    { 147, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "DIOGO FILIPE DE PINHO MENDES MIRANDA", 77359, 9201332, 1 },
                    { 148, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "DIOGO MIGUEL ROSARIO ALMEIDA", 81306, 9201530, 1 },
                    { 165, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "GON�ALO CARLOS DE BRITO BRAVO GUIMARAES CABANELAS", 81314, 9201521, 1 },
                    { 164, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "FREDERICO MIGUEL DUARTE ROSA", 77362, 9201326, 1 },
                    { 163, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "FREDERICO EMANUEL RIBEIRO CARVALHINHO", 80745, 9201487, 1 },
                    { 162, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "FRANCISCO MANUEL ABREU PEREIRA", 58414, 9201522, 1 },
                    { 161, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "FL�VIA SANTOS TAMBELINI", 80477, 9201497, 1 },
                    { 160, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "FILIPE ANDR� PEREIRA PINTO DA PALMA CORDEIRO", 48592, 9200967, 1 },
                    { 159, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "FERDINANDO DIAMANTINO RODRIGUES DE MATOS", 46443, 9201465, 1 },
                    { 158, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "F�BIO MIGUEL BERRONES CARDOSO", 80429, 9201496, 1 },
                    { 157, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "FABIO JORGE SILVA SANTOS", 53532, 9201250, 1 },
                    { 156, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "F�bio Emanuel Flores Resende Amaral", 59727, 9201693, 1 },
                    { 155, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "EUGENIO HENRIQUES AGOSTINHO LOPES RIBEIRO", 79395, 9201422, 1 },
                    { 154, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "EMERSON JORGE LOPES DO ROS�RIO SEQUEIRA", 75700, 9201230, 1 },
                    { 153, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "ELISIO MIGUEL SEMEDO SOARES", 99, 99, 1 },
                    { 152, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "DULCE MARIA FIALHO DA SILVA SILVA", 80742, 9201467, 1 },
                    { 151, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "DORA MARISA RIBEIRO", 75318, 9201197, 1 },
                    { 150, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "DIONISIO SERGIO DE MATOS VALENTE GON�ALVES", 77361, 9201324, 1 },
                    { 149, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 1, 1, null, "", "DIOGO PIRES", 99, 99, 1 },
                    { 128, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "ANT�NIO JOS� RIBEIRO MARQUES", 53548, 9200965, 1 },
                    { 127, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "ANTONIO JOSE PEREIRA RAMALHO", 75315, 9201215, 1 },
                    { 126, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 6, 4, 4, null, "", "ANGELA SOFIA GOMES FERREIRA", 99, 99, 1 },
                    { 125, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "ANDRE MORAIS CARNEIRO", 71289, 9201300, 1 },
                    { 103, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 5, 1, null, "", "MARCO PAULO DE ANDRADE RODRIGUES", 33948, 4840, 1 },
                    { 102, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "MARCO ANTONIO SILVA FRAGOSO", 36920, 5002, 1 },
                    { 101, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 3, 2, null, "", "MANUEL FRANCISCO CORREIA MATA LAN�A", 633, 3010, 1 },
                    { 100, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "JULIO AUGUSTO DA CRUZ", 37011, 5001, 1 },
                    { 99, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 3, 2, null, "", "JOS� MANUEL CARDOSO DA COSTA LEONARDO", 3902, 2062, 1 },
                    { 98, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 3, 2, null, "", "JOS� ANT�NIO DIAS CRUZ", 629, 2055, 1 },
                    { 97, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 3, 2, null, "", "JO�O MANUEL SIM�O CARRILHO", 1171, 2045, 1 },
                    { 96, 3, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 3, 2, null, "", "JO�O DANIEL AL�PIO GUERREIRO TEOT�NIO", 13122, 3258, 1 },
                    { 95, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 5, 1, null, "", "JOAO CARLOS QUITERIO ALVES", 36882, 5097, 1 },
                    { 94, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "IVAN DANIEL LOUREN�O GARCIA CORREIA", 37062, 4999, 1 },
                    { 93, 3, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 3, 2, null, "", "GHEORGHE ADELIN MEDISAN", 14643, 3445, 1 },
                    { 92, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "ELDER CARLOS BORGES", 36414, 5025, 1 },
                    { 91, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "BUBACAR DJASSI", 37107, 4980, 1 },
                    { 90, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "BRUNO MIGUEL CARDOSO BATISTA", 37093, 4964, 1 },
                    { 89, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "BRUNO DANIEL VEIGA MIRA", 37100, 4975, 1 },
                    { 88, 3, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 3, 2, null, "", "ANT�NIO FERNANDO LOPES FIDALGO", 1143, 2013, 1 },
                    { 87, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "ANGELO CARLOS SIXPENCE CAZAN�A", 37126, 4979, 1 },
                    { 104, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, 6, 1, null, "", "MARIA DA CONCEI��O SANTOS PEREIRA RODRIGUES", 99, 5064, 1 },
                    { 166, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "GON�ALO MADEIRA CARDOSO BRITO", 74417, 9201175, 1 },
                    { 105, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "MIGUEL FILIPE PACHECO ELIAS", 23989, 5003, 1 },
                    { 107, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 10, 6, 2, null, "", "PAULO FABRICIO VIEIRA MENEZES CATANHO", 99, 6425, 1 },
                    { 124, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "ANDRE FILIPE VENTURA", 77817, 9201359, 1 },
                    { 123, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "ANDRE BENTO VERDE", 81243, 9201534, 1 },
                    { 122, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "ANABELA FERNANDES CONCEI��O", 80415, 9201464, 1 },
                    { 121, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 1, 1, null, "", "ANA RITA PEIXOTO DA COSTA PEREIRA DA SILVA", 99, 99, 1 },
                    { 120, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "ANA PAULA DA RIBEIRA RAMOS", 81179, 9201493, 1 },
                    { 119, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "ANA FILIPA SILVA RODRIGUES PEREIRA", 81022, 9201492, 1 },
                    { 118, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 1, 4, null, "", "ANA FILIPA MARTINHO RAMOS", 77774, 9201358, 1 },
                    { 117, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "ANA CATARINA DA FONSECA FERNANDES", 99, 99, 1 },
                    { 116, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "AMILCAR JORGE COIMBRA DOS SANTOS", 81242, 9201528, 1 },
                    { 115, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "ALINE PEREZ GARCIA", 76802, 9201303, 1 },
                    { 114, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "VALDEMIRO VEIGA FERNANDES", 45373, 5015, 1 },
                    { 113, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 1, 1, null, "", "TIAGO FILIPE DE BARROS MORAIS LINHARES", 37095, 5014, 1 },
                    { 112, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "RUI SAMUEL VENANCIO LEIT�O", 36922, 5013, 1 },
                    { 111, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 6, 2, null, "", "RUI ALEXANDRE ALVES PEREIRA", 24899, 4065, 1 },
                    { 110, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 6, 2, null, "", "RICARDO JOS� RIBEIRO DOS SANTOS", 28030, 4500, 1 },
                    { 109, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 1, 1, null, "", "RICARDO JORGE MARQUES BARROCAS", 37066, 5010, 1 },
                    { 108, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "PAULO JORGE DE OLIVEIRA SANTOS", 46781, 5669, 1 },
                    { 106, 1, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "NUNO RICARDO MONTEIRO LOPES", 37069, 5006, 1 },
                    { 86, 2, 1, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 7, 1, null, "", "ALEXANDRE PEREIRA RAPOSO", 40512, 5212, 1 },
                    { 167, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 1, 1, null, "", "GON�ALO SILVA SANTA BARBARA", 57800, 9201277, 1 },
                    { 169, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "HELTON ANDRADE D�SANTANA", 76418, 9201327, 1 },
                    { 228, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "RUI MANUEL SOUSA PINTO", 80441, 9201505, 1 },
                    { 227, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "RUI FILIPE FERNANDES PAULINO", 75682, 9201249, 1 },
                    { 226, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "RAQUEL ALEXANDRA SILVA", 75300, 9201200, 1 },
                    { 225, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "RAFAEL MARQUES ESTANQUE", 72737, 9201264, 1 },
                    { 224, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "PEDRO TELMO FERNANDES COSTA", 51651, 9201168, 1 },
                    { 223, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 7, 1, 1, null, "", "PEDRO RICARDO ROCHA FERRO PIRES", 99, 99, 1 },
                    { 222, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "PEDRO DUARTE DOS SANTOS BARQUINHA", 81327, 9201626, 1 },
                    { 229, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "Rui Miguel A. C. Afonso Madeira", 77414, 9201356, 1 },
                    { 221, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "PEDRO CELESTINO SOARES DE OLIVEIRA PINTO", 99, 99, 1 },
                    { 219, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "PAULO JOS� MIGUEL RIBEIRO", 75317, 9201229, 1 },
                    { 218, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "PATRICIA ALEXANDRA DE JESUS COELHO", 80440, 9201466, 1 },
                    { 217, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "NUNO MIGUEL MORAIS DE ALMEIDA", 81326, 9201531, 1 },
                    { 216, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "NUNO MIGUEL BUGADA PINTO", 31157, 9201009, 1 },
                    { 215, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "NUNO FILIPE VIEIRA CUSTODIO", 81987, 9201545, 1 },
                    { 214, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "NUNO FILIPE DINIZ RAIMUNDO", 75311, 9201242, 1 },
                    { 213, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "NUNO ANDR� CORDEIRO DE SOUSA", 73830, 9201184, 1 },
                    { 220, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "PEDRO ALEXANDRE MARTINS NETO RIBEIRO", 35849, 9201415, 1 },
                    { 230, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "RUI MIGUEL REMIGIO DA CRUZ BENTO", 81139, 9201533, 1 },
                    { 231, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "Rui Ricardo dos Santos Pereira Dias  ", 71941, 9201084, 1 },
                    { 232, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "Rute Maria Dinis Costa", 78331, 9201385, 1 },
                    { 249, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "VERA LUCIA CARDOSO MARTINS DA SILVA", 99, 99, 1 },
                    { 248, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "VASCO RAFAEL SIM�O DA SILVA RAMOS", 99, 99, 1 },
                    { 247, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "VASCO RAFAEL CORDEIRO MARTINS TAPADAS", 81148, 9201463, 1 },
                    { 246, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 4, 4, null, "", "VANESSA CRISTINA DA PONTE PAJUEL NUNES", 99, 99, 1 },
                    { 245, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "TIAGO MIGUEL SOUSA ALVES", 77377, 9201331, 1 },
                    { 244, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "TIAGO FILIPE DA SILVA GUERREIRO", 76569, 9201278, 1 },
                    { 243, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "TIAGO FERREIRA RAIMUNDO", 81330, 9201529, 1 },
                    { 242, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "TIAGO FERREIRA MANGAS DUARTE JORGE", 76565, 9201276, 1 },
                    { 241, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "TIAGO FERNANDO MORAIS DA CUNHA FIGUEIRA", 99, 99, 1 },
                    { 240, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "Susana Trindade M. Raimundo Silva", 77806, 9201357, 1 },
                    { 239, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "SERGIO MIGUEL SILVA HENRIQUES", 82011, 9201541, 1 },
                    { 238, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 1, 1, null, "", "S�RGIO EDUARDO MOUTINHO DA SILVA CASTANHO CANDEIAS", 99, 99, 1 }
                });

            migrationBuilder.InsertData(
                table: "Colaborador",
                columns: new[] { "ColaboradorID", "CategoriaId", "ContratoId", "CreatedAt", "CreatedBy", "DataAdmissão", "DataFim", "DepartamentoId", "EquipaId", "FuncaoId", "HorarioContratadoId", "HorarioPraticadoId", "LastUpdatedAt", "LastUpdatedBy", "Nome", "NumCartao", "NumPw", "UhId" },
                values: new object[,]
                {
                    { 237, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "SERGIO BRUNO VELHO VANDER KELLEN", 81953, 9201546, 1 },
                    { 236, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "SARA RAQUEL MARTINHO FERNANDES", 81329, 9201519, 1 },
                    { 235, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "SARA DIAS AFONSO", 76575, 9201266, 1 },
                    { 234, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "SARA CATARINA DOS SANTOS AREDE", 80442, 9201506, 1 },
                    { 233, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "SANDRA PATRICIA DE ALMEIDA LOPES FERREIRA", 76564, 9201279, 1 },
                    { 212, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "NILTON ALEXANDRE BRITO", 81933, 9201542, 1 },
                    { 211, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "NELSON FILIPE CONCEI�AO CARVALHO", 81931, 9201551, 1 },
                    { 210, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "NELSON BONITO PITA", 81325, 9201524, 1 },
                    { 209, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "NANCY SANTOS BALC�O", 58451, 9201028, 1 },
                    { 186, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "JULIO CESAR RODRIGUES RIBEIRO", 81926, 9201544, 1 },
                    { 185, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 6, 4, 4, null, "", "JULIANA MORENO ESPOSITO", 83339, 9201670, 1 },
                    { 184, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "JOJO ANTHONY SABERON MONTANO", 81174, 9201501, 1 },
                    { 183, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "JOAO PAULO PO�AS DE CARVALHO E OLIVEIRA", 76732, 9201274, 1 },
                    { 182, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "JOAO PAULO CARDOSO RODRIGUES", 76721, 9201305, 1 },
                    { 181, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 7, 1, 1, null, "", "JOAO FERNANDO LAGUGAS MORAIS", 99, 99, 1 },
                    { 180, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "JO�O DE DEUS PEREIRA VIERA LAGINHAS", 57743, 9201208, 1 },
                    { 179, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "JO�O DANIEL COUTO CAMPOS SILVA", 81169, 9201535, 1 },
                    { 178, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "JO�O CARLOS MADUREIRA GOMES", 99, 99, 1 },
                    { 177, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "JO�O ALEXANDRE REIS FIGUEIRAL", 80430, 9201500, 1 },
                    { 176, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "JESSICA SOUSA SANTOS", 76719, 9201298, 1 },
                    { 175, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "JESSICA FILIPA PEREIRA RODRIGUES", 81068, 9201499, 1 },
                    { 174, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "JESSICA ANDREIA CALADO COSTA", 77372, 9201328, 1 },
                    { 173, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "IVO RAFAEL HENRINQUES RAMOS", 72254, 9201171, 1 },
                    { 172, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 6, 4, 4, null, "", "IVAN EMANUEL ARRULO PEDROSO DA SILVA", 80748, 9201498, 1 },
                    { 171, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 1, 1, null, "", "Isabel Maria Nobre Batata", 77413, 9201321, 1 },
                    { 170, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "HUGO ALEXANDRE FERREIRA LOPES", 77365, 9201322, 1 },
                    { 187, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "Karen Andreina Jardin Rojas", 99, 99, 1 },
                    { 168, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "HELIBERTO EDUARDO QUARESMA CASTRO", 81315, 9201525, 1 },
                    { 188, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "LARYSSA DE RESENDE LEMOS", 77472, 9201329, 1 },
                    { 190, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "LEE NATHAN SERENO", 74420, 9200118, 1 },
                    { 208, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "MONICA SOFIA SANTOS FERREIRA TRINDADE", 76680, 9201267, 1 },
                    { 207, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 7, 1, 1, null, "", "MIGUEL LOUREN�O GERALDES FREIRE DE CARVALHO", 80759, 9201504, 1 },
                    { 206, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "MIGUEL CONSOLADO OLIVEIRA", 71840, 9201104, 1 },
                    { 205, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 1, 1, null, "", "MIGUEL ALEXANDRE TEIXEIRA COUTINHO", 76570, 9201281, 1 },
                    { 204, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4, 1, 1, null, "", "MAURO ANDR� CRUZ DIAS", 74430, 9201185, 1 },
                    { 203, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 6, 4, 4, null, "", "MARTA INES RIBEIRO DA SILVA", 80474, 9201475, 1 },
                    { 202, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "MARTA ALEXANDRA MALVEIRO DA SILVA", 99, 99, 1 },
                    { 201, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "MARIANA CAETANO FERNANDES", 99, 99, 1 },
                    { 200, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "MARIA USURELU", 76701, 9201273, 1 },
                    { 199, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "MARIA TERESA CALADO AMADO MARTINS CORREIA", 81929, 9201543, 1 },
                    { 198, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "Maria Helena Prazeres Vanez Paula", 74432, 9201177, 1 },
                    { 197, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "MARIA DE LURDES OLIVEIRA RIBEIRO", 81322, 9201523, 1 },
                    { 195, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "LUISA FORTUNATO FERREIRA", 81073, 9201532, 1 },
                    { 194, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "LUIS MIGUEL SEGURA DA SILVA", 75933, 9201503, 1 },
                    { 193, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 1, 1, null, "", "LUIS MIGUEL MARTINS LOPES", 99, 99, 1 },
                    { 192, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "LUIS MIGUEL GUEIF�O GODINHO", 80785, 9201502, 1 },
                    { 191, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "LEONARDO SANTOS GOMES", 51650, 9201176, 1 },
                    { 189, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "LEANDRA SOFIA MORAR NUNES", 55772, 9201692, 1 },
                    { 85, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "V�TOR MANUEL DOS SANTOS LAMEIRAS", 54236, 8317, 1 },
                    { 251, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 7, 1, 1, null, "", "MARCELO MANUEL MELO RODRIGUES", 81072, 9201473, 1 },
                    { 83, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "S�LVIA CARLA MIRANDA DE SOUSA", 55249, 8294, 1 },
                    { 23, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 6, 1, null, "", "JO�O CARLOS VIEIRA CORREIA", 32660, 6625, 1 },
                    { 24, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 7, 1, null, "", "JOAO PEDRO MARQUES GERARDO", 99, 5675, 1 },
                    { 25, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "JO�O PEDRO QUINTELA ALVES SILVA", 56158, 7600, 1 },
                    { 26, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 7, 1, null, "", "JORGE MANUEL BERNARDO RIBEIRO", 47307, 5772, 1 },
                    { 27, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 7, 1, null, "", "LU�S EDUARDO BARRETO GON�ALVES", 37315, 6077, 1 },
                    { 28, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3, 6, 1, null, "", "LU�S FERNANDO MARTINS DIAS", 16048, 6621, 1 },
                    { 29, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 1, null, "", "LU�S FILIPE OLIVEIRA DE SOUSA", 52174, 6766, 1 },
                    { 30, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 1, 1, null, "", "M�RCIA DOS SANTOS MENDES", 38881, 7599, 1 },
                    { 31, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 6, 1, null, "", "MARCOS PAULO ANDRADE RODRIGUES", 52178, 6768, 1 },
                    { 32, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "MIGUEL BRANDAO DE MACEDO SANTOS", 37099, 5061, 1 },
                    { 33, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 7, 1, null, "", "NELSON PEREIRA DOS SANTOS MARQUES", 40579, 5235, 1 },
                    { 34, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "NUNO CARLOS PEREIRA GODINHO", 54538, 7019, 1 },
                    { 35, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "NUNO GON�ALO VENTURA ROCHA", 57624, 7871, 1 },
                    { 36, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "NUNO MIGUEL DUARTE GOMES", 57621, 7974, 1 },
                    { 37, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 7, 1, null, "", "NUNO MIGUEL GON�ALVES FRANCO", 46696, 5757, 1 },
                    { 38, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 7, 1, null, "", "OSCAR ZEFERINO BARRAL PEREIRA DA SILVA", 36193, 5325, 1 },
                    { 39, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "PAULO ADRIANO MATEUS RIBEIRO", 58138, 7975, 1 },
                    { 22, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 7, 1, null, "", "JAIME NELSON DOS SANTOS PINHO", 44598, 5406, 1 },
                    { 21, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 7, 1, null, "", "JAIME MAGNO MORGADO", 46701, 5756, 1 },
                    { 20, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "HENRIQUE MANUEL DA ENCARNA�AO RAMIRES DOS SANTOS", 28358, 4513, 1 },
                    { 19, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 4, null, "", "GON�ALO SANTOS NUNES DE VASCONCELOS E MENESES", 22501, 6628, 1 },
                    { 250, 1, 4, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "VITOR HUGO RAMOS SOARES", 73352, 9201540, 1 },
                    { 2, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 6, 1, null, "", "ANA CLARA MARQUES LOPES", 51706, 6619, 1 },
                    { 3, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 6, 1, null, "", "ANA FLOR PEREIRA NEVES", 51707, 6622, 1 },
                    { 4, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "ANTONIO ANGELO VITORETTI", 43872, 5382, 1 },
                    { 5, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 1, 1, null, "", "ANTONIO JORGE BAPTISTA DA ROCHA", 37797, 5057, 1 },
                    { 6, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 6, 1, null, "", "ANT�NIO JOS� SANTOS ALVES", 50544, 6627, 1 },
                    { 7, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 5, 1, null, "", "ANTONIO MIGUEL FERNANDES CAPELO", 51266, 5104, 1 },
                    { 8, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "ANT�NIO MIGUEL RODRIGUES SILVA", 31271, 6070, 1 },
                    { 40, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 6, 1, null, "", "PAULO ALEXANDRE MIRANDA DE MATOS", 48948, 6767, 1 },
                    { 9, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 7, 1, null, "", "BRUNO RICARDO ABADESSO NUNES SILVA", 6296, 6264, 1 },
                    { 11, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "CARLOS MANUEL NUNES TIAGO", 54526, 7020, 1 },
                    { 12, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 7, 1, null, "", "CIPRIAN GAVRILIUC", 44662, 5402, 1 },
                    { 13, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "F�BIO FILIPE PINTO BRANCO", 52204, 7028, 1 },
                    { 14, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "F�BIO MIGUEL FERREIRA MOTA", 48518, 5858, 1 },
                    { 15, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 7, 1, null, "", "FABIO RAFAEL RATO VARELA", 46018, 5855, 1 },
                    { 16, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 7, 1, null, "", "FERNANDO PEDRO VIDEIRA VIANA RODRIGUES", 48890, 6074, 1 },
                    { 17, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "FILIPE JOAQUIM ARAUJO DE MELO ALVES", 48511, 6061, 1 },
                    { 18, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "GIVANILDO ALVES DA SILVA", 13401, 5213, 1 },
                    { 10, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "CARLOS ALBERTO DOS SANTOS LAMEIRAS", 49770, 6798, 1 },
                    { 41, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "PAULO JORGE DE CARVALHO VALERIO", 53556, 7017, 1 },
                    { 1, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "ALBERTO MIGUEL FARIA DA COSTA", 53163, 7785, 1 },
                    { 43, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 7, 1, null, "", "PAULO MIGUEL CARMONA GROU", 47316, 5907, 1 },
                    { 66, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "ANDR� DE SOUSA FARIA COSTA", 71821, 8324, 1 },
                    { 67, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "DENISE ALEXANDRA MADUE�O FERNANDES", 58443, 8222, 1 },
                    { 68, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "EDILSON CARLOS BORGES BARROS SILVA", 71903, 8337, 1 },
                    { 69, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 1, 1, null, "", "GON�ALO LOPES FONSECA", 71824, 8295, 1 },
                    { 70, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "H�LIO MIGUEL MAGALHAES BARBOSA", 49732, 8338, 1 },
                    { 71, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "HUGO MIGUEL RODRIGUES MENDES", 71826, 8319, 1 },
                    { 42, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 4, null, "", "PAULO JORGE PIRES LOUREIRO", 51718, 6599, 1 },
                    { 73, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "JORGE MANUEL TEIXEIRA NETO", 70452, 8297, 1 },
                    { 74, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "LEANDRO DE SOUSA MARTINS", 71831, 8298, 1 },
                    { 75, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "M�RCIO IVO FERNANDES DOS SANTOS", 58450, 8223, 1 },
                    { 76, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 7, 1, 1, null, "", "PAULO JORGE ANTUNES DA SILVA", 58452, 8325, 1 },
                    { 77, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 1, 1, null, "", "PAULO JORGE DE AGUAIR ROSALIS", 71104, 8336, 1 },
                    { 78, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "PAULO JORGE DE BRITO DUARTE", 47309, 8355, 1 },
                    { 79, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 1, 1, null, "", "PAULO JORGE MILEU TEIXEIRA", 71105, 8226, 1 },
                    { 80, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 1, 1, null, "", "PEDRO CARVALHO SANDE", 51401, 8229, 1 },
                    { 81, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "PEDRO DIOGO DOS SANTOS AMARAL", 71841, 6102, 1 },
                    { 82, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "RICARDO RUA SOL", 58167, 8224, 1 },
                    { 65, 4, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 9, 2, 2, null, "", "ANA RITA DE MELO SANTOS DA CRUZ", 99, 8356, 1 },
                    { 64, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "WILLIAM SILVA GOMES JUNIOR", 46212, 6601, 1 },
                    { 72, 1, 2, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 6, 1, null, "", "JO�O JOS� HORTA NOBRE", 58439, 6811, 1 },
                    { 62, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 6, 1, null, "", "VASCO ANDR� FIGUEIREDO DA SILVA", 46137, 6624, 1 },
                    { 63, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 7, 1, null, "", "VITOR HUGO CARRILHO DA SILVA", 43826, 5379, 1 }
                });

            migrationBuilder.InsertData(
                table: "Colaborador",
                columns: new[] { "ColaboradorID", "CategoriaId", "ContratoId", "CreatedAt", "CreatedBy", "DataAdmissão", "DataFim", "DepartamentoId", "EquipaId", "FuncaoId", "HorarioContratadoId", "HorarioPraticadoId", "LastUpdatedAt", "LastUpdatedBy", "Nome", "NumCartao", "NumPw", "UhId" },
                values: new object[,]
                {
                    { 45, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 7, 1, null, "", "PEDRO MIGUEL LOUREIRO DOS SANTOS", 40516, 5383, 1 },
                    { 46, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "PEDRO RICARDO GAMBOA PEREIRA", 17068, 3564, 1 },
                    { 47, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 1, 1, null, "", "RICARDO MIGUEL SUBTIL PAULINO", 50549, 6296, 1 },
                    { 48, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 6, 1, null, "", "RODOLFO GOMES SANTOS", 28935, 5012, 1 },
                    { 49, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 1, 1, null, "", "RODRIGO NASCIMENTO SILVA LEMOS", 54610, 7022, 1 },
                    { 50, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 7, 1, null, "", "RUBEN SAMUEL DE OLIVEIRA ROCHA", 42556, 5324, 1 },
                    { 51, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 8, 6, 1, null, "", "RUI MANUEL CAMELO QUINTAS", 21869, 6765, 1 },
                    { 52, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 5, 1, 1, null, "", "RUI MIGUEL MEDINA SILVA", 53540, 6848, 1 },
                    { 44, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "PEDRO FILIPE RAPOSO SANTOS", 42704, 5326, 1 },
                    { 54, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, 7, 1, null, "", "SANDRO MIGUEL GUINCHO FERREIRA", 50542, 6266, 1 },
                    { 55, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 5, 1, null, "", "S�RGIO FILIPE GOMES RODRIGUES", 53549, 6812, 1 },
                    { 56, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 8, 1, 1, null, "", "S�RGIO LU�S BRITO FARINHA", 51721, 6600, 1 },
                    { 57, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "SERGIO MIGUEL DOS SANTOS HENRIQUE", 42778, 5328, 1 },
                    { 58, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 1, null, "", "S�RGIO MIGUEL MARIA PEREIRA", 52177, 6764, 1 },
                    { 59, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 8, 6, 1, null, "", "SUSANA CRISTINA PEREIRA DA LUZ", 52180, 6763, 1 },
                    { 60, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 7, 1, null, "", "TIAGO LUIS FERR�O DA SILVA", 43825, 5419, 1 },
                    { 61, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 7, 1, null, "", "TIAGO PIMENTA CORTEGA�A", 48887, 6065, 1 },
                    { 53, 1, 3, new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "rui.santos@portway.pt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, 7, 1, null, "", "RUI PEDRO DE OLIVEIRA CARDOSO", 46699, 5758, 1 }
                });

            migrationBuilder.InsertData(
                table: "Stands",
                columns: new[] { "StandId", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "PlataformaId", "Remoto", "StandN" },
                values: new object[,]
                {
                    { 29, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 206 },
                    { 28, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 205 },
                    { 24, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 201 },
                    { 26, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 203 },
                    { 25, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 202 },
                    { 30, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 207 },
                    { 27, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 204 },
                    { 31, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 208 },
                    { 35, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, true, 223 },
                    { 33, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, true, 221 },
                    { 34, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, true, 222 },
                    { 36, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, true, 224 },
                    { 37, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 3, true, 225 },
                    { 38, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, true, 301 },
                    { 39, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, true, 302 },
                    { 40, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, true, 401 },
                    { 32, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 209 },
                    { 23, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 2, true, 200 },
                    { 2, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, true, 105 },
                    { 21, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 146 },
                    { 41, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, true, 402 },
                    { 3, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, true, 106 },
                    { 4, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 107 },
                    { 5, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, true, 108 },
                    { 7, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 114 },
                    { 8, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 115 },
                    { 9, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 116 },
                    { 10, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 117 },
                    { 22, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 147 },
                    { 11, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 122 },
                    { 13, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 124 },
                    { 14, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 125 },
                    { 15, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 126 },
                    { 16, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 141 },
                    { 17, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 142 },
                    { 18, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 143 },
                    { 19, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 144 },
                    { 20, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 145 },
                    { 12, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, false, 123 },
                    { 42, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, true, 403 },
                    { 64, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 506 },
                    { 44, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, true, 405 },
                    { 69, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 605 },
                    { 70, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 606 },
                    { 71, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 607 },
                    { 72, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 608 },
                    { 73, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 609 },
                    { 74, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 701 },
                    { 75, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 702 },
                    { 76, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 703 },
                    { 77, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 704 },
                    { 78, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 705 },
                    { 79, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 706 },
                    { 80, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 801 },
                    { 81, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 802 },
                    { 82, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 803 },
                    { 83, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 804 },
                    { 84, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 805 },
                    { 85, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 6, true, 806 },
                    { 68, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 604 },
                    { 43, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 4, true, 404 },
                    { 67, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 603 },
                    { 65, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 601 },
                    { 45, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 411 },
                    { 47, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 412 },
                    { 48, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 413 },
                    { 49, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 414 },
                    { 50, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 415 },
                    { 51, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 416 },
                    { 52, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 421 },
                    { 53, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 422 },
                    { 54, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 423 },
                    { 55, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 424 },
                    { 56, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 425 },
                    { 57, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 426 },
                    { 58, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 501 },
                    { 59, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 502 },
                    { 60, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 503 },
                    { 61, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 504 },
                    { 62, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 505 },
                    { 66, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 5, true, 602 },
                    { 1, new DateTime(2018, 10, 25, 11, 23, 39, 719, DateTimeKind.Unspecified).AddTicks(6886), "SISTEMA", null, null, 1, true, 104 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stands_StandN",
                table: "Stands",
                column: "StandN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stagings_StatusId",
                table: "Stagings",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portas");

            migrationBuilder.DropTable(
                name: "Stagings");

            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_Stands_StandN",
                table: "Stands");

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Colaborador",
                keyColumn: "ColaboradorID",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Stands",
                keyColumn: "StandId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Uh",
                keyColumn: "UhId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uh",
                keyColumn: "UhId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Uh",
                keyColumn: "UhId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contrato",
                keyColumn: "ContratoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contrato",
                keyColumn: "ContratoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contrato",
                keyColumn: "ContratoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contrato",
                keyColumn: "ContratoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departamento",
                keyColumn: "DepartamentoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipa",
                keyColumn: "EquipaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipa",
                keyColumn: "EquipaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipa",
                keyColumn: "EquipaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipa",
                keyColumn: "EquipaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Funcao",
                keyColumn: "FuncaoId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Horario",
                keyColumn: "HorarioId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Plataformas",
                keyColumn: "PlataformaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plataformas",
                keyColumn: "PlataformaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plataformas",
                keyColumn: "PlataformaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plataformas",
                keyColumn: "PlataformaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plataformas",
                keyColumn: "PlataformaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Plataformas",
                keyColumn: "PlataformaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Uh",
                keyColumn: "UhId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "StandN",
                table: "Stands",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Colaborador",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_StatusId",
                table: "Colaborador",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Status_StatusId",
                table: "Colaborador",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
