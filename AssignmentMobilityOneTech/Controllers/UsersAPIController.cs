using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using AssignmentMobilityOneTech.Models;

namespace AssignmentMobilityOneTech.Controllers
{
   
    public class UsersAPIController : ApiController
    {
        private Assignment_Model db = new Assignment_Model();

       
        public IQueryable<Users> GetAllUsers()
        {
            return db.Users;
        }
        public IHttpActionResult AddUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return Json(new { success = true, message = "Added Successfully", JsonRequestBehavior.AllowGet });
        }
        public IQueryable<Users> GetUserByID(int id)
        {
            return db.Users.Where(x => x.Id == id);
        }
        public IHttpActionResult UpdateUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Users dbUser = db.Users.Where(x=>x.Id == users.Id).FirstOrDefault();
            dbUser.Name = users.Name;
            dbUser.PhoneNumber = users.PhoneNumber;
            dbUser.EmailAddress = users.EmailAddress;
            dbUser.Password = users.Password;
            dbUser.LastLogin = users.LastLogin;

            string dt = users.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            DateTime oDate = DateTime.Parse(dt);

            dbUser.CreateDate = oDate;
            dbUser.Suspended = users.Suspended;

            string dtLogin = users.LastLogin.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime oDateLogin = DateTime.Parse(dtLogin);

            dbUser.LastLogin = oDateLogin;

            db.SaveChanges();

            return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
        }

        public IHttpActionResult SingleUserRemove(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Users user = db.Users.Where(b => b.Id == id).FirstOrDefault();
            db.Users.Remove(user);

            db.SaveChanges();

            return Json(new { success = true, message = "Deleted Successfully", JsonRequestBehavior.AllowGet });
        }
        //Create Method for Insert and Update

        //[HttpGet]
        //public IHttpActionResult StoreOrEdit(int id = 0)
        //{
        //    if (id == 0)
        //        return View(new Student());
        //    else
        //    {
        //        using (DBModel db = new DBModel())
        //        {


        //            return View(db.Students.Where(x => x.StudentID == id).FirstOrDefault<Student>());

        //        }
        //    }
        //}

        //[HttpPost]
        //public ActionResult StoreOrEdit(Student studentob)
        //{
        //    using (DBModel db = new DBModel())
        //    {
        //        if (studentob.StudentID == 0)
        //        {
        //            db.Students.Add(studentob);
        //            db.SaveChanges();
        //            return Json(new { success = true, message = "Saved Successfully", JsonRequestBehavior.AllowGet });
        //        }
        //        else
        //        {
        //            db.Entry(studentob).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
        //        }
        //    }

        //}

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    using (DBModel db = new DBModel())
        //    {
        //        Student emp = db.Students.Where(x => x.StudentID == id).FirstOrDefault<Student>();
        //        db.Students.Remove(emp);
        //        db.SaveChanges();
        //        return Json(new { success = true, message = "Deleted Successfully", JsonRequestBehavior.AllowGet });
        //    }
        //}
        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
       
    
        // DELETE: api/Users/5
        //[ResponseType(typeof(Users))]
        //public IHttpActionResult DeleteUsers(int id)
        //{
        //    Users users = db.Users.Find(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(users);
        //    db.SaveChanges();

        //    return Ok(users);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}