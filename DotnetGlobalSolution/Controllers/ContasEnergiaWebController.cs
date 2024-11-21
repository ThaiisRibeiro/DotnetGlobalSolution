using Aplication.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



namespace GlobalSolutionDotnet.Controllers

{
   
    public class ContasEnergiaWebController : Controller
    {
        public static int UsuarioId_Global = 0;
        public static string UsuarioEstado_Global = "";
        public static string UsuarioNome_Global = "";
        public static double Valor1kwh_Global = 0;




        /* private readonly InterfaceContasEnergiaApp _InterfaceContasEnergiaApp;

         public ContasEnergiaWebController(InterfaceContasEnergiaApp InterfaceContasEnergiaApp)
         {
             _InterfaceContasEnergiaApp = InterfaceContasEnergiaApp;
         }



         private readonly InterfacePrecoEcologicoApp _InterfacePrecoEcologicoApp;

          public PrecoEcologicoWebController(InterfacePrecoEcologicoApp InterfacePrecoEcologicoApp)
          {
              _InterfacePrecoEcologicoApp = InterfacePrecoEcologicoApp;
          }
         */
        private readonly InterfaceContasEnergiaApp _InterfaceContasEnergiaApp;
        private readonly InterfacePrecoEcologicoApp _InterfacePrecoEcologicoApp;

        // Construtor que recebe ambas as interfaces
        public ContasEnergiaWebController(InterfaceContasEnergiaApp interfaceContasEnergiaApp, InterfacePrecoEcologicoApp interfacePrecoEcologicoApp)
        {
            _InterfaceContasEnergiaApp = interfaceContasEnergiaApp;
            _InterfacePrecoEcologicoApp = interfacePrecoEcologicoApp;
        }






        //Lista de carro para simular o banco de dados
        //  private static List<Paciente> _lista = new List<Paciente>();

        private static int _id = 0; //Controla o IDc 


        // GET: PacienteWebController
      //  public async Task<ActionResult> Index()
          public async Task<ActionResult> Index(int UsuarioId, string Estado, string Nome)
        {
           if (UsuarioId > 0)
            {
                UsuarioId_Global = UsuarioId;
                UsuarioEstado_Global = Estado;
                UsuarioNome_Global = Nome;
            }


            if (_InterfacePrecoEcologicoApp != null)
            {
                List<PrecoEcologico> precoEcologico = await _InterfacePrecoEcologicoApp.Listar();

                foreach (var listar in precoEcologico)
                {

                    if (listar.Estado == UsuarioEstado_Global)
                    {
                        Valor1kwh_Global = ((double)listar.Valor1kwh);
                    }

                }
                //contasenergia.Valortotalecologico = (double)(contasenergia.Quantidadekwh * valor1kw);

                // contasenergia.Valoreconomizado = contasenergia.Valorgastoreal - contasenergia.Valortotalecologico;
            }

            // return View(_InterfacePacienteApp);

            // Adicionando dados ao ViewBag
            ViewBag.NomeUsuario = UsuarioNome_Global;
            var ContasEnergia = await _InterfaceContasEnergiaApp.Listar();
            double valor1 = 0;
            double valor2 = 0;
            double valor3 = 0;
            double valor4 = 0;

            var contasenergiatela = new List<Domain.Entities.ContasEnergia>();

            foreach (var listar in ContasEnergia)
            {
                if (listar.id_usuario == UsuarioId_Global)
                {


                    valor1 = valor1 + listar.Valorgastoreal;
                    valor2 = valor2 + listar.Valortotalecologico;
                    valor3 = valor3 + listar.Valoreconomizado;
                    valor4 = valor4 + listar.Quantidadekwh;

                    contasenergiatela.Add(listar);

                }

            }
            ViewBag.ValorTotalPago = valor1;
            ViewBag.ValorTotalEconomico = valor2;
            ViewBag.ValorTotalDesconto = valor3;
            ViewBag.ValorKwh = valor4;

            // return View(await _InterfaceContasEnergiaApp.Listar());
            return View(contasenergiatela);

          }
 


