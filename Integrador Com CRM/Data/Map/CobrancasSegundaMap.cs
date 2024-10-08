using Integrador_Com_CRM.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrador_Com_CRM.Data.Map
{
    internal class CobrancasSegundaMap : IEntityTypeConfiguration<CobrancasNaSegundaModel>
    {
        public void Configure(EntityTypeBuilder<CobrancasNaSegundaModel> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.CodigoJornada).IsRequired();
            bld.Property(x => x.BoletoId).IsRequired();
            bld.HasOne(x => x.Boleto);
            bld.Property(x => x.NovoAtrasoBoleto).IsRequired();
            bld.Property(x => x.Cod_Oportunidade).IsRequired();
        }
    }
}
