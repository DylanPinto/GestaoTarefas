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
        }

       

        private static void PopulateCargos(GestaoTarefasDbContext db)
        {
            if (db.Cargo.Any()) return;

            db.Cargo.AddRange(
                new Cargo { NomeCargo = "Diretor"},
                new Cargo { NomeCargo = "Funcionário" },
                new Cargo { NomeCargo = "Professor" },
                new Cargo { NomeCargo = "Estagiário" }
                );
            db.SaveChanges();
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
                new Departamento { Nome = "Manutenção" },
                new Departamento { Nome = "Tesouraria" }
                
                );
            db.SaveChanges();
        }

        private static void PopulateTiposTarefas(GestaoTarefasDbContext db)
        {
            if (db.TiposTarefas.Any()) return;

            db.TiposTarefas.AddRange(
                new TiposTarefas {TipoTarefa = "Comprar" },
                new TiposTarefas { TipoTarefa = "Transporte" },
                new TiposTarefas { TipoTarefa = "Manutenção" },
                new TiposTarefas { TipoTarefa = "Limpeza" },
                new TiposTarefas { TipoTarefa = "Outra" }
                );
            db.SaveChanges();
        }
    }
}
