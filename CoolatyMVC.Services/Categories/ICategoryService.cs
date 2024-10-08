﻿using CoolatyMVC.Models;

namespace CoolatyMVC.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories(int pageNumber, int pageSize, string search);
        Task<Category> GetSingleCategory(int id);
        Task Create(Category model);
        void Update(Category model);
        void Delete(Category model);
    }
}
