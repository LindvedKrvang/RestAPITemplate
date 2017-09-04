using System;

namespace VideoMenuDAL.Entities
{
    public class Video : IComparable<Video>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EGenre Genre { get; set; }

        public Video()
        {
            
        }

        public int CompareTo(Video other)
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
