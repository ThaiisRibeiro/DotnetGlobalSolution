using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface InterfaceUsuario
    {
        Task <Usuario> BuscarPorLogin(string login);
        Task Adcionar(Usuario Objeto);

        Task Atualizar(Usuario Objeto);

        Task Excluir(Usuario Objeto);

        Task<Usuario> ObterPorId(int Id);

        Task<List<Usuario>> Listar();
    }
}
