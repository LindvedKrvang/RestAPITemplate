using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VideoMenuBLL.BusinessObjects
{
    public class UserBO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ProfileBO Profile { get; set; }
        public List<RentalBO> Rentals { get; set; }
    }
}
