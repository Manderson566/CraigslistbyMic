
using System.Web.Mvc;
using CraigslistbyMic.Models;
using System.Net;
using System.Linq;
using Microsoft.AspNet.Identity;
using System;
using System.IO;

namespace CraigslistbyMic.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.CurrentSub = db.Posts.Where(s => s.SubCatagoryId == id).ToList();

            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.SubCatagoryId = new SelectList(db.SubCatagories, "Id", "Title");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {

            var uploadedFile = Request.Files[0];
            string filename = $"{DateTime.Now.Ticks}{uploadedFile.FileName}";
            var serverPath = Server.MapPath(@"~\Uploads");
            var fullPath = Path.Combine(serverPath, filename);
            uploadedFile.SaveAs(fullPath);

            var image = new ImageUpload
            {
                File = filename,
                PostId = post.Id
            };
            db.ImageUploads.Add(image);


            post.Created = DateTime.Now;
            post.OwnerId = User.Identity.GetUserId();
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");


        }
    }
}


