using Microsoft.AspNetCore.Mvc.Rendering;
using MyOwnProject.DataAccess.Data.Repository.IRepository;
using MyOwnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyOwnProject.DataAccess.Data.Repository
{
    public class FrequencyRepository : Repository.Repository<Frequency>, IFrequencyRepository
    {
        private readonly ApplicationDbContext _db;
    
        public FrequencyRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        public IEnumerable<SelectListItem> GetFrequencyListForDropDown()
        {
            return _db.Frequency.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.id.ToString()
            });
        }

        public void Update(Frequency frequency)
        {
            var obj = _db.Frequency.FirstOrDefault(s => s.id == frequency.id);
            obj.Name = frequency.Name;
            obj.FrequencyCount = frequency.FrequencyCount;

            _db.SaveChanges();
        }
    }
}
