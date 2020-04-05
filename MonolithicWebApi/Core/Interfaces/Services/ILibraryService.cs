using Common.Shared;
using Core.DTO;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces.Services
{
    public interface ILibraryService
    {
        Guid Add(LibraryDTO library);
        int GetSongsNumber(Guid userId);
        List<SongDTO> GetLibrarySongs(LibraryPageFilter filter);
    }
}
