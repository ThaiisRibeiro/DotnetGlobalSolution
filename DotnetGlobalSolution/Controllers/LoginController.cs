using Domain.Entities;
using Domain.Interface;
using DotnetGlobalSolution.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotnetGlobalSolution.Controllers
{
    public class LoginController : Controller
    {
        private readonly InterfaceUsuario _InterfaceUsuario;

        public LoginController(InterfaceUsuario interfaceUsuario)
        {
            _InterfaceUsuario = interfaceUsuario;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid || !ModelState.IsValid)
                {
                    Usuario usuario = await _InterfaceUsuario.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "ContasEnergiaWeb", new { usuarioId = usuario.id_usuario, estado = usuario.Estado, nome = usuario.Nome});

                           // return RedirectToAction("Index", "ContasEnergiaWeb");


                        }
                        TempData["MensagemErro"] = $"Senha do usuário é inválida. Por favor, tente novamente.";



                    }

                    TempData["MensagemErro"] = $"Usuario e/ou senha inválido(s). Por favor, tente novamente.";

                }
                return View("Index");

            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, nao conseguimos realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
        [HttpPost]

        public async Task<ActionResult> Cadastrar(Usuario usuario)

       // public IActionResult Cadastrar(LoginModel loginModel)
        {
            /* try
             {
                 if (ModelState.IsValid)
                 {
                     // Redireciona para a ação "Adicionar" no controlador "UsuarioWebController"
                     return RedirectToAction("Adcionar", "UsuarioWebController");
                 }

                 // Retorna para a página atual com uma mensagem de erro, caso o modelo seja inválido
                 TempData["MensagemErro"] = "Dados inválidos. Por favor, revise os campos preenchidos.";
                 return View(usuario);
             }
             catch (Exception erro)
             {
                 TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu cadastro. Tente novamente. Detalhe do erro: {erro.Message}";
                 return RedirectToAction("Index");
             }
            */
            return RedirectToAction("Adcionar", "UsuarioWeb");

        }

    }
}
