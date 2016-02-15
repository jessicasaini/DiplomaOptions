namespace OptionsWebsite.Migrations.BCITMigrations
{
    using Models.BCITModels;
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.YearTerms.AddOrUpdate(
                y => y.YearTermId,
                DummyData.GetYearTerm().ToArray()
            );
            context.SaveChanges();

            context.Options.AddOrUpdate(
                o => o.OptionId,
                DummyData.GetOption().ToArray()
            );
            context.SaveChanges();


        }
    }
}
