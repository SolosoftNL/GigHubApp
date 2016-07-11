using GigHubApp.Models;
using GigHubApp.ViewModels;
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
    }
}