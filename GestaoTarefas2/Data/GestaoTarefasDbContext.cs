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

        public DbSet<GestaoTarefas2.Models.Departamento> Departamento { get; set; }

        public DbSet<GestaoTarefas2.Models.Tarefa> Tarefa { get; set; }

        public DbSet<GestaoTarefas2.Models.Funcionario> Funcionario { get; set; }

        public DbSet<GestaoTarefas2.Models.Cargo> Cargo { get; set; }

        public DbSet<GestaoTarefas2.Models.TiposTarefas> TiposTarefas { get; set; }

    }
}
