using Common.Models;
using Common.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Interfaces
{
    public interface ILibraryService
    {
        Task AddLibraryAsync(LibraryAddModel library);
        Task<LibraryPageModel> GetLibrarySongsAsync(LibraryPageFilter filter);
        Task<List<PopularityRankingModel>> GetPopularityRankingsAsync();
        Task AddSongToLibraryAsync(Guid libraryId, Guid songId);
        Task RemoveSongFromLibraryAsync(Guid libraryId, Guid songId);
    }
}
