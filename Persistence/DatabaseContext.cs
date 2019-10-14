using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>().HasData(new[]
            {
               new User
               {
                   Id = Guid.NewGuid(),
                   FirstName = "Daniel",
                   LastName = "Agg",
                   CreatedOn = DateTime.Parse("2016-06-13T17:41:32.6436241Z"),
                   LastAccessOn = DateTime.Parse("2019-10-14T19:31:11.5359553Z")
               }
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<TrackPlaylistAssignment> TrackPlaylistAssignments { get; set; }

        public class User
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime LastAccessOn { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class Artist
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class Album
        {
            public Guid Id { get; set; }
            public Guid ArtistId { get; set; }
            public virtual Artist Artist { get; set; }
            public string Name { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class Track
        {
            public Guid Id { get; set; }
            public Guid AlbumId { get; set; }
            public virtual Album Album { get; set; }
            public string Name { get; set; }
            public bool IsExplicit { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class Playlist
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public Guid UserId { get; set; }
            public virtual User User { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class TrackPlaylistAssignment
        {
            public Guid Id { get; set; }
            public Guid PlaylistId { get; set; }
            public virtual Playlist Playlist { get; set; }
            public Guid TrackId { get; set; }
            public virtual Track Track { get; set; }
            public DateTime AddedTrackToPlaylistOn { get; set; }
        }
    }
}
