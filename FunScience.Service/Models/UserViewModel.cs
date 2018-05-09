using System;
using System.Collections.Generic;
using System.Text;

namespace FunScience.Service.Models
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Description { get; set; }
        
        public string Profession { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}
