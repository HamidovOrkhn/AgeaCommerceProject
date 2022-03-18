using AgeaProject.Areas.Admin.ViewModels.Auth;
using AgeaProject.Data;
using AgeaProject.Filter;
using CryptoHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly DataContext _db;
        private readonly IConfiguration _configuration;
        public AuthController(DataContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] AuthIndexViewModel req)
        {
            var username = Crypto.HashPassword(req.Username);
            var pass = Crypto.HashPassword(req.Password);
            if (!Crypto.VerifyHashedPassword(_configuration["User:Password"], req.Password) || 
                !Crypto.VerifyHashedPassword(_configuration["User:Username"], req.Username))
            {
                TempData["UserFail"] = "Undefined User";
                return RedirectToAction(nameof(Index));
            }
            HttpContext.Session.SetString("user-id", req.Username);
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
       // [Login]
        [HttpGet]
        public IActionResult Logout()
        {
            string sess = HttpContext.Session.GetString("user-id");
            if (sess is object)
            {
                HttpContext.Session.Remove("user-id");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
