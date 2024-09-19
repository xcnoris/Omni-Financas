using Integrador_Com_CRM.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Data.Map
{
    internal class BoletoAcaoCRM_Map : IEntityTypeConfiguration<BoletoAcoesCRMModel>
    {
        public void Configure(EntityTypeBuilder<BoletoAcoesCRMModel> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.Dias_Cobrancas).IsRequired().HasMaxLength(300);
            bld.Property(x => x.Dias_Cobrancas).IsRequired().HasMaxLength(300);
            bld.Property(x => x.Mensagem_Atualizacao).IsRequired().HasMaxLength(300);

        }
    }
}
