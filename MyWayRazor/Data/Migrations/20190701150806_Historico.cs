using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class Historico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoAssistencias",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Msg = table.Column<string>(nullable: true),
                    Aeroporto = table.Column<string>(nullable: true),
                    Notif = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    DataContacto = table.Column<DateTime>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: true),
                    DataFim = table.Column<DateTime>(nullable: true),
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
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAssistencias", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoAssistencias");
        }
    }
}
