using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Contracts
{
    interface IRepositoryBase<T> where T : class
    {

        ICollection<T> FindAll();

        T FindById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool save();

    }
}
