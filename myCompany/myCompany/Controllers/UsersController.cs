using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myCompany.Data;
using myCompany.Models;

namespace myCompany.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(databaseContext db) {
            _db = db;
        }
        private readonly databaseContext _db;
        public IActionResult Index()
        {
            IEnumerable<User> usersList = _db.Users.Where(x=>x.IsActive==true).ToList();
            return View(usersList);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(User user)
        {
            if (ModelState.IsValid)
            {
                user.ID = 0;
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
        public IActionResult Edit(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var user = _db.Users.Find(ID);
            if (user == null) 
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
        public IActionResult Delete(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var user = _db.Users.Find(ID);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive = false;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult Delete(int? ID)
        //{
        //    if (ID == null || ID == 0)
        //    {
        //        return NotFound();
        //    }
        //    var user = _db.Users.Find(ID);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(User user)
        //{
        //    user.IsActive = false;
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
