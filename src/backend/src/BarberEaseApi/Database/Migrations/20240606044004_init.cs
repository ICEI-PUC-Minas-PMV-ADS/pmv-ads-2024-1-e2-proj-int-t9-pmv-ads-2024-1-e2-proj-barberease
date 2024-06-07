using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    hashed_password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "establishment_services",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    category = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    establishment_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_establishment_services", x => x.id);
                    table.ForeignKey(
                        name: "FK_establishment_services_establishments_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "establishments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    client_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    establishment_service_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointments_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_establishment_services_establishment_service_id",
                        column: x => x.establishment_service_id,
                        principalTable: "establishment_services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "id", "city", "created_at", "email", "first_name", "hashed_password", "last_name", "phone", "state", "updated_at" },
                values: new object[] { new Guid("ba997890-aa6a-4c10-bbad-c930a19b119f"), "São Paulo", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local), "client@default.com", "Client", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "Default", "119123456789", "São Paulo", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "establishments",
                columns: new[] { "id", "address", "cep", "city", "cnpj", "company_name", "created_at", "email", "hashed_password", "owner_first_name", "owner_last_name", "phone", "state", "updated_at" },
                values: new object[] { new Guid("db279123-e792-44aa-9c43-87c869ff5abd"), "Rua Francisco Salzillo", "03923087", "São Paulo", "72835673000172", "Establishment Default", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local), "establishment@default.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "Establishment", "Default", "119123456789", "São Paulo", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "establishment_services",
                columns: new[] { "id", "category", "created_at", "description", "establishment_id", "name", "price", "updated_at" },
                values: new object[,]
                {
                    { new Guid("18e9b482-7c3e-4db5-8c40-3d79c9ac4f66"), "Corte de Cabelo", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local), null, new Guid("db279123-e792-44aa-9c43-87c869ff5abd"), "Corte de Cabelo Masculino", 50.0, new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local) },
                    { new Guid("21e79cb3-9385-4f9c-9e55-28c6c3b0a8bc"), "Barba", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local), null, new Guid("db279123-e792-44aa-9c43-87c869ff5abd"), "Barba Completa", 35.0, new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local) },
                    { new Guid("cffb2e84-71a1-4977-afb2-13197662210b"), "Sobrancelha", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local), null, new Guid("db279123-e792-44aa-9c43-87c869ff5abd"), "Design de Sobrancelhas", 25.0, new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "client_id", "created_at", "date", "establishment_service_id", "status", "updated_at" },
                values: new object[,]
                {
                    { new Guid("7f16ad90-8d07-42ac-9257-dbb2a9aa7343"), new Guid("ba997890-aa6a-4c10-bbad-c930a19b119f"), new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local), new DateTime(2024, 6, 6, 10, 0, 0, 0, DateTimeKind.Local), new Guid("cffb2e84-71a1-4977-afb2-13197662210b"), "RECEIVED", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local) },
                    { new Guid("9454ae1e-38a0-4a24-86e4-548e672c6396"), new Guid("ba997890-aa6a-4c10-bbad-c930a19b119f"), new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local), new DateTime(2024, 6, 6, 9, 30, 0, 0, DateTimeKind.Local), new Guid("21e79cb3-9385-4f9c-9e55-28c6c3b0a8bc"), "CANCELLED", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local) },
                    { new Guid("aa4f97ba-514e-4964-a2f2-f639d2400aa6"), new Guid("ba997890-aa6a-4c10-bbad-c930a19b119f"), new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local), new DateTime(2024, 6, 6, 9, 0, 0, 0, DateTimeKind.Local), new Guid("18e9b482-7c3e-4db5-8c40-3d79c9ac4f66"), "CONFIRMED", new DateTime(2024, 6, 5, 21, 41, 32, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_client_id",
                table: "appointments",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_establishment_service_id",
                table: "appointments",
                column: "establishment_service_id");

            migrationBuilder.CreateIndex(
                name: "IX_clients_email",
                table: "clients",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_establishment_services_establishment_id",
                table: "establishment_services",
                column: "establishment_id");

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
                name: "appointments");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "establishment_services");

            migrationBuilder.DropTable(
                name: "establishments");
        }
    }
}
