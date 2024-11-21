using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface InterfaceContasEnergia
    {
        Task Adcionar(ContasEnergia Objeto);

        Task Atualizar(ContasEnergia Objeto);

        Task Excluir(ContasEnergia Objeto);

        Task<ContasEnergia> ObterPorId(int Id);

        Task<List<ContasEnergia>> Listar();
    }
}
