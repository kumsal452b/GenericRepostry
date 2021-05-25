using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelApp.DAL.Repostories.Abstract;
using PersonelApp.Domain;
namespace PersonelApp.DAL.Repostories.Abstract
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        IEnumerable<Department> GetTopDepartmants(int counts);
        IEnumerable<Department> GetDepartmentWithPersonel();
    }
}
