namespace BusinessSite.Migrations
{
    using BusinessSite.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BusinessSite.DAL.SiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BusinessSite.DAL.SiteContext context)
        {
            var emails = new List<Email>
            {
                new Email { EmailAddress = "info@arturstruzik.pl" }
            };
            emails.ForEach(s => context.Emails.AddOrUpdate(p => p.EmailAddress, s));
            context.SaveChanges();
        }
    }
}
