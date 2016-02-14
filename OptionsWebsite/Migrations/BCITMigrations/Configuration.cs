namespace OptionsWebsite.Migrations.BCITMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OptionsWebsite.Models.BCITModels.BCITContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\BCITMigrations";
        }

        protected override void Seed(OptionsWebsite.Models.BCITModels.BCITContext context)
        {

        }
    }
}
