using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProjectGmarDonation.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Remoting.Contexts;
using System.Web.Security;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace ProjectGmarDonation.Controllers
{
    [Authorize]
    public class HairDonationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HairDonations
        // searchstring1=hairtype   searchstring2=hairlength      searchstring3=rgb(hex)

        public ActionResult Index(string searchString1, string searchString2, string searchString3)
        {
            var hair = from s in db.hairdonation
                       select s;

            foreach (var item in hair)
            {
                item.isColor = false;
            }
            if ((!String.IsNullOrEmpty(searchString1)) && (!String.IsNullOrEmpty(searchString2)) && (searchString3 != "#000000"))
            {
                foreach (var item in hair)
                {

                    if (ColorMatching(searchString3, item.HairColor) == true)
                    {
                        item.isColor = true;
                    }
                    else if (item.HairColor2 != null)
                    {
                        if (ColorMatching(searchString3, item.HairColor2) == true)
                        {
                            item.isColor = true;
                        }
                        else if (item.HairColor3 != null)
                        {
                            if (ColorMatching(searchString3, item.HairColor3) == true)
                            {
                                item.isColor = true;
                            }
                        }

                    }
                }

                db.SaveChanges();
                // if the specifec search (hex) contains the example color exist(true) it shows the requested details.
                hair = hair.Where(s => s.HairLength.Contains(searchString2)
                                      && s.HairType.Contains(searchString1)
                                      && (s.isColor == true));
            }       
            else if ((!String.IsNullOrEmpty(searchString1)) && (!String.IsNullOrEmpty(searchString2)))
            {
                hair = hair.Where(s => s.HairLength.Contains(searchString2)
                      && s.HairType.Contains(searchString1));
            }       
            else if ((!String.IsNullOrEmpty(searchString1)) && (searchString3 != "#000000"))
            {
                foreach (var item in hair)
                {

                    if (ColorMatching(searchString3, item.HairColor) == true)
                    {
                        item.isColor = true;
                    }
                    else if (item.HairColor2 != null)
                    {
                        if (ColorMatching(searchString3, item.HairColor2) == true)
                        {
                            item.isColor = true;
                        }
                        else if (item.HairColor3 != null)
                        {
                            if (ColorMatching(searchString3, item.HairColor3) == true)
                            {
                                item.isColor = true;
                            }
                        }

                    }
                }

                db.SaveChanges();
                // if the specifec search (hex) contains the example color exist(true) it shows the requested details.
                hair = hair.Where(s => s.HairType.Contains(searchString1)
                                      && (s.isColor == true));
            }
            else if ((!String.IsNullOrEmpty(searchString2)) && (searchString3 != "#000000"))
            {
                foreach (var item in hair)
                {

                    if (ColorMatching(searchString3, item.HairColor) == true)
                    {
                        item.isColor = true;
                    }
                    else if (item.HairColor2 != null)
                    {
                        if (ColorMatching(searchString3, item.HairColor2) == true)
                        {
                            item.isColor = true;
                        }
                        else if (item.HairColor3 != null)
                        {
                            if (ColorMatching(searchString3, item.HairColor3) == true)
                            {
                                item.isColor = true;
                            }
                        }

                    }
                }

                db.SaveChanges();
                // if the specifec search (hex) contains the example color exist(true) it shows the requested details.
                hair = hair.Where(s => s.HairLength.Contains(searchString2)
                                      && (s.isColor == true));
            }
            else if (!String.IsNullOrEmpty(searchString1))
            {
                hair = hair.Where(s => s.HairType.Contains(searchString1));
            }
            else if (!String.IsNullOrEmpty(searchString2))
            {
                hair = hair.Where(s => s.HairLength.Contains(searchString2));
            }
            else if (!String.IsNullOrEmpty(searchString3))
            {
                foreach (var item in hair)
                {

                    if (ColorMatching(searchString3, item.HairColor) == true)
                    {
                        item.isColor = true;
                    }
                    else if (item.HairColor2 != null)
                    {
                        if (ColorMatching(searchString3, item.HairColor2) == true)
                        {
                            item.isColor = true;
                        }
                        else if(item.HairColor3 != null)
                        {
                            if (ColorMatching(searchString3, item.HairColor3) == true)
                            {
                                item.isColor = true;
                            }
                        }

                    }
                }

                    db.SaveChanges();
                hair = hair.Where(s => s.isColor == true);
            }
            return View(hair.ToList());
        }

        public Boolean ColorMatching(string x , string y)
        {
            int difference = 0, difference2 = 0, difference3 = 0;
            int red = 0, green = 0, blue = 0;
            int red2 = 0, green2 = 0, blue2 = 0;

            string colora = x.Replace("#", "");

            red = int.Parse(colora.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            green = int.Parse(colora.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            blue = int.Parse(colora.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            string Colorb = y.Replace("#", "");

            red2 = int.Parse(Colorb.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            green2 = int.Parse(Colorb.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            blue2 = int.Parse(Colorb.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            difference = Math.Abs(red - red2);
            difference2 = Math.Abs(green - green2);
            difference3 = Math.Abs(blue - blue2);

            if (difference <= 10 && difference2 <= 10 && difference3 <= 10)
            {
                return true;
            }
            return false;
        }


        // GET: HairDonations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HairDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HairType,HairColor,HairLength,imgurl,HairColor2,HairColor3")] HairDonation hairDonation,HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                hairDonation.Donor_Id = User.Identity.GetUserId();
                hairDonation.Donor_Email = User.Identity.GetUserName();

                hairDonation.imgurl = new byte[image1.ContentLength];
                image1.InputStream.Read(hairDonation.imgurl, 0, image1.ContentLength);

                if (hairDonation.HairColor2 == "#000000")
                {
                    hairDonation.HairColor2 = null;
                }
                if (hairDonation.HairColor3 == "#000000")
                {
                    hairDonation.HairColor3 = null;
                }
               
                db.hairdonation.Add(hairDonation);
                db.SaveChanges();
            }

            return View(hairDonation);
        }


        // GET: HairDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairDonation hairDonation = db.hairdonation.Find(id);
            if (hairDonation == null)
            {
                return HttpNotFound();
            }
            return View(hairDonation);
        }

        // POST: HairDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HairDonation hairDonation = db.hairdonation.Find(id);
            db.hairdonation.Remove(hairDonation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult request(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairDonation hairDonation = db.hairdonation.Find(id);
            if (hairDonation == null)
            {
                return HttpNotFound();
            }
            return View(hairDonation);
        }

        // POST: HairDonations/request/5
        [HttpPost, ActionName("request")]
        [ValidateAntiForgeryToken]
        public ActionResult RequestConfirmed(int id)
        {
            HairDonation hairDonation = db.hairdonation.Find(id);
            hairDonation.Requester_Id = User.Identity.GetUserId();
            hairDonation.IsAvailable = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MyRequstedHair()
        {
            var hair = from s in db.hairdonation
                       select s;
            var id = User.Identity.GetUserId();
            hair = hair.Where(s => s.Requester_Id.Contains(id));

            return View (hair.ToList());
        }
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairDonation hairDonation = db.hairdonation.Find(id);
            if (hairDonation == null)
            {
                return HttpNotFound();
            }
            return View(hairDonation);
        }

        // POST: HairDonations/request/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveConfirmed(int id)
        {
            HairDonation hairDonation = db.hairdonation.Find(id);
            hairDonation.Approved = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ApproveIndex()
        {
            var hair = from s in db.hairdonation
                       select s;

            return View(hair.ToList());
        }
    }

}

