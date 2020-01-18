using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class Departamento
    {
            [Key]
            public int DepartamentoId { get; set; }
            [Required]
            [StringLength(30, MinimumLength = 3)]
            public string Nome { get; set; }

            public ICollection<Funcionario> Funcionarios { get; set; }
        

    }

}

