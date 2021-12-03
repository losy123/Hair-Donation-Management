using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;
using ProjectGmarDonation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectGmarDonation.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index([Bind(Include = "Id,Amount,User_Id")] MoneyDonation moneyDonation)
        {
            moneyDonation.User_Id = User.Identity.GetUserId();
            db.moneydonation.Add(moneyDonation);
            db.SaveChanges();
            return View();
        }


        public class DonateModel
        {
            public string business { get; set; }
            public string notify_url { get; set; }
            public string invoice { get; set; }
            public string item_name { get; set; }
            public string item_number { get; set; }
            public string amount { get; set; }
        }
       // [HttpPost]
       // public ActionResult Donate(DonateModel donateData)
      //  {
            // save it to db check if data not before and not empty
      //      db.moneydonation.Add(new MoneyDonation()
       //     {
       //         Amount = decimal.Parse(donateData.amount)
      //      });
     //       return Redirect("https://www.paypal.com/donate?token=rlmhTvAYZ18ZUudNNHY-Sn3FtZbrdg6pW7VnfchhesTbiST5fQqHlRIZ_5dz0vGrlcgXRljqsDaCrcUK");
    //    }

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