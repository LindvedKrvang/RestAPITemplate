using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuBLL.BusinessObjects
{
    public class RentalBO
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int VideoId { get; set; }
        public int UserId { get; set; }

        public UserBO User { get; set; }
        public VideoBO Video { get; set; }
    }
}
