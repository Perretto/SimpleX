using SimpleX.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.ModelCore.Mapping
{
    public class messageMap : EntityTypeConfiguration<systemMessage>
    {
        public messageMap()
        {
            ToTable("systemmessage");

            this.Property(m => m.ID).HasColumnName("id");
            this.Property(m => m.type).HasColumnName("type");
            this.Property(m => m.internalNumber).HasColumnName("internalNumber");
            this.Property(m => m.externalNumber).HasColumnName("externalNumber");
            this.Property(m => m.description).HasColumnName("description");

        }

    }
}
