using OptionsWebsite.Models.BCITModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OptionsWebsite.Models.BCITModels
{
    public class DummyData
    {
        public static List<YearTerm> GetYearTerm()
        {
            List<YearTerm> YearTerms = new List<YearTerm>()
            {
                new YearTerm {
                    Year = 2015,
                    Term = 20,
                    IsDefault = false
                },
                new YearTerm {
                    Year = 2015,
                    Term = 30,
                    IsDefault = false
                },
                new YearTerm {
                    Year = 2016,
                    Term = 10,
                    IsDefault = false
                },
                new YearTerm {
                    Year = 2016,
                    Term = 30,
                    IsDefault = true
                }
            };

            return YearTerms;
        }


        public static List<Option> GetOption()
        {
            List<Option> Options = new List<Option>
            {
                new Option
                {
                    Title = "Data Communications",
                    IsActive = true
                },
                new Option
                {
                    Title = "Client Server",
                    IsActive = true
                },
                new Option
                {
                    Title = "Digital Processing",
                    IsActive = true
                },
                new Option
                { 
                    Title = "Information Systems",
                    IsActive = true
                },
                new Option
                {
                    Title = "Database",
                    IsActive = false
                },
                new Option
                {
                    Title = "Web & Mobile",
                    IsActive = true
                },
                new Option
                { 
                    Title = "Tech Pro",
                    IsActive = false
                },
            };

            return Options;
        }

        public static List<Choice> GetChoices()
        {
            BCITContext c = new BCITContext();

            List<Choice> Choices = new List<Choice>
            {
                new Choice {
                    StudentId = "A00987650",
                    StudentFirstName = "Bob",
                    StudentLastName = "Smith",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title == "Client Server").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987651",
                    StudentFirstName = "Stuart",
                    StudentLastName = "Smith",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Client Server").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987652",
                    StudentFirstName = "Donald",
                    StudentLastName = "Duck",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Client Server").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice { 
                    StudentId = "A00987653",
                    StudentFirstName = "Homer",
                    StudentLastName = "Simpson",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Digital Processing").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987654",
                    StudentFirstName = "Marge",
                    StudentLastName = "Simpson",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Database").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Digital Processing").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987655",
                    StudentFirstName = "Bart",
                    StudentLastName = "Simpson",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Digital Processing").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987656",
                    StudentFirstName = "Bart",
                    StudentLastName = "Simpson",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Client Server").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987657",
                    StudentFirstName = "Mickey",
                    StudentLastName = "Mouse",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Digital Processing").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987658",
                    StudentFirstName = "Fred",
                    StudentLastName = "Flintstone",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987659",
                    StudentFirstName = "Wilma",
                    StudentLastName = "Flintstone",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2015).Where(u => u.Term == 30).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987660",
                    StudentFirstName = "Minnie",
                    StudentLastName = "Mouse",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987661",
                    StudentFirstName = "Albert",
                    StudentLastName = "Wei",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Digital Processing").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987662",
                    StudentFirstName = "Darcy",
                    StudentLastName = "Smith",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Client Server").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987663",
                    StudentFirstName = "Jason",
                    StudentLastName = "Harrison",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987664",
                    StudentFirstName = "Medhat",
                    StudentLastName = "Elmasry",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Information Systems").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Client Server").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987665",
                    StudentFirstName = "Mirela",
                    StudentLastName = "Gutica",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987666",
                    StudentFirstName = "John",
                    StudentLastName = "Doe",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987667",
                    StudentFirstName = "Bill",
                    StudentLastName = "Gates",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Digital Processing").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987668",
                    StudentFirstName = "Mark",
                    StudentLastName = "Zuckerberg",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Database").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Ditial Processing").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Web & Mobile").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },
                new Choice {
                    StudentId = "A00987669",
                    StudentFirstName = "Albert",
                    StudentLastName = "Einstein",
                    YearTermId = c.YearTerms.Where(u => u.Year == 2016).Where(u => u.Term == 10).Select(u => u.YearTermId).SingleOrDefault(),
                    SelectionDate = DateTime.Now,
                    FirstChoiceOptionId = (int?)c.Options.Where(u => u.Title == "Data Communications").Select(u => u.OptionId).SingleOrDefault(),
                    SecondChoiceOptionId =(int?)c.Options.Where(u => u.Title == "Ditial Processing").Select(u => u.OptionId).SingleOrDefault(),
                    ThirdChoiceOptionId = (int?)c.Options.Where(u => u.Title ==  "Tech Pro").Select(u => u.OptionId).SingleOrDefault(),
                    FourthChoiceOptionId =  (int?)c.Options.Where(u => u.Title ==  "Database").Select(u => u.OptionId).SingleOrDefault(),
                    YearTerm = null,
                    FirstOption = null,
                    SecondOption = null,
                    ThirdOption = null,
                    FourthOption = null
                },

            };

            return Choices;
        }

    }
}
