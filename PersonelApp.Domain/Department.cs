using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelApp.Domain
{
    public class Department:BaseEntity
    {
        public Department()
        {
            Personels = new List<Personel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Personel> Personels { get; set; }

    }
}
