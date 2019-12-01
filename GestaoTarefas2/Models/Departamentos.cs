using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class Departamentos
    {
        [Key]
        public int DepartamentoId { get; set; }
        [Required]
        public string Nome { get; set; }

    }
  
}
