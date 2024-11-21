using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)


        {
            //          Database.EnsureCreated();
        }
        public DbSet<Usuario> DotnetGS_Usuario { set; get; }
        public DbSet<PrecoEcologico> DotnetGS_Preco_Ecologico { set; get; }
        public DbSet<ContasEnergia> DotnetGS_Contas_Energia{ set; get; }
      



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
            if (!optionsBuilder.IsConfigured)
                //optionsBuilder.UseSqlServer(GetStringConectionConfig());
                optionsBuilder.UseOracle(GetStringConectionConfig());

            base.OnConfiguring(optionsBuilder);
        }


        private string GetStringConectionConfig()
        {
            //string strCon = "Data Source=ORACLE.FIAP.COM.BR:1521/ORCL;Initial Catalog=fiap;Integrated Security=False;User ID=;Password=;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            string strCon = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=;Password=;";
            return strCon;
        }



    }
}

