using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_operations.Models;
using System.Diagnostics;

namespace MVC_CRUD_operations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;
        public HomeController(ILogger<HomeController> logger, UserContext _context)
        {
            _logger = logger;
            this._context = _context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.UserList = _context.Users.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteUser(int ID)
        {
            var Deleted_User = await _context.Users.FindAsync(ID);
            _context.Remove(Deleted_User);
            await _context.SaveChangesAsync();  

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UpdateUser(int ID)
        {
            var UpdatedUser = _context.Users.Find(ID);
            return View(UpdatedUser);
        }

        [HttpPost]
        public IActionResult UpdateUser(Users user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
         }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}