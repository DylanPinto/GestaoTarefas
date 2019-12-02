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
        public int TipoTarefaID { get; set; }
        [Required]
        public string Tipotarefa { get; set; }

        
        
    }
}
