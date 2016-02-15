using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OptionsWebsite.Models.BCITModels
{
    public class BCITContext: DbContext
    {
        public BCITContext() : base("DefaultConnection")  { }

        public DbSet<Choice> Choices { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<YearTerm> YearTerms { get; set; }

    }
}