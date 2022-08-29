using System;
using System.Net;
using System.Web.Mvc;
using UsersApp.Core;

namespace UsersApp.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_userRepository.GetAllUsers());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Login,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepository.Create(user);
                    TempData["AlertMessage"] = "User Created Successfully!";
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    TempData["AlertMessage"] = e.Message;
                    return View(user);
                }
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Login,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepository.Update(user);
                    TempData["AlertMessage"] = "User Updated Successfully!";
                    return RedirectToAction("Index");
                } 
                catch (Exception e)
                {
                    TempData["AlertMessage"] = e.Message;
                    return View(user);
                }
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _userRepository.GetUserById(id);
            
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _userRepository.Delete(id);
            TempData["AlertMessage"] = "User Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
