using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas2.Migrations
{
    public partial class teste4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Tarefa");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Tarefa",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Tarefa");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Tarefa",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
