using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALA_07_MVC_try3.Models
{
    public class UserDetailsViewModel
    {
        public User User { get; set; }
        public List<Award> Awards { get; set; }

        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
