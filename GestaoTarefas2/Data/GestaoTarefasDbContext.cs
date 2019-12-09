using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefas2.Models
{
    public class GestaoTarefasDbContext : DbContext
    {
        public GestaoTarefasDbContext (DbContextOptions<GestaoTarefasDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefas2.Models.Departamentos> Departamentos { get; set; }
    }
}
