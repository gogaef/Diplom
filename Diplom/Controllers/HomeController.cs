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
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            return View(new StartupArticle());
            else
            {
                var startup = _repos.GetStartup((int)id);
                return View(startup);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StartupArticle startup)
        {
            if(startup.Id > 0)
            {
                _repos.UpdateStartup(startup);
            }
            else
            _repos.AddStartup(startup);
            if(await _repos.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(startup);
            }            
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repos.RemoveStartup(id);
            await _repos.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
