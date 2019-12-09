using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefas2.Models
{
    public class TarefasContext : DbContext
    {
        public TarefasContext (DbContextOptions<TarefasContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefas2.Models.Tarefas> Tarefas { get; set; }
    }
}
