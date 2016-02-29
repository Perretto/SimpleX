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
    public class compraProdutoMap : EntityTypeConfiguration<compraProduto>
    {
        public compraProdutoMap()
        {
            this.ToTable("compraproduto");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.valorTotal).HasColumnName("valorTotal");
            this.Property(c => c.compraID).HasColumnName("compraID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");
            this.Property(c => c.produtoID).HasColumnName("produtoID");
            this.Property(c => c.quantidade).HasColumnName("quantidade");
            this.Property(c => c.valorUnitario).HasColumnName("valorUnitario");

        }
    }
}
