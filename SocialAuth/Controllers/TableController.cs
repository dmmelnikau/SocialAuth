using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAuth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SocialAuth.Controllers
{
    [Authorize]
    public class TableController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        public TableController(ApplicationDbContext applicationDb)
        {
            applicationDbContext = applicationDb;
        }
        public async Task<IActionResult>Index()
        {
            return View(await applicationDbContext.Users.ToListAsync());
        }
    }
}
