using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Simplex.Pizzaria.Models;
using SimpleX.Model;
using SimpleX.ModelCore;
using SimpleX.ModelCore.Contexts;
using SimpleX.ModelCore.Mapping;
using Simplex.Pizzaria.Migrations;

namespace Simplex.Pizzaria.Context
{
    public class ContextPizzaria : SimpleX.ModelCore.Contexts.Context
    {
      
        //public DbSet<Teste> Teste { get; set; }

        

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

                 
            //modelBuilder.Configurations.Add(new testeMap());
            //this.Configuration.LazyLoadingEnabled = false;
        }



        public new class ContextInitializer : DropCreateDatabaseIfModelChanges<ContextPizzaria>
        {

        }
        
    }
}