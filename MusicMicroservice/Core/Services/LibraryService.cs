using Common.Shared;
using Core.CoreConverters;
using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Persistence.DAL;
using System;
using System.Linq;

using System.Collections.Generic;
using Common.Enums;
using MongoDB.Bson;

namespace Core.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IMongoCollection<Library> libraryDbList;
        private readonly IMongoCollection<PopularityRanking> popularityRankingsDbList;
        private readonly IMongoCollection<Artist> artistsDbList;
        private readonly IMongoCollection<Song> songsDbList;
        private readonly IMongoCollection<User> usersDbList;

        public LibraryService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:DefaultConnection"]);

            IMongoDatabase database = client.GetDatabase("MusicSpotMusic");
            libraryDbList = database.GetCollection<Library>("Libraries");
            artistsDbList = database.GetCollection<Artist>("Artists");
            songsDbList = database.GetCollection<Song>("Songs");
            usersDbList = database.GetCollection<User>("Users");

            popularityRankingsDbList = database.GetCollection<PopularityRanking>("PopularityRankings");

        }

        public void AddLibrary(LibraryDTO libraryDTO)
        {
            var library = LibraryCoreConverter.ToDAL(libraryDTO);
            library.SongsIds = new List<Guid>();
            libraryDbList.InsertOne(library);
        }

        public void RemoveSongFromLibrary(Guid libraryId, Guid songId)
        {
            //var library = libraryDbList.Find(l => l.Id == libraryId).First();
            //library.SongsIds.Add(songId);

            var filterLib = Builders<Library>.Filter.Eq(x => x.Id, libraryId);


            var update = Builders<Library>.Update.Pull("SongsIds", songId);

            libraryDbList.UpdateOne(filterLib, update);
        }

        public void AddSongToLibrary(Guid libraryId, Guid songId)
        {
            var filterLib = Builders<Library>.Filter.Eq(x => x.Id, libraryId);

            var update = Builders<Library>.Update.AddToSet("SongsIds", songId);

            libraryDbList.UpdateOne(filterLib, update);
        }



        public List<SongDTO> GetRecommendedSongs(BasicPageFilter filter)
        {
            var queryableUsers = usersDbList.AsQueryable();


            var library = from lib in libraryDbList.AsQueryable()
                          join u in queryableUsers on lib.Id equals u.LibraryId
                          where u.Id == filter.UserId
                          select lib.SongsIds;


            var allSongsIds = library.FirstOrDefault();
            if (allSongsIds == null)
            {
                new List<SongDTO>();
            }

            var filterArtists = Builders<Artist>.Filter.ElemMatch(x => x.Albums, Builders<Album>.Filter.AnyIn(x => x.SongsIds, allSongsIds));
            var userLibArtistsIds = artistsDbList.Find(filterArtists).ToList().Select(a=>a.Id);


            var recommendedArtistsFilter = Builders<Artist>.Filter.In(a => a.Id, userLibArtistsIds);
            var recommendedArtists = artistsDbList.Find(filterArtists).ToList();

            var recommendedSongs = recommendedArtists.SelectMany(
                artist => artist.Albums.SelectMany(album => album.SongsIds.Select
                 (s => new SongDTO()
                 {
                     Id = s,
                     Artist = artist.Name,
                     Album = album.Name,
                     AlbumUrlPicture = album.UrlPicture,
                     IsInLibrary = false
                 })
                 .OrderBy(s => s.Name)))
                .Skip(filter.PageIndex * filter.PageSize)
                 .Take(filter.PageSize).ToList();

            var recSongIds = recommendedSongs.Select(s => s.Id).ToList();

            var recSongsFilter = Builders<Song>.Filter.In(a => a.Id, recSongIds);
            var recSongsFromDb = songsDbList.Find(recSongsFilter).ToList();


            foreach(var recSong in recommendedSongs)
            {
                recSong.Name = recSongsFromDb.Find(s => s.Id == recSong.Id).Name;
                recSong.Url = recSongsFromDb.Find(s => s.Id == recSong.Id).Url;
                recSong.Year = recSongsFromDb.Find(s => s.Id == recSong.Id).Year;


            }

            return recommendedSongs.ToList();
        }


        public (int, List<SongDTO>) GetLibrarySongs(LibraryPageFilter filter)
        {
            var queryableUsers = usersDbList.AsQueryable();


            var library = from lib in libraryDbList.AsQueryable()
                          join u in queryableUsers on lib.Id equals u.LibraryId
                          where u.Id == filter.UserId
                          select lib.SongsIds;

            var allSongsIds = library.FirstOrDefault();

            if( allSongsIds == null)
            {
                return (0, new List<SongDTO>());

            }

            var query = from song in songsDbList.AsQueryable()
                        where allSongsIds.Contains(song.Id)
                                       && (song.Genre == filter.Genre || filter.Genre == null || filter.Genre == 0)
                                       && (song.PopularityRankingId == filter.PopularityRankingId || filter.PopularityRankingId == null)
                        orderby (song.Name)
                        select new SongDTO { Id = song.Id,
                            Name = song.Name,
                            Year = song.Year,
                            Url = song.Url
                        };

            int totalNumber = query.ToList().Where(song => IsYearInDecade(song.Year, filter.Decade)).ToList().Count;

            var songsDTOList = query.ToList().Where(song => IsYearInDecade(song.Year, filter.Decade)).Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).ToList();
            var songsIds = songsDTOList.Select(l => l.Id).ToList();


            var filterArtists = Builders<Artist>.Filter.ElemMatch(x => x.Albums, Builders<Album>.Filter.AnyIn(x => x.SongsIds, songsIds));
            var artists = artistsDbList.Find(filterArtists).ToList();

            foreach (var artist in artists)
            {
                foreach (var album in artist.Albums)
                {
                    var songsDTO = songsDTOList.Where(s => album.SongsIds.Contains(s.Id));

                    if (songsDTO != null)
                    {
                        foreach(var songDTO in songsDTO)
                        {
                            songDTO.Artist = artist.Name;
                            songDTO.Album = album.Name;
                            songDTO.AlbumUrlPicture = album.UrlPicture;
                            songDTO.Artist = artist.Name;
                            songDTO.IsInLibrary = true;
                        }
                    }
                }
            }
            return (totalNumber, songsDTOList);
        }

        public List<PopularityRankingDTO> GetPopularityRankings()
        {

            return popularityRankingsDbList.Find(a => true).ToList().Select(a => PopularityRankingCoreConverter.ToDTO(a)).ToList();
        }

        private bool IsYearInDecade(int year, DecadeEnum? decade)
        {
            if (decade == null || decade ==0)
            {
                return true;
            }

            switch (decade)
            {
                case DecadeEnum.D2010_2020:
                    {
                        if (2010 <= year && year < 2020)
                        {
                            return true;
                        }
                        return false;
                    }
                case DecadeEnum.D2000_2010:
                    {
                        if (2000 <= year && year < 2010)
                        {
                            return true;
                        }
                        return false;
                    }
                case DecadeEnum.D1990_2000:
                    {
                        if (1990 <= year && year < 2000)
                        {
                            return true;
                        }
                        return false;
                    }

                case DecadeEnum.D1980_1990:
                    {
                        if (1980 <= year && year < 1990)
                        {
                            return true;
                        }
                        return false;
                    }
                case DecadeEnum.D1970_1980:
                    {
                        if (1970 <= year && year < 1980)
                        {
                            return true;
                        }
                        return false;
                    }
                case DecadeEnum.D1960_1970:
                    {
                        if (1960 <= year && year < 1970)
                        {
                            return true;
                        }
                        return false;
                    }
                case DecadeEnum.D1950_1960:
                    {
                        if (1950 <= year && year < 1960)
                        {
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }
    }
}
