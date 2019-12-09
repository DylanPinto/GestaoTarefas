using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoTarefas2.Models;

namespace GestaoTarefas2.Models
{
    public class GestaoTarefasDbContext : DbContext
    {
        public GestaoTarefasDbContext (DbContextOptions<GestaoTarefasDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefas2.Models.Departamentos> Departamentos { get; set; }

        public DbSet<GestaoTarefas2.Models.Tarefas> Tarefas { get; set; }

        public DbSet<GestaoTarefas2.Models.Funcionarios> Funcionarios { get; set; }
    }
}
