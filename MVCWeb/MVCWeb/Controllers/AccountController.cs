using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using MVCWeb.Models;
using MVCWeb.Data;

namespace MVCWeb.Controllers
{

    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
       
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        //Register get and post

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(MVCWebEntity user)
        {
            if (ModelState.IsValid)
            {
                _db.MVCWeb.Add(user);
                _db.SaveChanges(true);
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            
            return View(user);
        }
        //Login get and post
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            
            if (ModelState.IsValid)
            {
                var Loggedinuser = _db.MVCWeb.Single(u => u.Email == email && u.Password == password);
                if (Loggedinuser != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
               
                
            }
            return View();
        }

        //logout 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
          
            return RedirectToAction("Index", "Home");
        }
    }
 }