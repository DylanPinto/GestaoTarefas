using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class Tarefa
    {
        [Key]
        public int TarefaId { get; set; }
        [StringLength(60)]
        public string NomeTarefa { get; set; }
        [StringLength(60)]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }
        
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
       
        public int TipoId { get; set; }
        public TipoTarefa TipoTarefa { get; set; }

        [StringLength(250)]
        public string Descricao { get; set; }
        [Required]
        public string estadoTarefa { get; set; }
    }
}
