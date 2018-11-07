using MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModels
{
    public class BlogCommentVM
    {
        public Blogs Blogs { get; set; }
        public Comments Comment { get; set; }
        public List<Comments> Comments { get; set; }


    }
}