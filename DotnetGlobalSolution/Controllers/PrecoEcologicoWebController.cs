using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionDotnet.Controllers
{
    public class PrecoEcologicoWebController : Controller
    {
        private readonly InterfacePrecoEcologicoApp _InterfacePrecoEcologicoApp;

        public PrecoEcologicoWebController(InterfacePrecoEcologicoApp InterfacePrecoEcologicoApp)
        {
            _InterfacePrecoEcologicoApp = InterfacePrecoEcologicoApp;
        }


        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: AgendamentoWebController
        public async Task<ActionResult> Index()
        {

            // return View(_InterfacePacienteApp);
            return View(await _InterfacePrecoEcologicoApp.Listar());
        }



        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
            return View(new PrecoEcologico());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(PrecoEcologico precoecologico)
        {
            if (ModelState.IsValid)
            {
                //Setar o código do carro
                precoecologico.id_preco_ecologico = ++_id;
                //Adicionar o carro na lista
                await _InterfacePrecoEcologicoApp.Adcionar(precoecologico);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Agendamento cadastrado!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
            }
            return View(new PrecoEcologico());

        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var precoecologico = await _InterfacePrecoEcologicoApp.ObterPorId((int)id);
            if (precoecologico == null)
            {
                return NotFound();
            }
            return View(precoecologico);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, PrecoEcologico precoecologico)
        {
            if (id != precoecologico.id_preco_ecologico)
            {
                return NotFound();
            }
            
            precoecologico.Data = DateTime.Now;


           // if (ModelState.IsValid)
           // {
                try
                {
                    await _InterfacePrecoEcologicoApp.Atualizar(precoecologico);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar o agendamento. Tente novamente.");
                    return View(precoecologico);
                }

                return RedirectToAction(nameof(Index));
           // }

            //Mensagem de sucesso
            TempData["msg"] = "Agendamento atualizado!";


            return View(precoecologico);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var precoecologico = await _InterfacePrecoEcologicoApp.ObterPorId((int)id);
            if (precoecologico == null)
            {
                return NotFound();
            }

            return View(precoecologico);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var precoecologico = await _InterfacePrecoEcologicoApp.ObterPorId(id);
            await _InterfacePrecoEcologicoApp.Excluir(precoecologico);

            return RedirectToAction(nameof(Index));

        }

    }
}
