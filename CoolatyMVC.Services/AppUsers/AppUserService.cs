using CoolatyMVC.Models;
using CoolatyMVC.Data.Repository;

namespace CoolatyMVC.Services.AppUsers
{
    public class AppUserService : IAppUserService
    {
        #region Fields
        private readonly Repository _repo;
        #endregion

        #region Constructor
        public AppUserService(Repository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<AppUser>> GetAllUsers(int pageNumber, int pageSize, string search)
        {
            return await _repo.AppUser.GetAllUsers(pageNumber, pageSize, search);
        }

        public async Task<AppUser> GetUserInfo(string userId)
        {
            return await _repo.AppUser.GetUserInfo(userId);
        }

        public void UpdateUserInfo(AppUser model)
        {
            _repo.AppUser.UpdateUserInfo(model);
        }

        public void DeleteUser(AppUser model)
        {
            _repo.AppUser.DeleteUser(model);
        }
        #endregion
    }
}
