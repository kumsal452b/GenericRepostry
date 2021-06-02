using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelApp.DAL.Repostories.Abstract;
using PersonelApp.Domain;

namespace PersonelApp.DAL.Repostories.Concrete
{
    public class PersonelRepository : Repository<Personel>,IPersonelRepository
    {
        public PersonelRepository(PersonelContext context) :base(context)
        {

        }

        public IEnumerable<Personel> GetPersonelWithDepartment()
        {
            return PersonelContext.Personels.Include("Departments").ToList();
        }

        public IEnumerable<Personel> GetAllForPersonel(string key)
        {
           return PersonelContext.Personels.Where<Personel>(e => e.Lastname.Contains(key) || e.Name.Contains(key));
        }

        public Personel Update(Personel personel)
        {

           Personel thePersonel=PersonelContext.Personels.FirstOrDefault(e => e.Id == personel.Id);
            if (thePersonel != null && personel!=null)
            {
                thePersonel.Lastname = personel.Lastname;
                thePersonel.Name = personel.Name;
                return thePersonel;
            }
            return thePersonel;
        }

        public PersonelContext PersonelContext { get { return dbContext as PersonelContext; }}
    }
}
