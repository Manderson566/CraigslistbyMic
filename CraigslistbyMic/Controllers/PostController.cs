
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
        public ActionResult Index(int? id, int? Value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (Value == null)
            {
                ViewBag.CurrentSub = db.Posts.Where(s => s.SubCatagoryId == id).ToList();
            }
            else if (Value == 1)
            {
                ViewBag.CurrentSub = db.Posts.Where(s => s.SubCatagoryId == id).OrderByDescending(o => o.Created).ToList();
            }
            else if (Value == 2)
            {
                ViewBag.CurrentSub = db.Posts.Where(s => s.SubCatagoryId == id).OrderByDescending(o => o.Price).ToList();
            }
            else if (Value == 3)
            {
                ViewBag.CurrentSub = db.Posts.Where(s => s.SubCatagoryId == id).OrderBy(o => o.Price).ToList();
            }

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
        public ActionResult Create([Bind(Include = "Id,Title,Body,CityId,SubCatagoryId")] Post post)
        {

            var uploadedFile = Request.Files[0];
            string filename = $"{DateTime.Now.Ticks}{uploadedFile.FileName}";
            var serverPath = Server.MapPath(@"~\Uploads");
            var fullPath = Path.Combine(serverPath, filename);
            uploadedFile.SaveAs(fullPath);
            var image = new ImageUpload
            {
                File = filename,
                PostTitle = post.Title
            };
            post.Created = DateTime.Now;
            post.OwnerId = User.Identity.GetUserId();
            db.Posts.Add(post);
            db.ImageUploads.Add(image);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");


        }
    }
}


