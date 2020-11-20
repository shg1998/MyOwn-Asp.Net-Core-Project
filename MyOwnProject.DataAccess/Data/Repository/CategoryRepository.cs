using Microsoft.AspNetCore.Mvc.Rendering;
using MyOwnProject.DataAccess.Data.Repository.IRepository;
using MyOwnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyOwnProject.DataAccess.Data.Repository
{
   public class CategoryRepository:Repository.Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db):base(db)
        {
            this._db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.id.ToString()
            });
        }

        public void Update(Category category)
        {
            var obj = _db.Category.FirstOrDefault(s => s.id == category.id);
            obj.Name = category.Name;
            obj.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
