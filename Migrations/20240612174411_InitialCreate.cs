using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace estacionamento_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_establishments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    document = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    telephone = table.Column<string>(type: "text", nullable: false),
                    motorcycle_spaces = table.Column<int>(type: "integer", nullable: false),
                    car_spaces = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_establishments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    license_plate = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_vehicles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_movimentations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false),
                    establishment_id = table.Column<int>(type: "integer", nullable: false),
                    check_in_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    checkout_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_movimentations", x => x.id);
                    table.ForeignKey(
                        name: "fk_tb_movimentations_tb_establishments_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "tb_establishments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tb_movimentations_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "tb_vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tb_movimentations_establishment_id",
                table: "tb_movimentations",
                column: "establishment_id");

            migrationBuilder.CreateIndex(
                name: "ix_tb_movimentations_vehicle_id",
                table: "tb_movimentations",
                column: "vehicle_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_movimentations");

            migrationBuilder.DropTable(
                name: "tb_establishments");

            migrationBuilder.DropTable(
                name: "tb_vehicles");
        }
    }
}
