using Integrador_Com_CRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Data.Map
{
    internal class RelacaoOSMap : IEntityTypeConfiguration<RelacaoOrdemServicoModels>
    {
        public void Configure(EntityTypeBuilder<RelacaoOrdemServicoModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id_OrdemServico).IsRequired();
            builder.Property(x => x.Cod_Oportunidade).IsRequired();
            builder.Property(x => x.Id_CategoriaOS).IsRequired();
            builder.Property(x => x.Data_Criacao).IsRequired();
            builder.Property(x => x.Data_Alteracao);

        }
    }
}
