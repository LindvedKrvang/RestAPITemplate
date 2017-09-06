using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuBLL.BusinessObjects
{
    public class ProfileBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public ProfileBO()
        {
            
        }

        public string FullName => $"{FirstName} + {LastName}";
    }
}
