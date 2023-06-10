using CoolatyMVC.Models;

namespace CoolatyMVC.Services.AppUsers
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUser>> GetAllUsers(int pageNumber, int pageSize, string search);
        Task<AppUser> GetUserInfo(string userId);
        void UpdateUserInfo(AppUser model);
        void DeleteUser(AppUser model);
    }
}
