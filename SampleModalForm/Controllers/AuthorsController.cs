using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SampleModalForm.Models;

namespace SampleModalForm.Controllers
{
    public class AuthorsController : Controller
    {
        private CommerceModel db = new CommerceModel();
        // GET: Authors
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAuthorsData()
        {
            var results = from r in db.Authors
                          select new
                          {
                              AuthorID = r.AuthorID,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              FullName = r.FirstName + " " +r.LastName
                          };
            return Json(results,JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchByName(string txtNama)
        {
            var results = from r in db.Authors
                          where r.FirstName.ToLower().Contains(txtNama.ToLower())
                          select new
                          {
                              AuthorID = r.AuthorID,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              FullName = r.FirstName + " " + r.LastName
                          };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAuthors()
        {
            return View();
        }

        //menggunakan auto complete dengan select2
        public JsonResult GetAuthorSelect()
        {
            var results = from a in db.Authors
                          select new
                          {
                              id = a.AuthorID,
                              text = a.FirstName
                          };

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenggunakanSelectBox()
        {
            return View();
        }
    }
}