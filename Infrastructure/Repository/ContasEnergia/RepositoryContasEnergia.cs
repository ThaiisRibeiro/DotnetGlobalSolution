using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;

namespace Infrastructure.Repository.ContasEnergiaRepository
{
    public class RepositoryContasEnergia : InterfaceContasEnergia, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryContasEnergia()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Domain.Entities.ContasEnergia Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            { 
                banco.Set<Domain.Entities.ContasEnergia>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }

  


        public async Task Atualizar(Domain.Entities.ContasEnergia Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.ContasEnergia>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Domain.Entities.ContasEnergia Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Domain.Entities.ContasEnergia>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Domain.Entities.ContasEnergia>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.ContasEnergia>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Domain.Entities.ContasEnergia> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Domain.Entities.ContasEnergia>().FindAsync(Id);
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }

}
