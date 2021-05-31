using PersonelApp.DAL;
using PersonelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspTest.Controllers
{
    public class PersonelController : Controller
    {
        PersonelContext theContext = new PersonelContext();
        UnitOfWork theWork;
        public PersonelController()
        {
            theWork = new UnitOfWork(theContext);
        }
        public ActionResult Index()
        {
            return View(theWork.PersonelRepository.GetAll());
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            if(searchString=="" || searchString == null)
            {
                return View(theWork.PersonelRepository.GetAll());
            }
            var list = theWork.PersonelRepository.GetAllForPersonel(searchString);
            return View(list);
        }

        public ActionResult Delete(int id,string Lastname)
        {
            
            var theDeletedList = theWork.PersonelRepository.GetById(id);
            return View(theDeletedList);
        }

        [HttpPost]
        public ActionResult Delete(int id )
        {
            //theWork.PersonelRepository.Remove(id);
            //theWork.Complete();
            ViewBag.isExit = true;
            return View();
        }
    }
}