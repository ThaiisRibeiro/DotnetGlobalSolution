using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface InterfaceUsuarioApp
    {
        Task Adcionar(Usuario Objeto);

        Task Atualizar(Usuario Objeto);

        Task Excluir(Usuario Objeto);

        Task<Usuario> ObterPorId(int Id);

        Task<List<Usuario>> Listar();
    }
}
