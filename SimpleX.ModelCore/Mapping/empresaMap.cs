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
    public class empresaMap : EntityTypeConfiguration<empresa>
    {
        public empresaMap()
        {
            this.ToTable("empresa");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.razaoSocial).HasColumnName("razaoSocial");
            this.Property(c => c.nomeFantasia).HasColumnName("nomeFantasia");
            this.Property(c => c.CNPJ).HasColumnName("CNPJ");
            this.Property(c => c.CPF).HasColumnName("CPF");
            this.Property(c => c.RG).HasColumnName("RG");
            this.Property(c => c.IE).HasColumnName("IE");
            this.Property(c => c.IM).HasColumnName("IM");
            this.Property(c => c.CNAEID).HasColumnName("CNAEID");
        }
    }
}
