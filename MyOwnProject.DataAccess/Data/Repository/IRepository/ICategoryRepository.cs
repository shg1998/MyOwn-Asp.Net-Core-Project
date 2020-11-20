using Microsoft.AspNetCore.Mvc.Rendering;
using MyOwnProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnProject.DataAccess.Data.Repository.IRepository
{
   public interface ICategoryRepository:IRepository.IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Category category);
    }
}
