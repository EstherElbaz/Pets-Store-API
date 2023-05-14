using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entites
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Password { get; set; }
    

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
