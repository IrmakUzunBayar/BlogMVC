using MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        private readonly BlogContext db;
        public BaseController()
        {
            db = new BlogContext();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            TempData["CategoryList"] = db.Categories.ToList();
        }
    }
}