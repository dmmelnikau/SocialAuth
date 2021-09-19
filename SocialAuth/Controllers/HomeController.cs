using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialAuth.Data;
using SocialAuth.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAuth.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDb)
        {
            _logger = logger;
            applicationDbContext = applicationDb;
        }
        public IActionResult Index()
        {

            int a = applicationDbContext.UserLogins.Where(p => p.LoginProvider == "Google").Count();
            int b = applicationDbContext.UserLogins.Where(p => p.LoginProvider == "Microsoft").Count();
            int c = applicationDbContext.UserLogins.Where(p => p.LoginProvider == "Github").Count();
            ViewBag.Google = a;
            ViewBag.Microsoft = b;
            ViewBag.Github = c;
         
            return View();
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
