using Aplication.Interface;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Aplication
{
    public class AppPrecoEcologico : InterfacePrecoEcologicoApp
    {
           InterfacePrecoEcologico _InterfacePrecoEcologico;

            public AppPrecoEcologico(InterfacePrecoEcologico InterfacePrecoEcologico)
            {
                _InterfacePrecoEcologico = InterfacePrecoEcologico;
            }

            public async Task Adcionar(PrecoEcologico Objeto)
            {
                await _InterfacePrecoEcologico.Adcionar(Objeto);
            }


            public async Task Atualizar(PrecoEcologico Objeto)
            {
                await _InterfacePrecoEcologico.Atualizar(Objeto);
            }

            public async Task Excluir(PrecoEcologico Objeto)
            {
                await _InterfacePrecoEcologico.Excluir(Objeto);
            }

            public async Task<PrecoEcologico> ObterPorId(int Id)
            {
                return await _InterfacePrecoEcologico.ObterPorId(Id);
            }
            public async Task<List<PrecoEcologico>> Listar()
            {
                return await _InterfacePrecoEcologico.Listar();
            }

        }
    }

