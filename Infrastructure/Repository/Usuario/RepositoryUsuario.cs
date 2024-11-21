using Domain.Entities;
using Domain.Interface;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repository.UsuarioRepository
{
    public class RepositoryUsuario : InterfaceUsuario, IDisposable
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryUsuario()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }

        public async Task<Domain.Entities.Usuario> BuscarPorLogin(string login)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
            
                return await banco.Set<Domain.Entities.Usuario>().FirstOrDefaultAsync(x => x.Login == login);
            }
        }


        public async Task Adcionar(Domain.Entities.Usuario Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Usuario>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Domain.Entities.Usuario Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Usuario>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Domain.Entities.Usuario Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.Usuario>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Domain.Entities.Usuario>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.Usuario>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Domain.Entities.Usuario> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.Usuario>().FindAsync(Id);
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
