using CoolatyMVC.Models;

namespace CoolatyMVC.Data.Repository.AppUsers
{
    public interface IAppUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers(int pageNumber, int pageSize, string search);
        Task<AppUser> GetUserInfo(string userId);
        void UpdateUserInfo(AppUser model);
        void DeleteUser(AppUser model);
    }
}
