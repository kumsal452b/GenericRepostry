using PersonelApp.DAL.Repostories.Abstract;
using PersonelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelApp.DAL.Repostories.Concrete
{
    public class DepartmentRepository :Repository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(PersonelContext context):base(context)
        {

        }

        public IEnumerable<Department> GetDepartmentWithPersonel()
        {
            return PersonelContext.Departments.Include("Personel").ToList();
        }

        public IEnumerable<Department> GetTopDepartmants(int counts)
        {
            return PersonelContext.Departments.Take(counts);
        }
        public PersonelContext PersonelContext { get { return dbContext as PersonelContext; } }
    }
}
