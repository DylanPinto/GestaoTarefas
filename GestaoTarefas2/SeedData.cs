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
                new Departamento { Nome = "Secretaria" }
                );
            db.SaveChanges();
        }
    }
}
