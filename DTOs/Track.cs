using System;

namespace DTOs
{
    public class Track
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string SongName { get; set; }
        public DateTime WrittenAt { get; set; }
    }
}
