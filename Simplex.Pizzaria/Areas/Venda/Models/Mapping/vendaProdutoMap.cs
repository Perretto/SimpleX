using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleX.ModelCore.Mapping;
using Simplex.Pizzaria.Models;
using System.Data.Entity.ModelConfiguration;

namespace Simplex.Pizzaria.Models.Mapping 
{
    public class vendaProdutoMap : EntityTypeConfiguration<vendaProduto>
    {
        public vendaProdutoMap()
        {
            this.ToTable("vendaproduto");
            this.Property(c => c.ID).HasColumnName("ID");
            this.Property(c => c.valorTotal).HasColumnName("valorTotal");
            this.Property(c => c.vendaID).HasColumnName("vendaID");
            this.Property(c => c.empresaID).HasColumnName("empresaID");
            this.Property(c => c.produtoID).HasColumnName("produtoID");
            this.Property(c => c.quantidade).HasColumnName("quantidade");
            this.Property(c => c.valorUnitario).HasColumnName("valorUnitario");
            this.Property(c => c.subProdutoID).HasColumnName("subProdutoID");
        }
    }
}