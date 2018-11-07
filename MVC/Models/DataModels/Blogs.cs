using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.DataModels
{
    public class Blogs
    {
        [Key]
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime Created { get; set; }

        public virtual Categories Categories { get; set; }

    }
}