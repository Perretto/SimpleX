using SimpleX.Model;
using SimpleX.ModelCore.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.ModelCore.Contexts
{
    public class Context : DbContext
    {

        public Context()
            : base("conexao")
        {
            
        }

        ////Administrador=============================
        //public DbSet<empresa> empresa { get; set; }
        //public DbSet<empresaEndereco> empresaEndereco { get; set; }
        //public DbSet<usuario> usuario { get; set; }
        //public DbSet<URA> URA { get; set; }
        //public DbSet<statusURA> statusURA { get; set; }

        ////==========================================

        ////Cadastro==================================
        //public DbSet<cliente> cliente { get; set; }
        //public DbSet<clienteContato> clienteContato { get; set; }
        //public DbSet<clienteEndereco> clienteEndereco { get; set; }

        //public DbSet<fornecedor> fornecedor { get; set; }
        //public DbSet<fornecedorContato> fornecedorContato { get; set; }
        //public DbSet<fornecedorEndereco> fornecedorEndereco { get; set; }

        //public DbSet<produto> produto { get; set; }
        //public DbSet<produtoCategoria> produtoCategoria { get; set; }
        //public DbSet<produtoComposicao> produtoComposicao { get; set; }
        //public DbSet<produtoTipo> produtoTipo { get; set; }

        ////==========================================

        ////Movimentação==============================
        //public DbSet<formaPagamento> formaPagamento { get; set; }
        //public DbSet<compra> compra { get; set; }
        //public DbSet<compraPagamento> compraPagamento { get; set; }
        //public DbSet<compraProduto> compraProduto { get; set; }
        //public DbSet<compraStatus> compraStatus { get; set; }

        //public DbSet<venda> venda { get; set; }
        //public DbSet<vendaPagamento> vendaPagamento { get; set; }
        //public DbSet<vendaProduto> vendaProduto { get; set; }
        //public DbSet<vendaStatus> vendaStatus { get; set; }
        ////==========================================

        ////Cadastro Geral ===========================
        //public DbSet<CNAE> CNAE { get; set; }
        //public DbSet<cidade> cidade { get; set; }
        //public DbSet<estado> estado { get; set; }
        //public DbSet<pais> pais { get; set; }
        //public DbSet<CFOPCore> CFOP { get; set; }

        //==========================================

        public DbSet<systemMessageCore> message { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //this.Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer<Context>(null);
            
            //Database.SetInitializer(new CreateOrMigrateDatabaseInitializer<Context, Configuration>());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());

            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());

            //var configuration = new GalleryDbMigrationConfiguration();
            //var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);
            //if (migrator.GetPendingMigrations().Any())
            //{
            //    migrator.Update();
            //}

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<empresa>().Ignore(o => o.empresaID);

            //Administrador=============================    
            //modelBuilder.Configurations.Add(new empresaMap());
            //modelBuilder.Configurations.Add(new empresaEnderecoMap());
            //modelBuilder.Entity<empresaEndereco>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new usuarioMap());
            //modelBuilder.Entity<usuario>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new URAMap());
            ////==========================================

            ////Cadastro==================================
            //modelBuilder.Configurations.Add(new clienteMap());
            //modelBuilder.Entity<cliente>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new clienteContatoMap());
            //modelBuilder.Entity<clienteContato>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new clienteEnderecoMap());
            //modelBuilder.Entity<clienteEndereco>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);

            //modelBuilder.Configurations.Add(new fornecedorMap());
            //modelBuilder.Entity<fornecedor>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new fornecedorContatoMap());
            //modelBuilder.Entity<fornecedorContato>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new fornecedorEnderecoMap());
            //modelBuilder.Entity<fornecedorEndereco>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);

            //modelBuilder.Configurations.Add(new produtoMap());
            //modelBuilder.Entity<produto>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new produtoCategoriaMap());
            //modelBuilder.Entity<produtoCategoria>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new produtoComposicaoMap());
            //modelBuilder.Entity<produtoComposicao>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Entity<produtoComposicao>().HasOptional(a => a.produtoOrigem).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Entity<produtoComposicao>().HasOptional(a => a.produtoDestino).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new produtoTipoMap());
            //modelBuilder.Entity<produtoTipo>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            ////==========================================

            ////Movimentação==============================
            //modelBuilder.Configurations.Add(new formaPagamentoMap());
            //modelBuilder.Entity<formaPagamento>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new compraMap());
            //modelBuilder.Entity<compra>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new compraPagamentoMap());
            //modelBuilder.Entity<compraPagamento>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new compraProdutoMap());
            //modelBuilder.Entity<compraProduto>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new compraStatusMap());
            //modelBuilder.Entity<compraStatus>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);

            //modelBuilder.Configurations.Add(new vendaMap());
            //modelBuilder.Entity<venda>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new vendaPagamentoMap());
            //modelBuilder.Entity<vendaPagamento>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            ////modelBuilder.Configurations.Add(new vendaProdutoMap());
            ////modelBuilder.Entity<vendaProduto>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new vendaStatusMap());
            //modelBuilder.Entity<vendaStatus>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            ////==========================================

            ////Cadastro Geral ===========================
            //modelBuilder.Configurations.Add(new CNAEMap());
            //modelBuilder.Configurations.Add(new cidadeMap());
            //modelBuilder.Entity<cidade>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new estadoMap());
            //modelBuilder.Entity<estado>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new paisMap());
            //modelBuilder.Entity<pais>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
            //modelBuilder.Configurations.Add(new CFOPMap());
            ////==========================================


            //modelBuilder.Configurations.Add(new messageMap());
            //modelBuilder.Entity<systemMessage>().Ignore(m => m.success);

            //this.Configuration.LazyLoadingEnabled = false;
        }



        public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context>
        {

        }

    }
}
