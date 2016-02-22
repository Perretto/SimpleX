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
    public class fornecedorContatoMap : EntityTypeConfiguration<fornecedorContato>
    {
        public fornecedorContatoMap()
        {
            this.ToTable("fornecedorContato");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.nomeContato).HasColumnName("nomeContato");
            this.Property(c => c.telefoneContato).HasColumnName("telefoneContato");
            this.Property(c => c.emailContato).HasColumnName("emailContato");
            this.Property(c => c.fornecedorID).HasColumnName("fornecedorID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");

        }
    }
}
