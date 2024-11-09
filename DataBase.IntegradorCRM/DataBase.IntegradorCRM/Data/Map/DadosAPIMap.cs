using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace Integrador_Com_CRM.Data.Map
{
    internal class DadosAPIMap : IEntityTypeConfiguration<DadosAPIModels>
    {
        public void Configure(EntityTypeBuilder<DadosAPIModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Token).HasMaxLength(500);
        }
    }
}
