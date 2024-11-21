using System.ComponentModel.DataAnnotations;

namespace DotnetGlobalSolution.Models
{
    public class LoginModel
    {
       // [Required(ErrorMessage = "Campo Login Obrigátorio", AllowEmptyStrings = false)]
        public string Login { get; set; }

       // [Required(ErrorMessage = "Campo Senha Obrigátorio", AllowEmptyStrings = false)]
        public string Senha { get; set; }
    }
}
