using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Migrations.MywayDb
{
    public partial class FixColaboradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Horario_HorarioId",
                table: "Colaborador");

            migrationBuilder.RenameColumn(
                name: "HorarioId",
                table: "Colaborador",
                newName: "ColaboradorHorarioPraticadoIdHorarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Colaborador_HorarioId",
                table: "Colaborador",
                newName: "IX_Colaborador_ColaboradorHorarioPraticadoIdHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_HorarioContratadoId",
                table: "Colaborador",
                column: "HorarioContratadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Horario_ColaboradorHorarioPraticadoIdHorarioId",
                table: "Colaborador",
                column: "ColaboradorHorarioPraticadoIdHorarioId",
                principalTable: "Horario",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Horario_HorarioContratadoId",
                table: "Colaborador",
                column: "HorarioContratadoId",
                principalTable: "Horario",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Horario_ColaboradorHorarioPraticadoIdHorarioId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Horario_HorarioContratadoId",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_HorarioContratadoId",
                table: "Colaborador");

            migrationBuilder.RenameColumn(
                name: "ColaboradorHorarioPraticadoIdHorarioId",
                table: "Colaborador",
                newName: "HorarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Colaborador_ColaboradorHorarioPraticadoIdHorarioId",
                table: "Colaborador",
                newName: "IX_Colaborador_HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Horario_HorarioId",
                table: "Colaborador",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
