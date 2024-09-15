

using Integrador_Com_CRM.Data.Map;
using Integrador_Com_CRM.DataBase;
using Integrador_Com_CRM.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Integrador_Com_CRM.Data
{
    internal class IntegradorDBContext : DbContext
    {
        private readonly string _connectionString;

        public IntegradorDBContext()
        {
            string teste = "";
            var conexao = new ConexaoDB(teste);
            _connectionString = conexao.Carregarbanco();
        }

        public DbSet<DadosAPIModels> DadosAPI_CRM { get; set; }
        public DbSet<RelacaoOrdemServicoModels> Relacao_OS_Com_CRM { get; set; }
        public DbSet<RelacaoBoletoCRMModel> RelacaoBoletoCRM { get; set; }
        public DbSet<CobrancasNaSegundaModel> Cobrancas_Na_Segunda_CRM { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new RelacaoOSMap());
            modelBuilder.ApplyConfiguration(new DadosAPIMap());
            modelBuilder.ApplyConfiguration(new RelacaoBoletoCRMMap());
            modelBuilder.ApplyConfiguration(new CobrancasSegundaMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aqui é usado a string de conexão carregada da classe ConexaoDB
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
