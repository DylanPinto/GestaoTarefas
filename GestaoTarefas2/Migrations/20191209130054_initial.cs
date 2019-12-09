using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefas2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiposTarefas_Tarefas_TarefasTarefaId",
                table: "TiposTarefas");

            migrationBuilder.DropIndex(
                name: "IX_TiposTarefas_TarefasTarefaId",
                table: "TiposTarefas");

            migrationBuilder.DropColumn(
                name: "TarefasTarefaId",
                table: "TiposTarefas");

            migrationBuilder.DropColumn(
                name: "NomeExecuta",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Tarefas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncionariosFuncionarioId",
                table: "Tarefas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Tarefas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TiposTarefasTipoId",
                table: "Tarefas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    SobreNome = table.Column<string>(maxLength: 60, nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    NTelemovel = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    DepartamentosDepartamentoId = table.Column<int>(nullable: true),
                    CargoId = table.Column<int>(nullable: false),
                    CargosCargoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Cargos_CargosCargoId",
                        column: x => x.CargosCargoId,
                        principalTable: "Cargos",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentosDepartamentoId",
                        column: x => x.DepartamentosDepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_FuncionariosFuncionarioId",
                table: "Tarefas",
                column: "FuncionariosFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_TiposTarefasTipoId",
                table: "Tarefas",
                column: "TiposTarefasTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargosCargoId",
                table: "Funcionarios",
                column: "CargosCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentosDepartamentoId",
                table: "Funcionarios",
                column: "DepartamentosDepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Funcionarios_FuncionariosFuncionarioId",
                table: "Tarefas",
                column: "FuncionariosFuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_TiposTarefas_TiposTarefasTipoId",
                table: "Tarefas",
                column: "TiposTarefasTipoId",
                principalTable: "TiposTarefas",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Funcionarios_FuncionariosFuncionarioId",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_TiposTarefas_TiposTarefasTipoId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_FuncionariosFuncionarioId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_TiposTarefasTipoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "FuncionariosFuncionarioId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "TiposTarefasTipoId",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "TarefasTarefaId",
                table: "TiposTarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeExecuta",
                table: "Tarefas",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposTarefas_TarefasTarefaId",
                table: "TiposTarefas",
                column: "TarefasTarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposTarefas_Tarefas_TarefasTarefaId",
                table: "TiposTarefas",
                column: "TarefasTarefaId",
                principalTable: "Tarefas",
                principalColumn: "TarefaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
