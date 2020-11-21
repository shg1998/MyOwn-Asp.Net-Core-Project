using Microsoft.AspNetCore.Mvc.Rendering;
using MyOwnProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnProject.DataAccess.Data.Repository.IRepository
{
   public interface IFrequencyRepository:IRepository.IRepository<Frequency>
    {
        IEnumerable<SelectListItem> GetFrequencyListForDropDown();

        void Update(Frequency frequency);
    }
}
