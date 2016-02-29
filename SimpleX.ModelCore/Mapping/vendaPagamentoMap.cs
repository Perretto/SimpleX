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
    public class vendaPagamentoMap : EntityTypeConfiguration<vendaPagamento>
    {
        public vendaPagamentoMap()
        {
            this.ToTable("vendaPagamento");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.vendaID).HasColumnName("vendaID");
            this.Property(c => c.formaPagamentoID).HasColumnName("formaPagamentoID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");

        }
    }
}
