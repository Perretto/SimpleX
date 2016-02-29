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
    public class produtoMap : EntityTypeConfiguration<produto>
    {
        public produtoMap()
        {
            this.ToTable("produto");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.codigo).HasColumnName("codigo");            
            this.Property(c => c.nome).HasColumnName("nome");
            this.Property(c => c.produtoCategoriaID).HasColumnName("produtoCategoriaID");
            this.Property(c => c.valorProduto).HasColumnName("valorProduto");
            this.Property(c => c.produtoTipoID).HasColumnName("produtoTipoID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");

        }
    }
}
