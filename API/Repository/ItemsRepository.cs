using API.Context;
using API.Repository.IRepository;
using Packages;

namespace API.Repository
{
    public class ItemsRepository : IItems
    {
        private readonly DataDbContext _db;
        public ItemsRepository(DataDbContext db)
        {
            _db = db;
        }    
        public async Task<bool> ItemsSend(Items itemsSend)
        {
            _db.items.Add(itemsSend);

            return await Save();
        }       

        public async Task<IEnumerable<Items>> ItemsSendById(int Index)
        {
            return  _db.items.Where(I => I.Index == Index).ToList();
        }

        public async Task<bool> Save()
        {
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

            }
            return false;
        }
    }
}
