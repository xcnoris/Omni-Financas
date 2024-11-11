using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class acaoSituacao_Boleto_Map : IEntityTypeConfiguration<AcaoSituacao_Boleto_CRM>
    {
        public void Configure(EntityTypeBuilder<AcaoSituacao_Boleto_CRM> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.Situacao).IsRequired();
            bld.Property(x => x.CodAcaoCRM).IsRequired();
            bld.Property(x => x.Mensagem_Acao).IsRequired();
            bld.Property(x => x.Data_Cricao).IsRequired();
            bld.Property(x => x.Data_Atualizacao);
        }
    }
}
