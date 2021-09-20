using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialAuth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
