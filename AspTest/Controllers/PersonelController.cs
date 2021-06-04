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
            getEmployeElement();
        }
        public ActionResult Index()
        {
            //getEmployeElement();
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
            //getEmployeElement();
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
            theWork.PersonelRepository.Remove(id);
            theWork.Complete();
            ViewBag.isExit = true;
            return RedirectToAction("Index","Personel");
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
        public void getEmployeElement()
        {
            var employeList = theWork.DepartmentRepository.GetAll().Select(e => (e.Id, e.Name));
            IEnumerable<SelectListItem> selectE;

            List<SelectListItem> Items = new List<SelectListItem>();
            foreach (var item in employeList)
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Value = item.Id.ToString();
                selectList.Text = item.Name;
                Items.Add(selectList);

            }
            ViewBag.emp = Items;
        }

        public ActionResult Add(int eid,string name,string lastname)
        {
            Personel personel = new Personel
            {
                Name = name,
                Lastname = lastname,
                DepartmentId = eid
            };
            theWork.PersonelRepository.Add(personel);
            theWork.Complete();
            return RedirectToAction("Index","Personel");
        }
    }
}