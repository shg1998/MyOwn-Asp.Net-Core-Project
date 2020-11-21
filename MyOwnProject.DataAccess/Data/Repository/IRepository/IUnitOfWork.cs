using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnProject.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository category { get; }

        IFrequencyRepository frequency { get; }

        void Save();
    }
}
