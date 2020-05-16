using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Services;
using Common.Shared;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonolithicWebAPI.Converters;
using MonolithicWebAPI.Models;

namespace MonolithicWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExploreController : ControllerBase
    {
        private readonly IArtistsService _artistsService;
        private readonly ILibraryService _libraryService;

        public ExploreController(IArtistsService artistsService, ILibraryService libraryService )
        {
            _artistsService = artistsService;
            _libraryService = libraryService;
        }


        [HttpPost]
        public List<ArtistModel> GetArtists([FromBody] ArtistsPageFilter filter)
        {
            var artists = _artistsService.GetArtists(filter);

            var artistsModels = artists.Select(a => ArtistWebConverter.ToModel(a)).ToList();

            SetIsInLibraryAttribute(artistsModels, filter.LibraryId);

            return artistsModels;
        }

        private void SetIsInLibraryAttribute(List<ArtistModel> artistsModels, Guid libraryId)
        {
            var songsIds = _libraryService.GetSongsIds(libraryId);

            foreach (var artist in artistsModels)
            {
                foreach (var album in artist.Albums)
                {
                    foreach (var song in album.Songs)
                    {
                        song.IsInLibrary = songsIds.Contains(song.Id);
                    }
                }
            }
        }
    }
}