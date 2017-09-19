using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuDAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
