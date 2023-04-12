using GoDisneyBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDisneyBlog.Data
{
    public interface IGoDisneyRepository
    {
        Task<IEnumerable<ICard>> GetCard();
        Task<ICard> GetCardById(int id);
        Task<bool> SaveAllAsync();
        void AddEntity(object model);
        void DeleteEntity(object model);
        Task<ICard> GetCardByName(string name);
        Task<IEnumerable<ICard>> GetCardsByCat(string cat);
        Task<IEnumerable<ICard>> GetCardsLinkData(string cat);
    }
}
