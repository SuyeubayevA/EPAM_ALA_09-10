using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ALA_07_MVC_try3.Models;

namespace ALA_07_MVC_try3.Models
{
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<ALA_07_MVC_try3.Models.User> User { get; set; }
        public DbSet<ALA_07_MVC_try3.Models.Award> Award { get; set; }
        public DbSet<ALA_07_MVC_try3.Models.Role> Role { get; set; }
    }
}
