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
    public class AppUsuario : InterfaceUsuarioApp
    {
        InterfaceUsuario _InterfaceUsuario;

        public AppUsuario(InterfaceUsuario InterfaceUsuario)
        {
            _InterfaceUsuario = InterfaceUsuario;
        }

        public async Task Adcionar(Usuario Objeto)
        {
            await _InterfaceUsuario.Adcionar(Objeto);
        }


        public async Task Atualizar(Usuario Objeto)
        {
            await _InterfaceUsuario.Atualizar(Objeto);
        }

        public async Task Excluir(Usuario Objeto)
        {
            await _InterfaceUsuario.Excluir(Objeto);
        }

        public async Task<Usuario> ObterPorId(int Id)
        {
            return await _InterfaceUsuario.ObterPorId(Id);
        }
        public async Task<List<Usuario>> Listar()
        {
            return await _InterfaceUsuario.Listar();
        }
    }
}
