using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberEaseApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hashed_password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "establishments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hashed_password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    owner_first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    owner_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cep = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_establishments", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "id", "city", "created_at", "email", "first_name", "hashed_password", "last_name", "phone", "state", "updated_at" },
                values: new object[] { new Guid("2b9923da-c7c0-4b7e-8d74-ea9cbe483bcf"), "São Paulo", new DateTime(2024, 5, 11, 1, 11, 46, 87, DateTimeKind.Utc).AddTicks(3907), "client@default.com", "Client", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "Default", "119123456789", "São Paulo", new DateTime(2024, 5, 11, 1, 11, 46, 87, DateTimeKind.Utc).AddTicks(3911) });

            migrationBuilder.InsertData(
                table: "establishments",
                columns: new[] { "id", "address", "cep", "city", "cnpj", "company_name", "created_at", "email", "hashed_password", "owner_first_name", "owner_last_name", "phone", "state", "updated_at" },
                values: new object[] { new Guid("d792532b-7aee-4249-9d28-5f0ab98a682c"), "Rua Francisco Salzillo", "03923087", "São Paulo", "72835673000172", "Establishment Default", new DateTime(2024, 5, 11, 1, 11, 46, 87, DateTimeKind.Utc).AddTicks(4492), "establishment@default.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "Establishment", "Default", "119123456789", "São Paulo", new DateTime(2024, 5, 11, 1, 11, 46, 87, DateTimeKind.Utc).AddTicks(4494) });

            migrationBuilder.CreateIndex(
                name: "IX_clients_email",
                table: "clients",
                column: "email",
                unique: true);

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
                name: "clients");

            migrationBuilder.DropTable(
                name: "establishments");
        }
    }
}
