using Common.Models;
using Common.Shared;
using Grpc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExploreController : ControllerBase
    {
        private readonly IArtistsService _artistsService;
        private readonly ILibraryService _libraryService;

        public ExploreController(IArtistsService artistsService, ILibraryService libraryService)
        {
            _artistsService = artistsService;
            _libraryService = libraryService;
        }


        [HttpPost]
        public List<ArtistModel> GetArtists([FromBody] ArtistsPageFilter filter)
        {
            //var artists = _artistsService.GetArtists(filter);

            //var artistsModels = artists.Select(a => ArtistWebConverter.ToModel(a)).ToList();



            var artists = _artistsService.GetArtistsAsync(filter);

            //SetIsInLibraryAttribute(artistsModels, filter.LibraryId);

            return artists.Result;
        }

        //private void SetIsInLibraryAttribute(List<ArtistModel> artistsModels, Guid libraryId)
        //{
        //    var songsIds = _libraryService.GetSongsIds(libraryId);

        //    foreach (var artist in artistsModels)
        //    {
        //        foreach (var album in artist.Albums)
        //        {
        //            foreach (var song in album.Songs)
        //            {
        //                song.IsInLibrary = songsIds.Contains(song.Id);
        //            }
        //        }
        //    }
        //}
    }
}