        // GET: PacienteWebController/Create
        public async Task<ActionResult> Adcionar()
        {
        

            return View(new ContasEnergia());
        }

        // POST: PacienteWebController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Adcionar(ContasEnergia contasenergia)
        {

            contasenergia.id_usuario = UsuarioId_Global;

            contasenergia.id_preco_ecologico = 1;

            var datateste = contasenergia.Data;


            /*
                        double valor1kw = 1;



                        //Carrega a lista dos precos ecologicos
                            List <PrecoEcologico> precoEcologico = await _InterfacePrecoEcologicoApp.Listar();

                         foreach (var listar in precoEcologico)              
                         {
                          if (listar.Estado == UsuarioEstado_Global)
                             {
                                  valor1kw = ((double)listar.Valor1kwh);
                             }

                         }


                         contasenergia.Valortotalecologico = (double)(contasenergia.Quantidadekwh * valor1kw);

                         contasenergia.Valoreconomizado = contasenergia.Valorgastoreal - contasenergia.Valortotalecologico;
                     */
            contasenergia.Valortotalecologico = (double)(contasenergia.Quantidadekwh * Valor1kwh_Global);

            contasenergia.Valoreconomizado = contasenergia.Valorgastoreal - contasenergia.Valortotalecologico;


            //  contasenergia.Valortotalecologico = 100;

            //contasenergia.Valoreconomizado = 50;

            // if (ModelState.IsValid)
            // {
            //Setar o código do carro
            contasenergia.id_conta_energia = ++_id;
                //Adicionar o carro na lista
                await _InterfaceContasEnergiaApp.Adcionar(contasenergia);
                //Mandar uma mensagem de sucesso para a view
                TempData["msg"] = "Paciente cadastrado!";
                //Redireciona para o método Cadastrar
                return RedirectToAction("Index");
           // }
            return View(contasenergia);


        }


        // GET: PacienteWebController/Edit/5
        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Atualizar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var contasenergia = await _InterfaceContasEnergiaApp.ObterPorId((int)id);
            if (contasenergia == null)
            {
                return NotFound();
            }
            return View(contasenergia);

        }




        // POST: PacienteWebController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Atualizar(int id, ContasEnergia contasenergia)
        {
            if (id != contasenergia.id_conta_energia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*      double valor1kw = 1;


                          List<PrecoEcologico> precoEcologico = await _InterfacePrecoEcologicoApp.Listar();

                          foreach (var listar in precoEcologico)
                          {
                              if (listar.Estado == "Pará")
                              {
                                  valor1kw = ((double)listar.Valor1kwh);
                              }

                          }
                          contasenergia.Valortotalecologico = (double)(contasenergia.Quantidadekwh * valor1kw);

                          contasenergia.Valoreconomizado = contasenergia.Valorgastoreal - contasenergia.Valortotalecologico;
                                    */

                    contasenergia.Valortotalecologico = (double)(contasenergia.Quantidadekwh * Valor1kwh_Global);

                    contasenergia.Valoreconomizado = contasenergia.Valorgastoreal - contasenergia.Valortotalecologico;

                    await _InterfaceContasEnergiaApp.Atualizar(contasenergia);
                }
                catch (DbUpdateConcurrencyException)
                {

                    ModelState.AddModelError(string.Empty, "Erro de concorrência ao atualizar o paciente. Tente novamente.");
                    return View(contasenergia);
                }

                return RedirectToAction(nameof(Index));
            }

            //Mensagem de sucesso
            TempData["msg"] = "Paciente atualizado!";


            return View(contasenergia);
        }






        [HttpGet] //Abrir o formulário com os dados preenchidos
        public async Task<ActionResult> Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var contasenergia = await _InterfaceContasEnergiaApp.ObterPorId((int)id);
            if (contasenergia == null)
            {
                return NotFound();
            }

            return View(contasenergia);


        }


        // POST: PacienteWebController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Excluir(int id)
        {

            var contasenergia = await _InterfaceContasEnergiaApp.ObterPorId(id);
            await _InterfaceContasEnergiaApp.Excluir(contasenergia);

            return RedirectToAction(nameof(Index));

        }

    }
}
