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
            var employeList = theWork.DepartmentRepository.GetAll().Select(e => e.Name);
            IEnumerable<SelectListItem> selectE;
            SelectListItem selectList = new SelectListItem();
            List<SelectListItem> Items = new List<SelectListItem>();
            foreach (var item in employeList)
            {
                selectList.Value = item;
            }
            Items.Add(selectList);
            ViewBag.emp = Items;
            return View(theWork.PersonelRepository.GetAll());
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            if (searchString == "" || searchString == null)
            {
                return View(theWork.PersonelRepository.GetAll());
            }
            var list = theWork.PersonelRepository.GetAllForPersonel(searchString);
            return View(list);
        }

        public ActionResult Delete(int id, string Lastname)
        {

            var theDeletedList = theWork.PersonelRepository.GetById(id);
            return View(theDeletedList);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //theWork.PersonelRepository.Remove(id);
            //theWork.Complete();
            ViewBag.isExit = true;
            return RedirectToRoute("/Index");
        }
        public ActionResult Edit(int id)
        {
            Personel thePersonel = theWork.PersonelRepository.GetById(id);
            ViewBag.Name = thePersonel.Name;
            ViewBag.Lastname = thePersonel.Lastname;
            ViewBag.id = thePersonel.Id;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, string name, string lastname)
        {
            Personel thePersonel = new Personel
            {
                Id = id,
                Lastname = lastname,
                Name = name,
                UpdateDate = DateTime.Now
            };
            theWork.PersonelRepository.Update(thePersonel);
            theWork.Complete();
            return View();
        }
    }
}