using Microsoft.AspNetCore.Mvc;
using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
namespace CRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<User> objUserList = _db.Users.ToList();
            return View(objUserList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User obj)
        {
			if (ModelState.IsValid)
			{
				_db.Users.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "User added successfully";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Edit(int ?Id)
		{
			if(Id == 0||Id==null) {
				return NotFound();
			}
			User? User = _db.Users.Find(Id);
			if (User == null)
			{
				return NotFound();
			}
			return View(User);
		}
		[HttpPost]
		public IActionResult Edit(User obj)
		{
			if (ModelState.IsValid)
			{
				_db.Users.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "User updated successfully";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int? Id)
		{
			if (Id == 0 || Id == null)
			{
				return NotFound();
			}
			User? User = _db.Users.Find(Id);
			if (User == null)
			{
				return NotFound();
			}
			return View(User);
		}
		[HttpPost,ActionName("Delete")]
		public IActionResult DeleteP(int?Id)
		{
			User? obj = _db.Users.Find(Id);
			if(obj == null)
			{
				return NotFound();
			}
			_db.Users.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "User deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
