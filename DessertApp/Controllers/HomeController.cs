using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DessertApp.Models;


namespace DessertApp.Controllers
{
    public class HomeController : Controller
    {

        private DessertDb db = new DessertDb();


        public ActionResult Index()
        {
            return View(db.Desserts.ToList());

            //Get all desserts
            //my model image url ==@model.url---in view and url.action to find/take you to recipe of image


        }


        public ActionResult TopRated()
        {
            var dessert = GetTopRated();

            return PartialView("_TopRated", dessert);
        }


        private Dessert GetTopRated()

        {
            var dessert = db.Desserts
                .OrderByDescending(a => a.Like)
                .First();
                
            return dessert;
           

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