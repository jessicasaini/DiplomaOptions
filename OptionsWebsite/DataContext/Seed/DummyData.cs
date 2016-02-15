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
                    IsActive = true
                },
            };

            return Options;
        }

        //[Key]
        //public int OptionId { get; set; }
        //[StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 5)]
        //public string Title { get; set; }
        //public bool IsActive { get; set; }
    }
}
