using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuDAL.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int VideoId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Video Video { get; set; }
    }
}
