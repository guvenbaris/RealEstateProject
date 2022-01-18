using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace RealEstateWebApp.DataAccess.Tools
{
    public interface IOrmRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);

    }
}
