using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loja.Models;
using loja.ViewModels;

namespace loja.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies Movies/ramdom
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
                
            return View(viewModel);
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model
            //return View(Movie);
            //return content("hello word");
            //return httpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("index", "Home", new { pages = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month )
        {
            return Content(year + "/" + month);
        }

    }
}