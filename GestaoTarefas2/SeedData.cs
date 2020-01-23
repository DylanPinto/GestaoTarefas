using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public static class SeedData
    {
        private const string ADMIN_ROLE = "admin";
        private const string MANAGER_ROLE = "manager";
        private const string FUNC_ROLE = "funcionario";
        public static void Populate(GestaoTarefasDbContext db)
        {
            PopulateDepartamentos(db);
            PopulateCargos(db);
            PopulateTipoTarefa(db);
            PopulateFuncionarios(db);
            PopulateTarefas(db);
        }
        public static void PopulateDepartamentos(GestaoTarefasDbContext db)
        {
            if (db.Departamento.Any()) return;
            

            db.Departamento.AddRange(
                new Departamento { Nome = "Informática" },
                new Departamento { Nome = "Contabilidade" },
                new Departamento { Nome = "Civil" },
                new Departamento { Nome = "Bar" },
                new Departamento { Nome = "Cantina" },
                new Departamento { Nome = "Secretaria" },
                new Departamento { Nome = "Manutenção" }
                );
            db.SaveChanges();
        }

        private static void PopulateCargos(GestaoTarefasDbContext db)
        {
            if (db.Cargo.Any()) return;

            db.Cargo.AddRange(
                new Cargo { NomeCargo = "Diretor" },
                new Cargo { NomeCargo = "Funcionário" },
                new Cargo { NomeCargo = "Professor" },
                new Cargo { NomeCargo = "Estagiário" }
                );
            db.SaveChanges();
        }
        private static void PopulateTipoTarefa(GestaoTarefasDbContext db)
        {
            if (db.TipoTarefa.Any()) return;

            db.TipoTarefa.AddRange(
                new TipoTarefa { TipoNome = "Comprar" },
                new TipoTarefa { TipoNome = "Transporte" },
                new TipoTarefa { TipoNome = "Manutenção" },
                new TipoTarefa { TipoNome = "Limpeza" },
                new TipoTarefa { TipoNome = "Outra" }
                );
            db.SaveChanges();
        }

        private static void PopulateFuncionarios(GestaoTarefasDbContext db)
        {
            if (db.Funcionario.Any()) return;

            db.Funcionario.AddRange(
               new Funcionario { Nome = "Dylan", SobreNome = "Pinto", Sexo = "Masculino", NTelemovel = "912123456", Email = "pinto@ipg.pt", DepartamentoId = 2, CargoId = 2},
               new Funcionario { Nome = "Martim", SobreNome = "Costa", Sexo = "Masculino", NTelemovel = "912123123", Email = "costa@ipg.pt", DepartamentoId = 1, CargoId = 1 },
               new Funcionario { Nome = "Alberto", SobreNome = "Melo", Sexo = "Masculino", NTelemovel = "932123456", Email = "melo@ipg.pt", DepartamentoId = 7, CargoId = 3 },
               new Funcionario { Nome = "Paulo", SobreNome = "Barrosa", Sexo = "Masculino", NTelemovel = "932123456", Email = "barrosa@ipg.pt", DepartamentoId = 5, CargoId = 1 }
                );
            db.SaveChanges();
        }

        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager)
        {
            const string ADMIN_USERNAME = "Admin";
            const string ADMIN_EMAIL = "admin@ipg.pt";
            const string ADMIN_PASSWORD = "Secret123$";

            const string MANAGER_USERNAME = "Peter";
            const string MANAGER_EMAIL = "peter@ipg.pt";
            const string MANAGER_PASSWORD = "Secret123$";

            const string FUNC_USERNAME = "Paulo";
            const string FUNC_EMAIL = "paulo@ipg.pt";
            const string FUNC_PASSWORD = "Secret123$";

            IdentityUser user = await userManager.FindByNameAsync(ADMIN_USERNAME);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = ADMIN_USERNAME,
                    Email = ADMIN_EMAIL
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, ADMIN_ROLE))
            {
                await userManager.AddToRoleAsync(user, ADMIN_ROLE);
            }

            user = await userManager.FindByNameAsync(MANAGER_USERNAME);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = MANAGER_USERNAME,
                    Email = MANAGER_EMAIL
                };

                await userManager.CreateAsync(user, MANAGER_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, MANAGER_ROLE))
            {
                await userManager.AddToRoleAsync(user, MANAGER_ROLE);
            }

            user = await userManager.FindByNameAsync(FUNC_USERNAME);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = FUNC_USERNAME,
                    Email = FUNC_EMAIL
                };

                await userManager.CreateAsync(user, FUNC_PASSWORD);
            }
            if (!await userManager.IsInRoleAsync(user, FUNC_ROLE))
            {
                await userManager.AddToRoleAsync(user, FUNC_ROLE);
            }


            // Create other user accounts ...
        }

       

       

        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {


            if (!await roleManager.RoleExistsAsync(ADMIN_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(MANAGER_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(MANAGER_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(FUNC_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(FUNC_ROLE));
            }
        }

        public static void PopulateTarefas(GestaoTarefasDbContext db)
        {
            if (db.Tarefa.Any()) return;


            db.Tarefa.AddRange(
                new Tarefa { NomeTarefa = "Aquecedores", NomeOrdena = "Martim", FuncionarioId = 2, DataInicio = DateTime.Parse("12-01-2020"), DataFim = DateTime.Parse("15-01-2020"), TipoId = 3, Descricao = "Arranjar os aquecedores da sala de informática", estadoTarefa = "Incompleta" },
                new Tarefa { NomeTarefa = "Wi-fi", NomeOrdena = "Dylan", FuncionarioId = 3, DataInicio = DateTime.Parse("02-02-2020"), DataFim = DateTime.Parse("03-02-2020"), TipoId = 3, Descricao = "Não existe internet no departamento de contabilidade", estadoTarefa = "Incompleta" },
                new Tarefa { NomeTarefa = "Orçamento", NomeOrdena = "Paulo", FuncionarioId = 4, DataInicio = DateTime.Parse("22-03-2020"), DataFim = DateTime.Parse("23-03-2020"), TipoId = 5, Descricao = "Fazer um orçamento para renovar os materiais da cantina ", estadoTarefa = "Incompleta" },
                new Tarefa { NomeTarefa = "Ementa", NomeOrdena = "Dylan", FuncionarioId = 1, DataInicio = DateTime.Parse("29-04-2020"), DataFim = DateTime.Parse("15-05-2020"), TipoId = 5, Descricao = "Ementa para o dia de Erasmus", estadoTarefa = "Incompleta" }
                );
            db.SaveChanges();
        }
    }
}
