using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas2.Migrations
{
    public partial class tarefasUpdatev6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_TiposTarefas_TiposTarefasTipoId",
                table: "Tarefa");

            migrationBuilder.DropTable(
                name: "TiposTarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_TiposTarefasTipoId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "TiposTarefasTipoId",
                table: "Tarefa");

            migrationBuilder.AddColumn<int>(
                name: "TipoTarefaTipoId",
                table: "Tarefa",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoTarefa",
                columns: table => new
                {
                    TipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTarefa", x => x.TipoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_TipoTarefaTipoId",
                table: "Tarefa",
                column: "TipoTarefaTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_TipoTarefa_TipoTarefaTipoId",
                table: "Tarefa",
                column: "TipoTarefaTipoId",
                principalTable: "TipoTarefa",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_TipoTarefa_TipoTarefaTipoId",
                table: "Tarefa");

            migrationBuilder.DropTable(
                name: "TipoTarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_TipoTarefaTipoId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "TipoTarefaTipoId",
                table: "Tarefa");

            migrationBuilder.AddColumn<int>(
                name: "TiposTarefasTipoId",
                table: "Tarefa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposTarefas",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTarefa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTarefas", x => x.TipoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_TiposTarefasTipoId",
                table: "Tarefa",
                column: "TiposTarefasTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_TiposTarefas_TiposTarefasTipoId",
                table: "Tarefa",
                column: "TiposTarefasTipoId",
                principalTable: "TiposTarefas",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
