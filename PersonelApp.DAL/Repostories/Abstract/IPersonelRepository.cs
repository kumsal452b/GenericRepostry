using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelApp.Domain;

namespace PersonelApp.DAL.Repostories.Abstract
{
    public interface IPersonelRepository:IRepository<Personel>
    {
        IEnumerable<Personel> GetPersonelWithDepartment();
        IEnumerable<Personel> GetAllForPersonel(string key);
        Personel Update(Personel personel);

    }
}
