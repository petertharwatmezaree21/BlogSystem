using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Controllers
{
    
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
           var UserPost= Context.Posts.Include("Category").Where(p => p.AuthorEmail == User.Identity.Name).ToList();
            return View(UserPost);
        }

        public ActionResult Create()
        {
            
            ViewBag.CategoryId = new SelectList(Context.Categories.ToList(), "Id", "Title");
            var Post = new Post();
            return View(Post);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Post post,string NewCategory)
        {
            Category cat = new Category();
            cat.Title = NewCategory;
            Context.Categories.Add(cat);
            Context.SaveChanges();
           var LastCate= Context.Categories.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            post.Category = LastCate;
            Context.Posts.Add(post);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            
         var EditPost =Context.Posts.Include("Category").Where(p => p.AuthorEmail == User.Identity.Name && p.Id == id).FirstOrDefault();
            ViewBag.CategoryId = new SelectList(Context.Categories.ToList(),"Id", "Title", EditPost.Category.Id);
            return View(EditPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                Context.Entry<Post>(post).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            var EditPost = Context.Posts.Include("Category").Where(p => p.AuthorEmail == User.Identity.Name && p.Id == post.Id).FirstOrDefault();
            ViewBag.CategoryId = new SelectList(Context.Categories.ToList(), "Id", "Title", EditPost.Category.Title);
            return View(post);
        }

        [HttpPost]
        public ActionResult Delete(int? PostId)
        {
            Context.Posts.Remove(Context.Posts.Where(p => p.Id == PostId).FirstOrDefault());
            Context.SaveChanges();
            return  Json(Url.Action("Index", "Admin"),JsonRequestBehavior.AllowGet);
        }
    }
}