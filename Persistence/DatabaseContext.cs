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

            PopulateUsers(modelBuilder);
            PopulateArtists(modelBuilder);
            PopulateAlbums(modelBuilder);
            PopulateTracks(modelBuilder);
            PopulatePlaylists(modelBuilder);
            PopulateTrackPlaylistAssignments(modelBuilder);
        }

        #region entity definitions

        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<TrackPlaylistAssignment> TrackPlaylistAssignments { get; set; }

        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime LastAccessOn { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class Artist
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class Album
        {
            public int Id { get; set; }
            public int ArtistId { get; set; }
            public virtual Artist Artist { get; set; }
            public string Name { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class Track
        {
            public int Id { get; set; }
            public int AlbumId { get; set; }
            public virtual Album Album { get; set; }
            public string Name { get; set; }
            public bool IsExplicit { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class Playlist
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int UserId { get; set; }
            public virtual User User { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public class TrackPlaylistAssignment
        {
            public int Id { get; set; }
            public int PlaylistId { get; set; }
            public virtual Playlist Playlist { get; set; }
            public int TrackId { get; set; }
            public virtual Track Track { get; set; }
            public DateTime AddedTrackToPlaylistOn { get; set; }
        }

        #endregion

        #region data seeding

        private void PopulateUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new[]
            {
               new User
               {
                   Id = 1,
                   FirstName = "Daniel",
                   LastName = "Agg",
                   CreatedOn = DateTime.Parse("2016-06-13T17:41:32.6436241Z"),
                   LastAccessOn = DateTime.Parse("2019-10-14T19:31:11.5359553Z")
               }
            });
        }

        private void PopulateArtists(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(new[]
{
               new Artist
               {
                   Id = 1,
                   Name = "Queens of the Stone Age",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z"),
               },
               new Artist
               {
                   Id = 2,
                   Name = "Led Zeppelin",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z"),
               },
               new Artist
               {
                   Id = 3,
                   Name = "Black Sabbath",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z"),
               },
               new Artist
               {
                   Id = 4,
                   Name = "Gary Clark Jr.",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z"),
               },
               new Artist
               {
                   Id = 5,
                   Name = "Them Crooked Vultures",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z"),
               },
               new Artist
               {
                   Id = 6,
                   Name = "Black Keys",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z"),
               },
               new Artist
               {
                   Id = 7,
                   Name = "Killing Joke",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z"),
               },
               new Artist
               {
                   Id = 8,
                   Name = "Black Rebel Motorcycle Club",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z"),
               }
            });
        }

        private void PopulateAlbums(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasData(new[]
            {
               new Album
               {
                   Id = 1,
                   ArtistId = 1,
                   Name = "Villains",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 2,
                   ArtistId = 1,
                   Name = "...Like Clockwork",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 3,
                   ArtistId = 2,
                   Name = "Led Zeppelin II",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 4,
                   ArtistId = 2,
                   Name = "Led Zeppelin IV",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 5,
                   ArtistId = 3,
                   Name = "Masters of Reality",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 6,
                   ArtistId = 3,
                   Name = "Paranoid",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 7,
                   ArtistId = 4,
                   Name = "This Land",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 8,
                   ArtistId = 5,
                   Name = "Them Crooked Vultures",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 9,
                   ArtistId = 6,
                   Name = "\"Let's Rock \"",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 10,
                   ArtistId = 6,
                   Name = "El Camino",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 11,
                   ArtistId = 7,
                   Name = "Laugh? I Nearly Bought One!",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 12,
                   ArtistId = 7,
                   Name = "Absolute Dissent",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 13,
                   ArtistId = 7,
                   Name = "Brighter Than A Thousand Suns",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 14,
                   ArtistId = 8,
                   Name = "Specter At The  Feast",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               },
               new Album
               {
                   Id = 15,
                   ArtistId = 8,
                   Name = "B.R.M.C.",
                   CreatedOn = DateTime.Parse("1990-01-01T12:00:00.0000000Z")
               }
            });
        }

        private void PopulateTracks(ModelBuilder modelBuilder)
        {

        }

        private void PopulatePlaylists(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>().HasData(new[]
            {
               new Playlist
               {
                   Id = 1,
                   Name = "Walk Like a Badass",
                   UserId = 1,
                   CreatedOn = DateTime.Parse("2019-10-13T18:12:32.0000000Z")
               },
               new Playlist
               {
                   Id = 2,
                   Name = "Mellow Rock",
                   UserId = 1,
                   CreatedOn = DateTime.Parse("2019-08-22T10:52:18.0000000Z")
               },
               new Playlist
               {
                   Id = 3,
                   Name = "Music to Focus",
                   UserId = 1,
                   CreatedOn = DateTime.Parse("2018-12-30T14:02:25.0000000Z")
               },
               new Playlist
               {
                   Id = 4,
                   Name = "Oldschool Goodness",
                   UserId = 1,
                   CreatedOn = DateTime.Parse("2018-10-05T08:36:10.0000000Z")
               }
            });
        }

        private void PopulateTrackPlaylistAssignments(ModelBuilder modelBuilder)
        {

        }

        #endregion
    }
}
