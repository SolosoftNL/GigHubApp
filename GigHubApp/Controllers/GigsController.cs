using GigHubApp.Models;
using GigHubApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace GigHubApp.Controllers
{
    public class GigsController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public GigsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var genre = new GigFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View(genre);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            var artist = _dbContext.Users.Single(
                u => u.Id == userId);

            var genre = _dbContext.Genres.Single(g => g.Id == viewModel.Genre);

            try
            {
                var gig = new Gig
                {
                    Artist = artist,
                    DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                    Genre = genre,
                    Venue = viewModel.Venue,
                };

                _dbContext.Gigs.Add(gig);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.GetBaseException());
                throw;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}