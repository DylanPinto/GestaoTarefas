﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }

        public string NomeCargo { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }

    }
}
