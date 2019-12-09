using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas2.Migrations.Tarefas
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTarefa = table.Column<string>(maxLength: 60, nullable: true),
                    NomeOrdena = table.Column<string>(maxLength: 60, nullable: true),
                    NomeExecuta = table.Column<string>(maxLength: 60, nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposTarefas",
                columns: table => new
                {
                    TipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTarefa = table.Column<string>(nullable: true),
                    TarefasTarefaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTarefas", x => x.TipoId);
                    table.ForeignKey(
                        name: "FK_TiposTarefas_Tarefas_TarefasTarefaId",
                        column: x => x.TarefasTarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "TarefaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiposTarefas_TarefasTarefaId",
                table: "TiposTarefas",
                column: "TarefasTarefaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposTarefas");

            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
