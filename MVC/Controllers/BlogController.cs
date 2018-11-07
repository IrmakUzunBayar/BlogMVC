using MVC.Models.DataModels;
using MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BlogController : BaseController
    {
        private readonly BlogContext db;

        public BlogController()
        {
            db = new BlogContext();
        }
      
        

        public ActionResult Index(int id = 0)
        {
            IEnumerable<Blogs> blogList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Blogs").Result;
            //blogList = response.Content.ReadAsAsync<IEnumerable<Blogs>>().Result;


            if (id == 0)
                return View(db.Blogs.ToList());
            else
                return View(db.Blogs.Where(x => x.CategoryId == id).ToList());
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Blogs());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Blogs/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Blogs>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Blogs blg)
        {
            if (blg.BlogId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Blogs", blg).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Blogs/" + blg.BlogId, blg).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public BlogCommentVM GetBlogData(int blogId)
        {
            BlogCommentVM vm;

            var blog = db.Blogs.Find(blogId);
            var comments = db.Comments.Where(x => x.BlogId == blogId).ToList();

            vm = new BlogCommentVM()
            {
                Blogs = blog,
                Comments = comments
            };

            return vm;
        }

        [HttpPost]
        public ActionResult Search(string txtSearch)
        {
            var data = db.Blogs.Where(x => x.Title.Contains(txtSearch)).ToList();
            TempData["SearchData"] = data;

            return RedirectToAction("SearchResult", "Blog");
        }


        public ActionResult SearchResult()
        {
            return View();
        }


        public ActionResult Detay(int id = 0)
        {
            if (id != 0)
                return View(GetBlogData(id));
            else
                return RedirectToAction("Index", "Blog");
        }

        [HttpPost]
        public ActionResult Detay(BlogCommentVM vm, int id)
        {
            try
            {
                vm.Comment.BlogId = id;
                db.Comments.Add(vm.Comment);
                db.SaveChanges();

                ViewBag.Success = "True";
            }
            catch (Exception)
            {
                ViewBag.Success = "False";
            }

            return View(GetBlogData(id));
        }
    }
}