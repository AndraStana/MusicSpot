using Common.Shared;
using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Libmongocrypt;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library = Persistence.DAL.Library;

namespace Core.Services
{
    public class ArtistsService: IArtistsService
    {
        private readonly IMongoCollection<Library> libraryDbList;
        private readonly IMongoCollection<PopularityRanking> popularityRankingsDbList;
        private readonly IMongoCollection<Artist> artistsDbList;
        private readonly IMongoCollection<Song> songsDbList;
        private readonly IMongoCollection<User> usersDbList;


        public ArtistsService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:DefaultConnection"]);

            IMongoDatabase database = client.GetDatabase("MusicSpotMusic");
            libraryDbList = database.GetCollection<Library>("Libraries");
            artistsDbList = database.GetCollection<Artist>("Artists");
            songsDbList = database.GetCollection<Song>("Songs");
            usersDbList = database.GetCollection<User>("Users");
        }

        public List<ArtistDTO> GetArtists(ArtistsPageFilter filter)
        {
            //var filterArtists = Builders<Artist>.Filter.ElemMatch(x => x.Name, Builders<Album>.Filter.AnyIn(x => x.SongsIds, songsIds));
            //var filterArtists = Builders<Artist>.Filter.Regex(x => x.Name,".*"+ filter.SearchText+ ".*");

            var filterArtists = Builders<Artist>.Filter.Regex(x => x.Name, new BsonRegularExpression($".*{filter.SearchText}.*"));


            var userLibSongIds = libraryDbList.Find(l => l.Id == filter.LibraryId).FirstOrDefault().SongsIds;

            var artists = artistsDbList.Find(filterArtists).Skip(filter.PageIndex * filter.PageSize)
                .Limit(filter.PageSize).ToList();

            var allSongsIds = artists.SelectMany(a => a.Albums.SelectMany(aa => aa.SongsIds));


            var songsFilter = Builders<Song>.Filter.In(x => x.Id , allSongsIds);
            var songs = songsDbList.Find(songsFilter).ToList();

            var artistsDTOs = new List<ArtistDTO>();
            foreach( var artist in artists)
            {
                var artistDTO = new ArtistDTO();

                artistDTO.Id = artistDTO.Id;
                artistDTO.Name = artist.Name;
                artistDTO.UrlPicture = artist.UrlPicture;
                artistDTO.Albums = new List<AlbumDTO>();

                foreach( var album in artist.Albums)
                {
                    var albumDTO = new AlbumDTO();
                    albumDTO.Id = album.Id;
                    albumDTO.Name = album.Name;
                    albumDTO.UrlPicture = album.UrlPicture;
                    albumDTO.Songs = new List<SongSimpleDTO>();

                    foreach( var songId in album.SongsIds)
                    {
                        var song = songs.FirstOrDefault(s => s.Id == songId);
                        var songDTO = new SongSimpleDTO()
                        {
                            Id = song.Id,
                            Name = song.Name,
                            Url = song.Url,
                            IsInLibrary = userLibSongIds.Contains(song.Id)
                        };
                        albumDTO.Songs.Add(songDTO);
                    }
                    artistDTO.Albums.Add(albumDTO);
                }
                artistsDTOs.Add(artistDTO);
            }
            return artistsDTOs;
        }
    }
}
