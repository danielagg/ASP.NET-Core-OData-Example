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
            var result = await dbContext.Playlists
                .Where(p => p.UserId == userId)
                .Select(p => new UserPlaylist
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedOn = p.CreatedOn,
                    ModifiedOn = p.ModifiedOn,
                    OwnerUserName = $"{p.User.FirstName} {p.User.LastName}"
                })
                .ToArrayAsync();

            return result;
        }
    }
}
