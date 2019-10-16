using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IPlaylistService
    {
        Task<UserPlaylist[]> GetPlaylistsOfUser(int userId);
    }
}
