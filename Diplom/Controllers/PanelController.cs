using Diplom.Data.Repository;
using Diplom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repos;

        public PanelController(IRepository repos)
        {
            _repos = repos;
        }
        public IActionResult Index()
        {
            var startups = _repos.GetAllStartups();
            return View(startups);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
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
            if (startup.Id > 0)
            {
                _repos.UpdateStartup(startup);
            }
            else
                _repos.AddStartup(startup);
            if (await _repos.SaveChangesAsync())
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
