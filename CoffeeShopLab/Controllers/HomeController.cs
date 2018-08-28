using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShopLab.Models;

namespace CoffeeShopLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDB ORM = new CoffeeShopDB();
            List<user> users = new List<user>();
            users = ORM.users.ToList();
            user activeUser = users.ElementAt(users.Count-1);
            ViewBag.ActiveUser = activeUser;
            ViewBag.Items = ORM.item.ToList();
            return View();
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

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult SaveUser(user newUser)
        {
            CoffeeShopDB ORM = new CoffeeShopDB();
            // TODO: Validation
            if(newUser.firstname != null && newUser.lastname != null && newUser.email != null && newUser.password != null)
            {
                ORM.users.Add(newUser);
                ORM.SaveChanges();
            }
            else
            {
                return RedirectToAction("RegFail");
            }
            return RedirectToAction("Index");
        }

        public ActionResult RegFail()
        {
            return View();
        }
    }
}