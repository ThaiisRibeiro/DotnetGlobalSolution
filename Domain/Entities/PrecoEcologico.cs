using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("DotnetGS_Preco_Ecologico")]
    public class PrecoEcologico
    {
        [Key]
        // public int id { get; set; }
        public int id_preco_ecologico { get; set; }


        [Column("estado")]
        [Display(Name = "Estado: ")]
        [Required(ErrorMessage = "Campo Estado Obrigátorio", AllowEmptyStrings = false)]
        public string Estado { get; set; }


        [Column("valor_1kwh")]
        [Display(Name = "Valor 1 kwh: ")]
        [Required(ErrorMessage = "Campo Valor 1 kwh Obrigátorio", AllowEmptyStrings = false)]
        public double Valor1kwh { get; set; }



        [Column("data")]
        [Display(Name = "Data : ")]
        [Required(ErrorMessage = "Campo Data Obrigátorio", AllowEmptyStrings = false)]
        public DateTime Data { get; set; }


    }
}
