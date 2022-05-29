using Diplom.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddStartup(StartupArticle startup)
        {
            _ctx.Startups.Add(startup);
        }

        public List<StartupArticle> GetAllStartups()
        {
           return _ctx.Startups.ToList();
        }

        public StartupArticle GetStartup(int id)
        {
            return _ctx.Startups.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveStartup(int id)
        {
            StartupArticle startupArticle = GetStartup(id);
            _ctx.Startups.Remove(startupArticle);
        }

        public void UpdateStartup(StartupArticle startup)
        {
            _ctx.Startups.Update(startup);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
