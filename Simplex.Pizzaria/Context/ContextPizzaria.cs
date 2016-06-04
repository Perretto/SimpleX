using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Simplex.Pizzaria.Models;
using SimpleX.Model;
using SimpleX.ModelCore;
using SimpleX.ModelCore.Contexts;
using Simplex.Pizzaria.Migrations;
using Simplex.Pizzaria.Models.Mapping;

namespace Simplex.Pizzaria.Context
{
    public class ContextPizzaria : SimpleX.ModelCore.Contexts.Context
    {
      
        public DbSet<cliente> cliente { get; set; }

        public DbSet<produto> produto { get; set; }

        

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

            modelBuilder.Configurations.Add(new vendaProdutoMap());
            modelBuilder.Entity<Simplex.Pizzaria.Models.vendaProduto>().HasOptional(a => a.empresa).WithOptionalDependent().WillCascadeOnDelete(false);
                        
                 
            //this.Configuration.LazyLoadingEnabled = false;
        }



        public new class ContextInitializer : DropCreateDatabaseIfModelChanges<ContextPizzaria>
        {

        }
        
    }
}