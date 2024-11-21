using Domain.Interface;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.PrecoEcologicoRepository
{
    public class RepositoryPrecoEcologico : InterfacePrecoEcologico, IDisposable
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryPrecoEcologico()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Domain.Entities.PrecoEcologico Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.PrecoEcologico>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Domain.Entities.PrecoEcologico Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.PrecoEcologico>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Domain.Entities.PrecoEcologico Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.PrecoEcologico>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Domain.Entities.PrecoEcologico>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.PrecoEcologico>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Domain.Entities.PrecoEcologico> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.PrecoEcologico>().FindAsync(Id);
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
