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
        (int, List<SongDTO>) GetLibrarySongs(LibraryPageFilter filter);
        List<PopularityRankingDTO> GetPopularityRankings();
        List<SongDTO> GetRecommendedSongs(BasicPageFilter filter);
        void RemoveSongFromLibrary(Guid songId, Guid libraryId);
        void AddSongToLibrary(Guid songId, Guid libraryId);
        List<Guid> GetSongsIds(Guid libraryId);
    }
}
