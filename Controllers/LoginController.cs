using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.Controllers
{
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Login()
        {
            return View();
        }
        [Authorize]
        public IActionResult Register()
        {
            return View();
        }
    }
}
