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
    public class vendaProdutoMap : EntityTypeConfiguration<vendaProduto>
    {
        public vendaProdutoMap()
        {
            this.ToTable("vendaProduto");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.valorTotal).HasColumnName("valorTotal");
            this.Property(c => c.vendaID).HasColumnName("vendaID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");
            this.Property(c => c.produtoID).HasColumnName("produtoID");
            this.Property(c => c.quantidade).HasColumnName("quantidade");
            this.Property(c => c.valorUnitario).HasColumnName("valorUnitario");
        }
    }
}
