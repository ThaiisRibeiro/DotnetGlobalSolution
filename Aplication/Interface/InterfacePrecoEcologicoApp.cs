using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface InterfacePrecoEcologicoApp
    {
        Task Adcionar(PrecoEcologico Objeto);

        Task Atualizar(PrecoEcologico Objeto);

        Task Excluir(PrecoEcologico Objeto);

        Task<PrecoEcologico> ObterPorId(int Id);

        Task<List<PrecoEcologico>> Listar();
    }
}
