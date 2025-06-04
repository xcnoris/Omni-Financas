using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class BoletoAcaoCRM_Map : IEntityTypeConfiguration<BoletoAcoesModel>
    {
        public void Configure(EntityTypeBuilder<BoletoAcoesModel> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.Dias_Cobrancas);
            bld.Property(x => x.Dias_Cobrancas).IsRequired().HasMaxLength(300);
            bld.Property(x => x.MensagemAtualizacaoWhats).IsRequired().HasMaxLength(1000);
            bld.Property(x => x.EnviarPDFPorWhats);
            bld.Property(x => x.Data_Criacao).IsRequired();
            bld.Property(x => x.EnviarPDFPorEmail).IsRequired();
        }
    }
}