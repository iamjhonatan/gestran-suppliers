using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestranSuppliers.Migrations
{
    /// <inheritdoc />
    public partial class AdjustAllProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    PublicPlace = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Complement = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    City = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    State = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Country = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SupplierId",
                table: "Addresses",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
