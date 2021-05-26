using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelApp.DAL;
using PersonelApp.Domain;

namespace PersonelApp.Web.UI.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        PersonelContext theContext = new PersonelContext();
        UnitOfWork theWork;
        public PersonelController()
        {
            theWork = new UnitOfWork(theContext);
        }
        public ActionResult Index()
        {
            IEnumerable<Personel> theListOfPersonel = theWork.PersonelRepository.GetAll();
            return View(theListOfPersonel);
        }
        public ActionResult Delete()
        {

            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}