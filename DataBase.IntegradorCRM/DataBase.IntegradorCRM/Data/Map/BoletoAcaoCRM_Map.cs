using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class BoletoAcaoCRM_Map : IEntityTypeConfiguration<BoletoAcoesCRMModel>
    {
        public void Configure(EntityTypeBuilder<BoletoAcoesCRMModel> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.Dias_Cobrancas);
            bld.Property(x => x.Dias_Cobrancas).IsRequired().HasMaxLength(300);
            bld.Property(x => x.Mensagem_Atualizacao).IsRequired().HasMaxLength(300);
            bld.Property(x => x.Data_Criacao).IsRequired();

        }
    }
}
