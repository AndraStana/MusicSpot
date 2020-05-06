using Common.Enums;
using Common.Shared;
using Core.DTO;
using Core.Interfaces.Services;
using Grpc.Core;
using Grpc.GrpcConverters;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.ServicesImplementations
{
    public class LibraryGrpcServiceImpl : LibraryGrpcService.LibraryGrpcServiceBase
    {
        private ILibraryService _libraryService { get; set; }

        public LibraryGrpcServiceImpl(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public override Task<AddSongToLibraryResponse> AddSongToLibrary(AddSongToLibraryRequest request, ServerCallContext context)
        {

            _libraryService.AddSongToLibrary(Guid.Parse(request.LibraryId), Guid.Parse(request.SongId));

            var response = new AddSongToLibraryResponse();
            return Task.FromResult(response);
        }

        public override Task<RemoveSongFromLibraryResponse> RemoveSongFromLibrary(RemoveSongFromLibraryRequest request, ServerCallContext context)
        {
            _libraryService.RemoveSongFromLibrary(Guid.Parse(request.LibraryId), Guid.Parse(request.SongId));

            var response = new RemoveSongFromLibraryResponse();
            return Task.FromResult(response);
        }


        public override Task<AddLibraryResponse> AddLibrary(AddLibraryRequest request, ServerCallContext context)
        {

            var library = new LibraryDTO()
            {
                Id = Guid.Parse(request.Id),
                Name = request.Name
            };

            _libraryService.AddLibrary(library);

            var response = new AddLibraryResponse();
            return Task.FromResult(response);
        }

        public override Task<GetPopularityRankingResponse> GetPopularityRankings(GetPopularityRankingRequest request, ServerCallContext context)
        {
            var response = new GetPopularityRankingResponse();
            var popRanks = _libraryService.GetPopularityRankings().Select(s => new PopularityRankingMessage() { Id = s.Id.ToString(), Name = s.Name });

            response.PopularityRankings.AddRange(popRanks);
            return Task.FromResult(response);

        }

        public override Task<GetLibrarySongsResponse> GetLibrarySongs(GetLibrarySongsRequest request, ServerCallContext context)
        {

            var filter = new LibraryPageFilter()
            {
                UserId = Guid.Parse(request.UserId),
                Genre = (GenreEnum)request.Genre,
                Decade = (DecadeEnum)request.Decade,
                //PopularityRankingId = PopularityRankingId == null ? null : Guid.Parse(PopularityRankingId),
                PageIndex = request.PageIndex,
                PageSize = request.PageSize


                //          public Guid UserId { get; set; }
                //public GenreEnum? Genre { get; set; }
                //public DecadeEnum? Decade { get; set; }
                //public Guid? PopularityRankingId { get; set; }
                //public int PageIndex { get; set; }
                //public int PageSize { get; set; }
            };
            if(request.PopularityRankingId != null && request.PopularityRankingId != "")
            {
                filter.PopularityRankingId = Guid.Parse(request.PopularityRankingId);
            }

            var (totalNumber, songs ) = _libraryService.GetLibrarySongs(filter);
            var response = new GetLibrarySongsResponse()
            {
                TotalNumber = totalNumber
            };

            //if(songs != null && songs.Count != 0)
            //{
                response.Songs.AddRange(songs.Select(s => SongGrpcConverter.ToMessage(s)).ToList());

            //}
            return Task.FromResult(response);
        }
    }
}
