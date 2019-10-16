using DTOs;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly DatabaseContext dbContext;

        public PlaylistService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<UserPlaylist[]> GetPlaylistsOfUser(int userId)
        {
            var result = await dbContext.TrackPlaylistAssignments
                .Where(tpa => tpa.Playlist.UserId == userId)
                .Select(tpa => new
                {
                    tpa.Playlist.Id,
                    tpa.Playlist.Name,
                    tpa.Playlist.CreatedOn,
                    tpa.Playlist.ModifiedOn,
                    OwnerUserName = $"{tpa.Playlist.User.FirstName} {tpa.Playlist.User.LastName}",
                    TrackInfo = new
                    {
                        tpa.Track.Id,
                        Title = tpa.Track.Name,
                        WrittenAt = tpa.Track.CreatedOn,
                        Artist = tpa.Track.Album.Artist.Name
                    }
                })
                .GroupBy(
                    k => new { k.Id, k.Name, k.CreatedOn, k.ModifiedOn, k.OwnerUserName },
                    v => v.TrackInfo,
                    (k, v) => new
                    {
                        PlaylistInfo = k,
                        Tracks = v
                    })
                .Select(r => new UserPlaylist
                {
                    Id = r.PlaylistInfo.Id,
                    Name = r.PlaylistInfo.Name,
                    CreatedOn = r.PlaylistInfo.CreatedOn,
                    ModifiedOn = r.PlaylistInfo.ModifiedOn,
                    OwnerUserName = r.PlaylistInfo.OwnerUserName,
                    Tracks = r.Tracks.Select(t => new Track
                    {
                        Id = t.Id,
                        SongName = t.Title,
                        ArtistName = t.Artist,
                        WrittenAt = t.WrittenAt
                    }).ToArray()
                })
                .ToArrayAsync();

            return result;
        }
    }
}
