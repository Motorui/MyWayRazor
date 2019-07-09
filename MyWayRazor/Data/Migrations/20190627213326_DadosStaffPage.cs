using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class DadosStaffPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosAeroportos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Mov = table.Column<string>(nullable: true),
                    Reg = table.Column<string>(nullable: true),
                    Voo = table.Column<string>(nullable: true),
                    EstimatedTime = table.Column<DateTime>(nullable: true),
                    ScheduleTime = table.Column<DateTime>(nullable: true),
                    ActualTime = table.Column<DateTime>(nullable: true),
                    BlockTime = table.Column<DateTime>(nullable: true),
                    BeginBRD = table.Column<DateTime>(nullable: true),
                    EndBRD = table.Column<DateTime>(nullable: true),
                    EstimatedTimeUTC = table.Column<DateTime>(nullable: true),
                    ScheduleTimeUTC = table.Column<DateTime>(nullable: true),
                    ActualTimeUTC = table.Column<DateTime>(nullable: true),
                    BlockTimeUTC = table.Column<DateTime>(nullable: true),
                    BeginBRDUTC = table.Column<DateTime>(nullable: true),
                    EndBRDUTC = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosAeroportos", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosAeroportos");
        }
    }
}
