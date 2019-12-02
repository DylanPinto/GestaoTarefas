using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class Departamentos
    {
        public int DepartamentosId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}
