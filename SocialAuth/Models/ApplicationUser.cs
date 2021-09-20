using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAuth.Models
{
    public class ApplicationUser:IdentityUser
    {
        public bool Status { get; set; }

        public ApplicationUser()
        {
            Status = true;
        }
    }
}
