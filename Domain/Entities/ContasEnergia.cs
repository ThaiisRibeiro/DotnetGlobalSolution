using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("DotnetGS_Contas_Energia")]
    public class ContasEnergia
    {
        [Key]
        // public int id { get; set; }
        public int id_conta_energia { get; set; }

        [ForeignKey("Usuario")]
        public int id_usuario { get; set; }
    



        [ForeignKey("PrecoEcologico")]
        public int id_preco_ecologico { get; set; }
     



        [Column("data")]
        [Display(Name = "Data: ")]
        //[Required(ErrorMessage = "Campo Data Obrigátorio", AllowEmptyStrings = false)]
        public DateTime Data { get; set; }


        [Column("quantidade_kwh")]
        [Display(Name = "Quantidade de KWH: ")]
        [Required(ErrorMessage = "Campo Quantidade de KWH Obrigátorio", AllowEmptyStrings = false)]
        public double Quantidadekwh { get; set; }



        [Column("valor_gasto_real")]
        [Display(Name = "Valor gasto em R$ : ")]
        [Required(ErrorMessage = "Campo Valor gasto em R$ Obrigátorio", AllowEmptyStrings = false)]
        public double Valorgastoreal { get; set; }


        [Display(Name = "valor_total_ecologico: ")]
       // [Required(ErrorMessage = "Campo Valor total ecologico Obrigátorio", AllowEmptyStrings = false)]
        public double Valortotalecologico { get; set; }

       
        [Display(Name = "valor_economizado: ")]
     //   [Required(ErrorMessage = "Campo Valor Economizado Obrigátorio", AllowEmptyStrings = false)]
        public double Valoreconomizado { get; set; }
    }
}
