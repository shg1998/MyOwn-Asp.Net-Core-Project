using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyOwnProject.DataAccess.Data.Repository;
using MyOwnProject.DataAccess.Data.Repository.IRepository;
using MyOwnProject.Models;

namespace MyOwnProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FrequencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; 
        public FrequencyController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Frequency frequency = new Frequency();
            if (id == null)
            {
                return View(frequency);
            }
            frequency = _unitOfWork.frequency.Get(id.GetValueOrDefault());
            if (frequency == null)
            {
                return NotFound();
            }
            return View(frequency);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // for avoid to hacking and many many request suddenly by hacker!!
        public IActionResult Upsert(Frequency frequency)
        {
            if (ModelState.IsValid)
            {
                if (frequency.id == 0)
                {
                    _unitOfWork.frequency.Add(frequency);
                }
                else
                {
                    _unitOfWork.frequency.Update(frequency);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(frequency);

        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.frequency.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.frequency.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error While Deleting." });
            }
            _unitOfWork.frequency.Remove(obj);

            _unitOfWork.Save();
            return Json(new { success = true, message = "Successfully Deleted." });
        }
        #endregion

    }
}
