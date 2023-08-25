using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alquilautos.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idMarca = table.Column<int>(type: "int", nullable: false),
                    idConductor = table.Column<int>(type: "int", nullable: false),
                    idPropietario = table.Column<int>(type: "int", nullable: false),
                    idTenedor = table.Column<int>(type: "int", nullable: false),
                    vencimientoSoat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
