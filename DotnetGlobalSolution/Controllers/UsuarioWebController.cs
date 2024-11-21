using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionDotnet.Controllers
{
    public class UsuarioWebController : Controller
    {
        private readonly InterfaceUsuarioApp _InterfaceUsuarioApp;

        public UsuarioWebController(InterfaceUsuarioApp InterfaceUsuarioApp)
        {
            _InterfaceUsuarioApp = InterfaceUsuarioApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: AgendamentoWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfaceUsuarioApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new Usuario());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                usuario.id_usuario = ++_id;
                //Adicionar o carro na lista
               await _InterfaceUsuarioApp.Adcionar(usuario);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Agendamento cadastrado!";
                //Redireciona para o método Cadastrar
            
                return RedirectToAction("Index", "Login");

            }
            return View(new Usuario());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _InterfaceUsuarioApp.ObterPorId((int)id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, Usuario usuario)
        {
            if (id != usuario.id_usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceUsuarioApp.Atualizar(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar o agendamento. Tente novamente.");
                    return View(usuario);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Agendamento atualizado!";


            return View(usuario);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _InterfaceUsuarioApp.ObterPorId((int)id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var usuario = await _InterfaceUsuarioApp.ObterPorId(id);
            await _InterfaceUsuarioApp.Excluir(usuario);

            return RedirectToAction(nameof(Index));

        }

    }
}
