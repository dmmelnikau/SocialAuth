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
        public async Task<IActionResult>Index(string sortOrder)
        {
            
            ViewData["UserNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_order";
            ViewData["EmailSortParm"] = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "email_order";
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            var sort = from s in applicationDbContext.Users select s;
            switch (sortOrder)
            {
                case "id_desc":
                    sort = sort.OrderByDescending(s => s.Id);
                    break;
                case "email_order":
                    sort = sort.OrderBy(s => s.Email);
                    break;
                case "email_desc":
                    sort = sort.OrderByDescending(s => s.Email);
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
