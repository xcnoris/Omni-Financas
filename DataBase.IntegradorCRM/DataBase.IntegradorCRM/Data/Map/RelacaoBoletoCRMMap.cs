
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.IntegradorCRM.Models.EF;

namespace DataBase.IntegradorCRM.Data.Map
{
    internal class RelacaoBoletoCRMMap : IEntityTypeConfiguration<RelacaoBoletoCRMModel>
    {
        public void Configure(EntityTypeBuilder<RelacaoBoletoCRMModel> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id_DocumentoReceber).IsRequired();
            builder.Property(x => x.Numero_Documento).IsRequired();
            builder.Property(x => x.Id_Entidade).IsRequired();
            builder.Property(x => x.Nome_Entidade).IsRequired();
            builder.Property(x => x.Celular_Entidade).IsRequired();
            builder.Property(x => x.Email_Entidade).IsRequired();
            builder.Property(x => x.CNPJ_CPF).IsRequired();
            builder.Property(x => x.Situacao).IsRequired();
            builder.Property(x => x.Data_Vencimento).IsRequired();
            builder.Property(x => x.Cod_Oportunidade).IsRequired();
            builder.Property(x => x.Quitado).IsRequired();
            builder.Property(x => x.DiasEmAtraso).IsRequired();
            builder.Property(x => x.Data_Criacao).IsRequired();
            builder.Property(x => x.Data_Atualizacao);

        }
    }
}
