using AppData.Models;

namespace AppView.Services
{
    public interface IAPIService 
    {
        Task<List<Userr>> GetUserrs();
        Task<Userr> AddUser(Userr userr);
        Task<Userr> UpdateUser(Userr userr);
        Task<bool> DeleteUser(Guid id);
        Task<Userr> GetSingleUser(Guid id);
    }
}
