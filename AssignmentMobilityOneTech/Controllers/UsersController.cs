using AssignmentMobilityOneTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMobilityOneTech.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        //Create Method for Insert and Update

        [HttpGet]
        public ActionResult LoadAddPopup(int id = 0)
        {
            if (id == 0)
                return View(new Users());
            else
            {
                //using (DBModel db = new DBModel())
                //{


                //    return View(db.Students.Where(x => x.StudentID == id).FirstOrDefault<Student>());

                //}
                return View();

            }
        }
        [HttpGet]
        public ActionResult LoadEditPopup(int id = 0)
        {
            if (id == 0)
                return View(new Users());
            else
            {
                //using (DBModel db = new DBModel())
                //{


                //    return View(db.Students.Where(x => x.StudentID == id).FirstOrDefault<Student>());

                //}
                return View();

            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
