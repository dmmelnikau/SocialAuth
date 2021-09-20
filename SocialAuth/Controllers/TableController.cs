using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAuth.Data;
using SocialAuth.Models;
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
        public async Task<IActionResult>Index(string sortOrder)
        {
            ViewBag.Active = applicationDbContext.Users.Where(p => p.Status == true);
            ViewBag.Block = applicationDbContext.Users.Where(p => p.Status == false);
            ViewData["UserNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_order";
            ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "status_order";
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
          
            var sort = from s in applicationDbContext.Users select s;
            switch (sortOrder)
            {
                case "id_desc":
                    sort = sort.OrderByDescending(s => s.Id);
                    break;
                case "status_order":
                    sort = sort.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    sort = sort.OrderByDescending(s => s.Status);
                    break;
                case "name_desc":
                    sort = sort.OrderByDescending(s => s.UserName);
                    break;
                  case "name_order":
                    sort = sort.OrderBy(s => s.UserName);
                    break;
              default:
                    sort = sort.OrderBy(s => s.Id);
                    break;
            }
            return View(await sort.AsNoTracking().ToListAsync());
        }
     
    }
}
