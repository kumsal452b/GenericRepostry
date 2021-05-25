using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelApp.DAL;
using PersonelApp.Domain;
namespace PersonelApp.Console.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonelContext context = new PersonelContext();

            UnitOfWork unitOfWork = new UnitOfWork(context);
            //unitOfWork.DepartmentRepository.Add(new Domain.Department()
            //{
            //    Name = "Dneme",
            //    CreateDate = DateTime.Now,
            //    isActive = true
            //});
            List<Personel> personels = new List<Personel>();
            personels.Add(new Personel() { Name = "Yahya", Lastname = "Alatas", DepartmentId = 1, UpdateDate = DateTime.Now });
            personels.Add(new Personel() { Name = "Kumsal", Lastname = "Alatas", DepartmentId = 1, UpdateDate = DateTime.Now });

            unitOfWork.PersonelRepository.AddRange(personels
                );
            unitOfWork.Complete();

        }
    }
}
