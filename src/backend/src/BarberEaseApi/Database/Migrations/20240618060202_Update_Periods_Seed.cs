using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberEaseApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class Update_Periods_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("182cde4a-b74d-49a9-a2ec-59d1a82c2e68"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00", "09:00", "00:30" });

            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("30813908-3985-42c2-8cee-0b7fde58a1be"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00", "09:00", "00:30" });

            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("58695664-a938-4dc7-9384-54616a77ad9f"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00", "09:00", "00:30" });

            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("cdb52f2e-04e2-466c-8154-1403eb4aed63"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00", "09:00", "00:30" });

            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("ecf07789-b490-4c26-acc7-8acd123767b6"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00", "09:00", "00:30" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("182cde4a-b74d-49a9-a2ec-59d1a82c2e68"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00:00", "09:00:00", "00:30:00" });

            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("30813908-3985-42c2-8cee-0b7fde58a1be"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00:00", "09:00:00", "00:30:00" });

            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("58695664-a938-4dc7-9384-54616a77ad9f"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00:00", "09:00:00", "00:30:00" });

            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("cdb52f2e-04e2-466c-8154-1403eb4aed63"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00:00", "09:00:00", "00:30:00" });

            migrationBuilder.UpdateData(
                table: "establishment_periods",
                keyColumn: "id",
                keyValue: new Guid("ecf07789-b490-4c26-acc7-8acd123767b6"),
                columns: new[] { "closing_time", "opening_time", "time_between_service" },
                values: new object[] { "18:00:00", "09:00:00", "00:30:00" });
        }
    }
}
