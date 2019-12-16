using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALA_07_MVC_try3.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual User MyUser { get; set; }
    }
}
