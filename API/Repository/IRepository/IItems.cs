using Packages;

namespace API.Repository.IRepository
{
    public interface IItems
    {
        Task<bool> ItemsSend(Items itemsSend);
        Task<IEnumerable<Items>> ItemsSendById(int Id);
    }
}
