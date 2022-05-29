using Diplom.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diplom.Data.Repository
{
    public interface IRepository
    {
        StartupArticle GetStartup(int id);
        List<StartupArticle> GetAllStartups();
        void RemoveStartup(int id);
        void UpdateStartup(StartupArticle startup);
        void AddStartup(StartupArticle startup);

        Task<bool> SaveChangesAsync();
    }
}
