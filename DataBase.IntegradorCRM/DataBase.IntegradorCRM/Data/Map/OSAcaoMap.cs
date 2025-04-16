using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class OSAcaoMap : IEntityTypeConfiguration<OSAcoesCRMModel>
    {
        public void Configure(EntityTypeBuilder<OSAcoesCRMModel> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.IdCategoria);
            bld.Property(x => x.Mensagem_Atualizacao).IsRequired().HasMaxLength(1000);
            bld.Property(x => x.Data_Criacao).IsRequired();

        }
    }
}
