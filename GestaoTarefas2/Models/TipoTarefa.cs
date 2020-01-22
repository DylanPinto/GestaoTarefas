using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class TipoTarefa
    {
        [Key]
        
        public int TipoId { get; set; }
        [Required]
        public string TipoNome { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
