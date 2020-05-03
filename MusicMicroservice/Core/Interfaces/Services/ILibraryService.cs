using Common.Shared;
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
    }
}
