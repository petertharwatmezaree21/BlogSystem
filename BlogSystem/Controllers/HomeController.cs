using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Controllers
{
    public class HomeController : Controller
    {
        public static int counter = 0;
        ApplicationDbContext Context = new ApplicationDbContext();
        public ActionResult Index(int? CategoryId)
        {
           
            List<Post> AllPostes = new List<Post>();
            if (CategoryId == null)
            {
                ViewBag.CategoryId = new SelectList(Context.Categories.Where(c => c.Title.Equals("Other")).ToList(), "Id", "Title");
             AllPostes= Context.Posts.Include("Category").ToList();
                counter++;
                if(counter > 1)
                return View("ChoosePosts", AllPostes);
            }
            else
            {
                ViewBag.CategoryId = new SelectList(Context.Categories.Where(c => c.Id != 10).ToList(), "Id", "Title", CategoryId.Value);
                AllPostes = Context.Posts.Include("Category").Where(p => p.CategoryId == CategoryId).ToList();
                return View("ChoosePosts", AllPostes);
            }

            return View(AllPostes);
        }

        public ActionResult ChoosePosts(List<Post> Posts)
        {

            return View(Posts);
        }

        public ActionResult DesignComment(List<Comment> Commnets,int? PostId)
        {
            Commnets = Context.Comments.Where(c => c.PostId == PostId).OrderBy(c=>c.CommentDate).ToList();
            return View(Commnets);
        }

        public ActionResult ReadPost(int PostId)
        {
            var post= Context.Posts.Include("Comments").Include("Category").Where(p => p.Id == PostId).FirstOrDefault();
            return View(post);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            Context.Comments.Add(comment);
            Context.SaveChanges();

            var Commnets = Context.Comments.Where(c=>c.PostId== comment.PostId).OrderBy(c => c.CommentDate).ToList();
            return View("DesignComment", Commnets);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}