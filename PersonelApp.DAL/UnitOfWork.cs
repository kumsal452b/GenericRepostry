using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelApp.DAL.Repostories.Abstract;
using PersonelApp.DAL.Repostories.Concrete;

namespace PersonelApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private PersonelContext context;
        public UnitOfWork(PersonelContext context)
        {
            this.context = context;
            DepartmentRepository = new DepartmentRepository(context);
            PersonelRepository = new PersonelRepository(context);

        }
        public IDepartmentRepository DepartmentRepository { get; private set; }

        public IPersonelRepository PersonelRepository { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
