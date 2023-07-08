using CoolatyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolatyMVC.Data.Repository.AppUsers
{
    public class AppUserRepository : IAppUserRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Construstor
        public AppUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<AppUser>> GetAllUsers(int pageNumber, int pageSize, string search)
        {
            var result = _db.AppUsers.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(category => category.Name.Contains(search));
            }

            result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await Task.FromResult(result);
        }

        public async Task<AppUser> GetUserInfo(string userId)
        {
            return await _db.AppUsers.FirstOrDefaultAsync(c => c.Id == userId);
        }

        public void UpdateUserInfo(AppUser model)
        {
            _db.AppUsers.Update(model);
        }

        public void DeleteUser(AppUser model)
        {
            _db.AppUsers.Remove(model);
        }
        #endregion
    }
}
