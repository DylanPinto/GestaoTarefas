using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public static class SeedData
    {
        public static void Populate(GestaoTarefasDbContext db)
        {
            PopulateDepartamentos(db);
            PopulateCargos(db);
            PopulateTiposTarefas(db);
            PopulateFuncionarios(db);
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
        private static void PopulateTiposTarefas(GestaoTarefasDbContext db)
        {
            if (db.TiposTarefas.Any()) return;

            db.TiposTarefas.AddRange(
                new TiposTarefas { TipoTarefa = "Comprar" },
                new TiposTarefas { TipoTarefa = "Transporte" },
                new TiposTarefas { TipoTarefa = "Manutenção" },
                new TiposTarefas { TipoTarefa = "Limpeza" },
                new TiposTarefas { TipoTarefa = "Outra" }
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
    }
}
