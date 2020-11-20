using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyOwnProject.DataAccess.Data.Repository.IRepository;
using MyOwnProject.Models;

namespace MyOwnProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id==null)
            {
                return View(category);
            }
            category = _unitOfWork.category.Get(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        #region API Calls


        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.category.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.category.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error While Deleting." });
            }
            _unitOfWork.category.Remove(obj);

            _unitOfWork.Save();
            return Json(new { success = true, message = "Successfully Deleted." });
        }
        #endregion
    }
}
