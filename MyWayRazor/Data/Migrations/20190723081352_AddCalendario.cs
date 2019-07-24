using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class AddCalendario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    DateKey = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Day = table.Column<byte>(nullable: false),
                    DaySuffix = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    Weekday = table.Column<byte>(nullable: false),
                    WeekDayName = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    IsWeekend = table.Column<bool>(nullable: false),
                    IsHoliday = table.Column<bool>(nullable: false),
                    HolidayText = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    DOWInMonth = table.Column<byte>(nullable: false),
                    DayOfYear = table.Column<short>(nullable: false),
                    WeekOfMonth = table.Column<byte>(nullable: false),
                    WeekOfYear = table.Column<byte>(nullable: false),
                    ISOWeekOfYear = table.Column<byte>(nullable: false),
                    Month = table.Column<byte>(nullable: false),
                    MonthName = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Quarter = table.Column<byte>(nullable: false),
                    QuarterName = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    MMYYYY = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    MonthYear = table.Column<string>(unicode: false, maxLength: 7, nullable: false),
                    FirstDayOfMonth = table.Column<DateTime>(type: "date", nullable: false),
                    LastDayOfMonth = table.Column<DateTime>(type: "date", nullable: false),
                    FirstDayOfQuarter = table.Column<DateTime>(type: "date", nullable: false),
                    LastDayOfQuarter = table.Column<DateTime>(type: "date", nullable: false),
                    FirstDayOfYear = table.Column<DateTime>(type: "date", nullable: false),
                    LastDayOfYear = table.Column<DateTime>(type: "date", nullable: false),
                    FirstDayOfNextMonth = table.Column<DateTime>(type: "date", nullable: false),
                    FirstDayOfNextYear = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.DateKey);
                });

            migrationBuilder.CreateTable(
                name: "Formadores",
                columns: table => new
                {
                    FormadorID = table.Column<Guid>(nullable: false),
                    FormadorNome = table.Column<string>(maxLength: 50, nullable: false),
                    FormacaoId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formadores", x => x.FormadorID);
                    table.ForeignKey(
                        name: "FK_Formadores_Formacoes_FormacaoId",
                        column: x => x.FormacaoId,
                        principalTable: "Formacoes",
                        principalColumn: "FormacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaID = table.Column<Guid>(nullable: false),
                    SalaNome = table.Column<string>(maxLength: 50, nullable: false),
                    Capacidade = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formadores_FormacaoId",
                table: "Formadores",
                column: "FormacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "Formadores");

            migrationBuilder.DropTable(
                name: "Salas");

        }
    }
}
