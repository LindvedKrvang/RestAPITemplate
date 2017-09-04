using System;

namespace VideoMenuBLL.BusinessObjects
{
    public class VideoBO : IComparable<VideoBO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EGenreBO Genre { get; set; }

        public VideoBO()
        {
            
        }

        public int CompareTo(VideoBO other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var idComparison = Id.CompareTo(other.Id);
            if (idComparison != 0) return idComparison;
            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            return Genre.CompareTo(other.Genre);
        }
    }
}
