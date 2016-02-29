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
    public class produtoTipoMap : EntityTypeConfiguration<produtoTipo>
    {
        public produtoTipoMap()
        {
            this.ToTable("produtotipo");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.nome).HasColumnName("nome");
            this.Property(c => c.empresaID).HasColumnName("empresaID");
        }
    }
}
