using OptionsWebsite.Models.BCITModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsWebsite.Models.BCITModels
{
    class DummyData
    {
        public static List<YearTerm> GetYearTerm()
        {
            List<YearTerm> YearTerms = new List<YearTerm>()
            {
                new YearTerm {
                    YearTermId = 0,
                    Year = 2015,
                    Term = 20,
                    IsDefault = false
                },
                new YearTerm {
                    YearTermId = 1,
                    Year = 2015,
                    Term = 30,
                    IsDefault = false
                },
                new YearTerm {
                    YearTermId = 2,
                    Year = 2016,
                    Term = 10,
                    IsDefault = false
                },
                new YearTerm {
                    YearTermId = 3,
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
                    OptionId = 0,
                    Title = "Data Communications",
                    IsActive = true
                },
                new Option
                {
                    OptionId = 1,
                    Title = "Client Server",
                    IsActive = true
                },
                new Option
                {
                    OptionId = 2,
                    Title = "Digital Processing",
                    IsActive = true
                },
                new Option
                {
                    OptionId = 3,
                    Title = "Information Systems",
                    IsActive = true
                },
                new Option
                {
                    OptionId = 4,
                    Title = "Database",
                    IsActive = false
                },
                new Option
                {
                    OptionId = 5,
                    Title = "Web & Mobile",
                    IsActive = true
                },
                new Option
                {
                    OptionId = 6,
                    Title = "Tech Pro",
                    IsActive = true
                },
            };

            return Options;
        }
    }
}
