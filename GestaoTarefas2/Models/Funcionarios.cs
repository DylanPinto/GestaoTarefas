using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class Funcionarios
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Required(ErrorMessage ="Por favor insira o seu nome!")]
        [StringLength (60, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor insira o seu sobrenome!")]
        [StringLength(60, MinimumLength = 3)]
        public string SobreNome { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        [Phone]
        public string NTelemovel { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int DepartamentoId { get; set; }
        public Departamentos Departamentos { get; set; }

        public int CargoId { get; set; }
        public Cargos Cargos { get; set; }

        public ICollection<Tarefas> Tarefas { get; set; }
    }
}
