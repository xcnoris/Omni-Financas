using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class CobrancasSegundaMap : IEntityTypeConfiguration<CobrancasNaSegundaModel>
    {
        public void Configure(EntityTypeBuilder<CobrancasNaSegundaModel> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.BoletoId).IsRequired();
            bld.HasOne(x => x.Boleto);
            bld.Property(x => x.NovoAtrasoBoleto).IsRequired();
        }
    }
}
