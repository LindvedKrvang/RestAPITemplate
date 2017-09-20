using System;
using System.Collections.Generic;

namespace VideoMenuBLL.BusinessObjects
{
    public class VideoBO : IComparable<VideoBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public GenreBO Genre { get; set; }
        public List<RentalBO> Rentals { get; set; }

        public VideoBO()
        {
            
        }

        public int CompareTo(VideoBO other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var idComparison = Id.CompareTo(other.Id);
            if (idComparison != 0) return idComparison;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
