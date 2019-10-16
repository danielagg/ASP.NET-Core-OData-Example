using System;

namespace DTOs
{
    public class UserPlaylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerUserName { get; set; }
        public Track[] Tracks { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
