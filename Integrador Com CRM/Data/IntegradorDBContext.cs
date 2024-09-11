

using Integrador_Com_CRM.Data.Map;
using Integrador_Com_CRM.DataBase;
using Integrador_Com_CRM.Models;
using Microsoft.EntityFrameworkCore;

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

        //// Construtor que aceita a string de conexão
        //public IntegradorDBContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public DbSet<RelacaoOrdemServicoModels> Relacao_OS_Com_CRM { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new RelacaoOSMap());
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
