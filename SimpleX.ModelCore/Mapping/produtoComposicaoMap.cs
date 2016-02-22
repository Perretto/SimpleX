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
    public class produtoComposicaoMap : EntityTypeConfiguration<produtoComposicao>
    {
        public produtoComposicaoMap()
        {
            this.ToTable("produtoComposicao");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.produtoOrigemID).HasColumnName("produtoOrigemID");
            this.Property(c => c.produtoDestinoID).HasColumnName("produtoDestinoID");
            this.Property(c => c.quantidade).HasColumnName("quantidade");
            this.Property(c => c.empresaID).HasColumnName("empresaID");
        }
    }
}
