using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TikRandevu.Modules.Suppliers.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Suppliers");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Suppliers",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FullAddress = table.Column<string>(type: "text", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 9, 19, 10, 10, 50, 842, DateTimeKind.Utc).AddTicks(6410)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProvisions",
                schema: "Suppliers",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    ProvisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 9, 19, 10, 10, 50, 843, DateTimeKind.Utc).AddTicks(1340)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProvisions", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_SupplierProvisions_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Suppliers",
                        principalTable: "Suppliers",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierRezervations",
                schema: "Suppliers",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    ProvisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    RezervationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 9, 19, 10, 10, 50, 843, DateTimeKind.Utc).AddTicks(2080)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierRezervations", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_SupplierRezervations_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Suppliers",
                        principalTable: "Suppliers",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProvisions_SupplierId",
                schema: "Suppliers",
                table: "SupplierProvisions",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierRezervations_SupplierId",
                schema: "Suppliers",
                table: "SupplierRezervations",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Name",
                schema: "Suppliers",
                table: "Suppliers",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierProvisions",
                schema: "Suppliers");

            migrationBuilder.DropTable(
                name: "SupplierRezervations",
                schema: "Suppliers");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Suppliers");
        }
    }
}
