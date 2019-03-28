using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWayRazor.Data.Migrations
{
    public partial class FixStandNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Stand",
                table: "AssistenciasPRMS",
                nullable: true,
                defaultValue: "0",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParamID",
                keyValue: "1",
                column: "ParamValue",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParamID",
                keyValue: "2",
                column: "ParamValue",
                value: 180);

            //migrationBuilder.InsertData(
            //    table: "Parametros",
            //    columns: new[] { "ParamID", "CreatedAt", "CreatedBy", "LastUpdatedAt", "LastUpdatedBy", "ParamDesc", "ParamNome", "ParamValue" },
            //    values: new object[,]
            //    {
            //        { "3", new DateTime(2019, 2, 26, 15, 35, 0, 0, DateTimeKind.Unspecified), "SISTEMA", null, null, "Quantidade de ambulift's necessários vs num PAP", "NAmbulift", 4 },
            //        { "4", new DateTime(2019, 2, 26, 15, 35, 0, 0, DateTimeKind.Unspecified), null, null, null, "Quantidade de VTA's necessárias vs pmr no voo", "NVta", 5 }
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "ParamID",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "ParamID",
                keyValue: "4");

            migrationBuilder.AlterColumn<string>(
                name: "Stand",
                table: "AssistenciasPRMS",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "0");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParamID",
                keyValue: "1",
                column: "ParamValue",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "ParamID",
                keyValue: "2",
                column: "ParamValue",
                value: 0);
        }
    }
}
