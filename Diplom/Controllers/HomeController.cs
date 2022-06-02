using Microsoft.AspNetCore.Mvc;
using Diplom.Models;
using Diplom.Data;
using System.Threading.Tasks;
using Diplom.Data.Repository;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repos;

        public HomeController(IRepository repos)
        {
            _repos = repos;
        }
        public IActionResult Index()
        {
            var startups = _repos.GetAllStartups();
            return View(startups);
        }

        public IActionResult Startup(int id)
        {
            var startup = _repos.GetStartup(id);
            return View(startup);
        }
    }
}
