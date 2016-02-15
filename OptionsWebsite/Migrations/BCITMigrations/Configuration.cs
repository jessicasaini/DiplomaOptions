namespace OptionsWebsite.Migrations.BCITMigrations
{
    using Models.BCITModels;    //using Models.BCITModels;
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
            context.YearTerms.AddOrUpdate(
          y => new { y.Year, y.Term },
          DummyData.GetYearTerm().ToArray()
      );
            context.SaveChanges();

            context.Options.AddOrUpdate(
                o => new { o.Title },
                DummyData.GetOption().ToArray()
            );
            context.SaveChanges();


        }
    }
}
