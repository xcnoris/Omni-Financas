using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class acaoSituacao_OS_Map : IEntityTypeConfiguration<AcaoSituacao_OS_CRM>
    {
        public void Configure(EntityTypeBuilder<AcaoSituacao_OS_CRM> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.Situacao).IsRequired();
            bld.Property(x => x.Mensagem).IsRequired();
            bld.Property(x => x.Data_Cricao).IsRequired();
            bld.Property(x => x.Data_Atualizacao);
        }
    }
}
