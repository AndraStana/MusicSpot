﻿using Common.Shared;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Services
{
    public interface ILibraryService
    {
        void AddLibrary(LibraryDTO libraryDTO);
        (int, List<SongDTO>) GetLibrarySongs(LibraryPageFilter filter);
        List<PopularityRankingDTO> GetPopularityRankings();
        void RemoveSongFromLibrary(Guid libraryId, Guid songId);
        void AddSongToLibrary(Guid libraryId, Guid songId);
        List<SongDTO> GetRecommendedSongs(BasicPageFilter filter);
    }
}
