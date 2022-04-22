using Microsoft.EntityFrameworkCore.Migrations;

namespace SITHEC.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humanos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Sexo = table.Column<bool>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Altura = table.Column<int>(nullable: false),
                    Peso = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humanos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Humanos",
                columns: new[] { "Id", "Altura", "Edad", "Nombre", "Peso", "Sexo" },
                values: new object[] { 1, 168, 29, "Diego", 95.0, false });

            migrationBuilder.InsertData(
                table: "Humanos",
                columns: new[] { "Id", "Altura", "Edad", "Nombre", "Peso", "Sexo" },
                values: new object[] { 2, 175, 25, "Ronaldo", 98.5, false });

            migrationBuilder.InsertData(
                table: "Humanos",
                columns: new[] { "Id", "Altura", "Edad", "Nombre", "Peso", "Sexo" },
                values: new object[] { 3, 165, 33, "Danai", 60.0, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humanos");
        }
    }
}
