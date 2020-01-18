using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class TiposTarefas
    {
        [Key]
        public int TipoId { get; set; }
        [Required]
        public string TipoTarefa { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
