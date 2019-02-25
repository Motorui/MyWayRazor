using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class AddTablesPlataformaStand : Migration
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
                    Voo = table.Column<string>(nullable: true),
                    Mov = table.Column<string>(nullable: true),
                    OrigDest = table.Column<string>(nullable: true),
                    Pax = table.Column<string>(nullable: true),
                    SSR = table.Column<string>(nullable: true),
                    AC = table.Column<string>(nullable: true),
                    Stand = table.Column<string>(nullable: true),
                    Exit = table.Column<string>(nullable: true),
                    CkIn = table.Column<string>(nullable: true),
                    Gate = table.Column<string>(nullable: true),
                    Transferencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistenciasPRMS", x => x.ID);
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
                name: "Stands",
                columns: table => new
                {
                    StandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StandN = table.Column<string>(nullable: false),
                    Remoto = table.Column<bool>(nullable: false),
                    PlataformaId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stands", x => x.StandId);
                    table.ForeignKey(
                        name: "FK_Stands_Plataformas_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataformas",
                        principalColumn: "PlataformaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stands_PlataformaId",
                table: "Stands",
                column: "PlataformaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "AssistenciasPRMS");

            migrationBuilder.DropTable(
                name: "Stands");

            migrationBuilder.DropTable(
                name: "Plataformas");
        }
    }
}
