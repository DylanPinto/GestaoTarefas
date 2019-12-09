using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas2.Models
{
    public class Tarefas
    {
        [Key]
        public int TarefaId { get; set; }
        [StringLength(60)]
        public string NomeTarefa { get; set; }
        [StringLength(60)]
      
        public string NomeOrdena { get; set; }
        [StringLength(60)]
        public string NomeExecuta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime DataInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }
        
        public ICollection<TiposTarefas> Tipo { get; set; }

        [StringLength(250)]
        public string Descricao { get; set; }
    }
}
