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
            if (db.Departamentos.Any()) return;

            db.Departamentos.AddRange(
                new Departamentos { Nome = "Informática" },
                new Departamentos { Nome = "Contabilidade" },
                new Departamentos { Nome = "Civil" },
                new Departamentos { Nome = "Bar" },
                new Departamentos { Nome = "Cantina" },
                new Departamentos { Nome = "Secretaria" }
                );
            db.SaveChanges();
        }
    }
}
