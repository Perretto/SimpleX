using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Simplex.Pizzaria.Models;
using SimpleX.ModelCore.Contexts;
using Simplex.Pizzaria.Migrations;

namespace Simplex.Pizzaria.Context
{
    public class ContextPizzaria : SimpleX.ModelCore.Contexts.Context
    {
        //Administrador=============================
        public DbSet<empresa> empresa { get; set; }
        public DbSet<empresaEndereco> empresaEndereco { get; set; }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<URA> URA { get; set; }
        public DbSet<statusURA> statusURA { get; set; }

        //==========================================

        //Cadastro==================================
        public DbSet<cliente> cliente { get; set; }
        public DbSet<clienteContato> clienteContato { get; set; }
        public DbSet<clienteEndereco> clienteEndereco { get; set; }

        public DbSet<fornecedor> fornecedor { get; set; }
        public DbSet<fornecedorContato> fornecedorContato { get; set; }
        public DbSet<fornecedorEndereco> fornecedorEndereco { get; set; }

        public DbSet<produto> produto { get; set; }
        public DbSet<produtoCategoria> produtoCategoria { get; set; }
        public DbSet<produtoComposicao> produtoComposicao { get; set; }
        public DbSet<produtoTipo> produtoTipo { get; set; }

        //==========================================

        //Movimentação==============================
        public DbSet<formaPagamento> formaPagamento { get; set; }
        public DbSet<compra> compra { get; set; }
        public DbSet<compraPagamento> compraPagamento { get; set; }
        public DbSet<compraProduto> compraProduto { get; set; }
        public DbSet<compraStatus> compraStatus { get; set; }

        public DbSet<venda> venda { get; set; }
        public DbSet<vendaPagamento> vendaPagamento { get; set; }
        public DbSet<vendaProduto> vendaProduto { get; set; }
        public DbSet<vendaStatus> vendaStatus { get; set; }
        //==========================================

        //Cadastro Geral ===========================
        public DbSet<CNAE> CNAE { get; set; }
        public DbSet<cidade> cidade { get; set; }
        public DbSet<estado> estado { get; set; }
        public DbSet<pais> pais { get; set; }
        public DbSet<CFOP> CFOP { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            //this.Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer<ContextPizzaria>(null);

           //Database.SetInitializer(new CreateOrMigrateDatabaseInitializer<ContextPizzaria, Simplex.Pizzaria.Migrations.Configuration>());

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextPizzaria, SimpleX.ModelCore.Migrations.Configuration>());

            Database.SetInitializer(new CreateDatabaseIfNotExists<ContextPizzaria>());

            //var configuration = new GalleryDbMigrationConfiguration();
            //var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);
            //if (migrator.GetPendingMigrations().Any())
            //{
            //    migrator.Update();
            //}

            base.OnModelCreating(modelBuilder);
          
            //this.Configuration.LazyLoadingEnabled = false;
        }



        public new class ContextInitializer : DropCreateDatabaseIfModelChanges<ContextPizzaria>
        {

        }
        
    }
}