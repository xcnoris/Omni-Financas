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
            builder.Property(x => x.CodAPI_EnvioPDF).HasMaxLength(100);
        }
    }
}
