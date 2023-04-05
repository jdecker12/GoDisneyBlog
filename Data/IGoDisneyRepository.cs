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
        Task<IEnumerable<Card>> GetCard();
        Task<Card> GetCardById(int id);
        Task<bool> SaveAllAsync();
        void AddEntity(object model);
        void DeleteEntity(object model);
        Task<Card> GetCardByName(string name);
        Task<IEnumerable<Card>> GetCardsByCat(string cat);
        Task<IEnumerable<Card>> GetCardsLinkData(string cat);
    }
}
