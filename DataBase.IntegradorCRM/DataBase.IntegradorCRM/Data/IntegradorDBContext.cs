using DataBase.IntegradorCRM.Data.DataBase;
using DataBase.IntegradorCRM.Data.Map;
using Microsoft.EntityFrameworkCore;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data
{
    public class IntegradorDBContext : DbContext
    {
        private readonly string _connectionString;

        // Construtor que aceita DbContextOptions
        public IntegradorDBContext(DbContextOptions<IntegradorDBContext> options)
            : base(options)
        {
        }

        public IntegradorDBContext()
        {
            string teste = "";
            var conexao = new ConexaoDB(teste);
            _connectionString = conexao.Carregarbanco();
        }

        public DbSet<DadosAPIModels> DadosAPI_OmniService { get; set; }
        public DbSet<RelacaoOrdemServicoModels> Relacao_OS_OmniService { get; set; }
        public DbSet<RelacaoBoletoCRMModel> RelacaoBoleto_OmniService { get; set; }
        public DbSet<BoletoAcoesCRMModel> boletoAcoes_OmniService { get; set; }
        public DbSet<OSAcoesCRMModel> OSAcao_OmniService { get; set; }
        public DbSet<AcaoSituacao_OS_CRM> acaoSituacao_OS_OmniService { get; set; }
        public DbSet<AcaoSituacao_Boleto_CRM> acaoSituacao_Boleto_OmniService { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new RelacaoOSMap());
            modelBuilder.ApplyConfiguration(new DadosAPIMap());
            modelBuilder.ApplyConfiguration(new RelacaoBoletoCRMMap());
            modelBuilder.ApplyConfiguration(new BoletoAcaoCRM_Map());
            modelBuilder.ApplyConfiguration(new OSAcaoMap());
            modelBuilder.ApplyConfiguration(new acaoSituacao_OS_Map());
            modelBuilder.ApplyConfiguration(new acaoSituacao_Boleto_Map());

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
