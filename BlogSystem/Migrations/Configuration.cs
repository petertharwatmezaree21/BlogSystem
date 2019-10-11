namespace BlogSystem.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogSystem.Models.ApplicationDbContext context)
        {


            context.Categories.Add(new Models.Category { Title = "Sport" });
            context.Categories.Add(new Models.Category { Title = "political" });
            context.Categories.Add(new Models.Category { Title = "Social" });
            context.Categories.Add(new Models.Category { Title = "Other" });


            context.Posts.Add(new Models.Post
            {
                Author = "Dummy",
                AuthorEmail = "Dummy@gmail.com"
            ,
                Body = "Messi is the best palyer in the world",
                CategoryId = 1,
                PublishedDate = DateTime.Now,
                Title = "Messi"
            });
            context.Posts.Add(new Models.Post
            {
                Author = "Dummy2",
                AuthorEmail = "Dummy2@gmail.com"
,
                Body = "The Hug Dam is Ethoipean will be agreat danger for Egypt",
                CategoryId = 2,
                PublishedDate = DateTime.Now,
                Title = "Ethop"
            });
        }
    }
}
