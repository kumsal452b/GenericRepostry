﻿using PersonelApp.DAL;
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
        public ActionResult Index(string search)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var theId = id;
            return View();
        }
    }
}