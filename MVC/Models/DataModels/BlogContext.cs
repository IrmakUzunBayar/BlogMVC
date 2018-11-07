using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Models.DataModels
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=BlogConnection")
        {

        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}