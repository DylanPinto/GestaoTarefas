using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas2.Migrations
{
    public partial class updateTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeOrdena",
                table: "Tarefa");

            migrationBuilder.AddColumn<string>(
                name: "NomeDestinatario",
                table: "Tarefa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "estadoTarefa",
                table: "Tarefa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDestinatario",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "estadoTarefa",
                table: "Tarefa");

            migrationBuilder.AddColumn<string>(
                name: "NomeOrdena",
                table: "Tarefa",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);
        }
    }
}
