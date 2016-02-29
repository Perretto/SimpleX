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
    public class compraPagamentoMap : EntityTypeConfiguration<compraPagamento>
    {
        public compraPagamentoMap()
        {
            this.ToTable("compraPagamento");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.compraID).HasColumnName("compraID");
            this.Property(c => c.formaPagamentoID).HasColumnName("formaPagamentoID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");

        }
    }
}
