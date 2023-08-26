using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alquilautos.Migrations
{
    /// <inheritdoc />
    public partial class VehiculosDep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "potMotor",
                table: "Vehiculos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "velMax",
                table: "Vehiculos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "potMotor",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "velMax",
                table: "Vehiculos");
        }
    }
}
