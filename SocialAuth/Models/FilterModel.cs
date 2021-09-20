using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAuth.Models
{
    public class FilterModel
    {
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public SelectList Statuss { get; set; }
    }
}
