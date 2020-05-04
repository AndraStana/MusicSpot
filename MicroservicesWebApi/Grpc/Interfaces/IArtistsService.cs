using Common.Models;
using Common.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Interfaces
{
    public interface IArtistsService
    {
        Task<List<ArtistModel>> GetArtistsAsync(ArtistsPageFilter filter);
    }
}
