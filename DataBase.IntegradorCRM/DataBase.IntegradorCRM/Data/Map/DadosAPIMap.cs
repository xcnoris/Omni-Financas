using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class DadosAPIMap : IEntityTypeConfiguration<DadosAPIModels>
    {
        public void Configure(EntityTypeBuilder<DadosAPIModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Token).HasMaxLength(500);
            builder.Property(x => x.Cod_API_Boleto).HasMaxLength(100);
            builder.Property(x => x.Cod_Jornada_Boleto).HasMaxLength(100);
            builder.Property(x => x.Cod_API_OrdemServico).HasMaxLength(100);
            builder.Property(x => x.Cod_Jornada_OrdemServico).HasMaxLength(51000);


        }
    }
}
