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


            context.Choices.AddOrUpdate(z => new
            {
                z.StudentId,
                z.StudentFirstName,
                z.StudentLastName,
                z.YearTermId,
                z.SelectionDate,
                z.FirstChoiceOptionId,
                z.SecondChoiceOptionId,
                z.ThirdChoiceOptionId,
                z.FourthChoiceOptionId,
                z.YearTerm,
                z.FirstOption,
                z.SecondOption,
                z.ThirdOption,
                z.FourthOption
            }, DummyData.GetChoices().ToArray());
            context.SaveChanges();

        }
    }
}
