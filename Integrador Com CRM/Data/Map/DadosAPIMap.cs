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
    internal class DadosAPIMap : IEntityTypeConfiguration<DadosAPIModels>
    {
        public void Configure(EntityTypeBuilder<DadosAPIModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Token).HasMaxLength(500);
        }
    }
}
