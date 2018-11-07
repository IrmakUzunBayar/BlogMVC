using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.DataModels
{
    public class Comments
    {

        [Key]
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public string Comment { get; set; }

        public virtual Blogs Blogs { get; set; }
    }
}