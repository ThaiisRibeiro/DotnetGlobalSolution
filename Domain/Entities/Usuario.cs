using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("DotnetGS_Usuario")]
    public class Usuario
    {
        [Key]
        // public int id { get; set; }
        public int id_usuario { get; set; }


        [Column("nome")]
        [Display(Name = "Nome: ")]
        [Required(ErrorMessage = "Campo Nome Obrigátorio", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Column("login")]
        [Display(Name = "Login: ")]
       // [Required(ErrorMessage = "Campo Login Obrigátorio", AllowEmptyStrings = false)]
        public string Login { get; set; }


        [Column("senha")]
        [Display(Name = "Senha: ")]
       // [Required(ErrorMessage = "Campo Senha Obrigátorio", AllowEmptyStrings = false)]
        public string Senha { get; set; }



        [Column("estado")]
        [Display(Name = "Estado : ")]
        [Required(ErrorMessage = "Campo Estado Obrigátorio", AllowEmptyStrings = false)]
        public string Estado { get; set; }

        
        [Display(Name = "endereco: ")]
        [Required(ErrorMessage = "Campo Endereco Obrigátorio", AllowEmptyStrings = false)]
        public string Endereco { get; set; }

        [Display(Name = "email: ")]
        [Required(ErrorMessage = "Campo Email Obrigátorio", AllowEmptyStrings = false)]
        public string Email { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
