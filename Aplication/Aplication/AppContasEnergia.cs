using Aplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Entities;


namespace Aplication.Aplication
{
    public class AppContasEnergia : InterfaceContasEnergiaApp
    {
        InterfaceContasEnergia _InterfaceContasEnergia;

        public AppContasEnergia(InterfaceContasEnergia InterfaceContasEnergia)
        {
            _InterfaceContasEnergia = InterfaceContasEnergia;
        }

        public async Task Adcionar(ContasEnergia Objeto)
        {
            await _InterfaceContasEnergia.Adcionar(Objeto);
        }


        public async Task Atualizar(ContasEnergia Objeto)
        {
            await _InterfaceContasEnergia.Atualizar(Objeto);
        }

        public async Task Excluir(ContasEnergia Objeto)
        {
            await _InterfaceContasEnergia.Excluir(Objeto);
        }

        public async Task<ContasEnergia> ObterPorId(int Id)
        {
            return await _InterfaceContasEnergia.ObterPorId(Id);
        }
        public async Task<List<ContasEnergia>> Listar()
        {
            return await _InterfaceContasEnergia.Listar();
        }

    }
}
