using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas2.Migrations
{
    public partial class tarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeExecuta",
                table: "Tarefa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeExecuta",
                table: "Tarefa");
        }
    }
}
