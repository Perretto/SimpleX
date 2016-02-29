using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SimpleX.Model;

namespace SimpleX.ModelCore.Mapping
{
    public class fornecedorEnderecoMap : EntityTypeConfiguration<fornecedorEndereco>
    {
        public fornecedorEnderecoMap()
        {
            this.ToTable("fornecedorendereco");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.logradouro).HasColumnName("logradouro");
            this.Property(c => c.numero).HasColumnName("numero");
            this.Property(c => c.complemento).HasColumnName("complemento");
            this.Property(c => c.bairro).HasColumnName("bairro");
            this.Property(c => c.CEP).HasColumnName("CEP");
            this.Property(c => c.cidadeID).HasColumnName("cidadeID");
            this.Property(c => c.estadoID).HasColumnName("estadoID");
            this.Property(c => c.paisID).HasColumnName("paisID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");
            this.Property(c => c.fornecedorID).HasColumnName("fornecedorID");
        }
    }
}
