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
    public class URAMap : EntityTypeConfiguration<URA>
    {
        public URAMap()
        {
            this.ToTable("ura");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.texto).HasColumnName("texto");
            this.Property(c => c.nivel).HasColumnName("nivel");
            this.Property(c => c.statusURAID).HasColumnName("statusURAID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");
        }
    }
}
