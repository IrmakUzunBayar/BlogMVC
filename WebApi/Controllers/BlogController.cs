using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BlogController : ApiController
    {
        private BlogUcDbEntities db = new BlogUcDbEntities();

        // GET: api/Blog
        public IQueryable<Blogs> GetBlogs()
        {
            return db.Blogs;
        }

        // GET: api/Blog/5
        [ResponseType(typeof(Blogs))]
        public IHttpActionResult GetBlogs(int id)
        {
            Blogs blogs = db.Blogs.Find(id);
            if (blogs == null)
            {
                return NotFound();
            }

            return Ok(blogs);
        }

        // PUT: api/Blog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlogs(int id, Blogs blogs)
        {
           

            if (id != blogs.BlogId)
            {
                return BadRequest();
            }

            db.Entry(blogs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Blog
        [ResponseType(typeof(Blogs))]
        public IHttpActionResult PostBlogs(Blogs blogs)
        {
           

            db.Blogs.Add(blogs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = blogs.BlogId }, blogs);
        }

        // DELETE: api/Blog/5
        [ResponseType(typeof(Blogs))]
        public IHttpActionResult DeleteBlogs(int id)
        {
            Blogs blogs = db.Blogs.Find(id);
            if (blogs == null)
            {
                return NotFound();
            }

            db.Blogs.Remove(blogs);
            db.SaveChanges();

            return Ok(blogs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogsExists(int id)
        {
            return db.Blogs.Count(e => e.BlogId == id) > 0;
        }
    }
}