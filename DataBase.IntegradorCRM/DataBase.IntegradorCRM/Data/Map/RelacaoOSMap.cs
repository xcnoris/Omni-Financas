
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class RelacaoOSMap : IEntityTypeConfiguration<RelacaoOrdemServicoModels>
    {
        public void Configure(EntityTypeBuilder<RelacaoOrdemServicoModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id_OrdemServico).IsRequired();
            builder.Property(x => x.Id_CategoriaOS).IsRequired();
            builder.Property(x => x.Data_Criacao).IsRequired();
            builder.Property(x => x.Data_Alteracao);

        }
    }
}
