using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberEaseApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialEstablishmentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "establishments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    hashed_password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    company_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    owner_first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    owner_last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    cep = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_establishments", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_establishments_cnpj",
                table: "establishments",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_establishments_email",
                table: "establishments",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "establishments");
        }
    }
}
