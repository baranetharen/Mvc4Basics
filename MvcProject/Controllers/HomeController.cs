using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace MvcProject.Controllers
{
   
    public class HomeController : Controller
    {
        OdeToFoodDb odeToFoodDb = new OdeToFoodDb();

        public ActionResult Autocomplete(string term)
        {
            var model = odeToFoodDb.Restaurants.
                Where(x => x.Name.StartsWith(term))
                .Take(10)
                .Select(r =>
                 new
                 {
                     lable = r.Name
                 }
             );
            return Json(model, JsonRequestBehavior.AllowGet);
           
        }

        [OutputCache(Duration = 5)]
        public ActionResult Index(string searchTerm = null , int pageNumber =1)
        {
            var model = odeToFoodDb.Restaurants.OrderByDescending(r => r.Reviews.Average(reviews => reviews.Rating))
              .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
              .Select(r => new RestaurantListViewModel
              {
                  Id = r.Id,
                  Name = r.Name,
                  City = r.City,
                  Country = r.Country,
                  CountOfReviews = r.Reviews.Count()
              }).ToPagedList(pageNumber,10);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

        
        public ActionResult About()
        {
            var model = new AboutModel
            {
                Name = "Scott",
                Location = "TamilNadu India"
            };
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (odeToFoodDb != null)
            {
                odeToFoodDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}