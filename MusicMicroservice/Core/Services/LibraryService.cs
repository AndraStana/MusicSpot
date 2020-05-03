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
    public class LibraryService:  ILibraryService
    {
        private readonly IMongoCollection<Library> libraryDbList;
        private readonly IMongoCollection<PopularityRanking> popularityRankingsDbList;
        private readonly IMongoCollection<Artist> artistsDbList;
        private readonly IMongoCollection<Song> songsDbList;
        private readonly IMongoCollection<User> usersDbList;

        private readonly IMongoCollection<Object> artists2DbList;






        public LibraryService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:DefaultConnection"]);

            IMongoDatabase database = client.GetDatabase("MusicSpotMusic");
            libraryDbList = database.GetCollection<Library>("Libraries");
            artistsDbList = database.GetCollection<Artist>("Artists");
            songsDbList = database.GetCollection<Song>("Songs");
            usersDbList = database.GetCollection<User>("Users");


            popularityRankingsDbList = database.GetCollection<PopularityRanking>("PopularityRankings");



            IMongoDatabase database222 = client.GetDatabase("testdb");
            artists2DbList = database222.GetCollection<Object>("Artists2");

        }


        public void AddLibrary(LibraryDTO libraryDTO)
        {
            var library = LibraryCoreConverter.ToDAL(libraryDTO);
            library.SongsIds = new List<Guid>();
            libraryDbList.InsertOne(library);
        }

        public  (int, List<SongDTO>) GetLibrarySongs(LibraryPageFilter filter)
        {
            var queryableUsers = usersDbList.AsQueryable();

           
            var lib1 = libraryDbList.AsQueryable().ToList();
            var userss = usersDbList.AsQueryable().ToList();


            var library = from lib in libraryDbList.AsQueryable()
                          join u in queryableUsers on lib.Id equals u.LibraryId
                          select lib.SongsIds;



            var allSongsIds = library.FirstOrDefault();

            //var totalNumber = allSongsIds.Count;


            var query = from song in songsDbList.AsQueryable()
            where allSongsIds.Contains(song.Id)
                           && (song.Genre == filter.Genre || filter.Genre == null)
                                       && (song.PopularityRankingId == filter.PopularityRankingId || filter.PopularityRankingId == null)
                                       && (song.Genre == filter.Genre || filter.Genre == null)
                           orderby (song.Name)
                           
                           select new SongDTO{ Id = song.Id,
                              Name = song.Name,
                              Year = song.Year,
                              Url = song.Url,
                              IsInLibrary = true
                          };




            int totalNumber = query.ToList().Where(song => IsYearInDecade(song.Year, filter.Decade)).ToList().Count;

            var songsDTOList = query.ToList().Where(song => IsYearInDecade(song.Year, filter.Decade)).Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).ToList();



            //var songsDTOList = songsDto.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).ToList();

            var songsIds = songsDTOList.Select(l => l.Id).ToList();

            //var queryableArtist = artistsDbList.AsQueryable();




            //var artists = artistsDbList.Find(a => a.Albums.SelectMany(a => a.SongsIds).Where(s => songsIds.Contains(s)) != null).ToList();



            //var artists = artistsDbList.Find(Builders<Artist>.Filter.ElemMatch(Builders<UserModel>.Filter.ElemMatch(u => applications, a => a.category == "Tech")))



            //var artists = artistsDbList.Find(Builders<Artist>.Filter.ElemMatch(u => u.Albums, a => a.SongsIds.Intersect(songsIds).Any())).ToList();

            //var artists = artistsDbList.Find(Builders<Artist>.Filter.ElemMatch(u => u.Albums, Query.EQ())).ToList();


            //------------------

            //var query2 = artistsDbList
            //              .Aggregate()
            //              .Project(i => new {
            //                  Id = i.Id,
            //                  Albums = i.Albums,
            //                  SongIds = i.Albums.Select(f => f.SongsIds.Select(o=> o))
            //              }).



            //              ToList();

            //var result = query.Select(e => new IncidentDto { Id = e.Id, ObjectsCount = e.ObjectIds.SelectMany(l => l).Distinct().Count() });


            //-----------------------
            //var bsonQuery = "{'Details.a':{$elemMatch:{$elemMatch:{DeviceName : /.*Name0.*/}}}}";
            //var filter = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(bsonQuery);

            //*******************
            //db.Artists.findOne({ "Albums":{ "$elemMatch":{ "Name":"Album 0_8"} } })

            //            db.Artists.findOne({ "Albums":{ "$elemMatch":{ "SongsIds":  {$elemMatch: { "$in":["dfdf"]
            //    }
            //}   }  }})

            //db.Artists2.findOne({"Albums":{$elemMatch:{"SongsIds":  {$elemMatch : {$in:["aaa"]}    }   }  }})
            //*******************

            //




            //-----------------TEST EU ------------------------





            //var bsonQuery = "{'Details.a':{$elemMatch:{$elemMatch:{DeviceName : /.*Name0.*/}}}}";
            //var filter = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(bsonQuery);


            //var result = col.FindSync(filter).ToList();

       

    //            db.Artists2.insertOne({ "Name": "test", "Albums": [ {"Name" :"alb1", "SongsIds":["d1622dcd-e6f1-4d98-a790-1297e615dc8e","bbb","ccc"]
    //} ] } )

            var bsonQuery = "{ 'Albums':{$elemMatch: { 'SongsIds':  {$elemMatch: {$in:['aaa'] }}   }  }})";
            var filter2 = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(bsonQuery);


            //Builders<TDocument>.Filter.AnyIn(x => x.Array, searchArray)
            //BsonDocument bson = new BsonDocument("_id", new BsonDocument("$in", new BsonArray(vins)));

            //var vins = new List<Guid>();

            //BsonDocument bson = new BsonDocument("_id", new BsonDocument("$in", new BsonArray(vins)));

            //var artistsddd = artistsDbList.Find(Builders<Artist>.Filter.ElemMatch(u => u.Albums, a => a.SongsIds.Intersect(songsIds).Any())).ToList();



           var ff =   Builders<Artist>.Filter.ElemMatch(x => x.Albums, Builders<Album>.Filter.AnyIn(x => x.SongsIds, allSongsIds) );
            var res = artistsDbList.Find(ff).ToList();





            //            db.Artists2.findOne({ "Albums":{$elemMatch: { "SongsIds":  {$elemMatch: {$in:["aaa"]  }}   }  }})



            var qArtists = artistsDbList.AsQueryable();
            var artists = from art in qArtists
                          where art.Albums.SelectMany(a => a.SongsIds).Intersect(allSongsIds).Any()
                          select new Artist
                          {
                              Name = art.Name,
                              Albums = new List<Album>()

                          };



            //var filter = Builders<Post>.Filter.ElemMatch(x => x.Tags, x => x.Name == "test");

                           //artistsDbList.Find();



            foreach (var artist in artists)
            {
                foreach( var album in artist.Albums)
                {
                    var songDTO = songsDTOList.Find(s => album.SongsIds.Contains(s.Id));
                    if(songDTO != null)
                    {
                        songDTO.Artist = artist.Name;
                        songDTO.Album = album.Name;
                        songDTO.AlbumUrlPicture = album.UrlPicture;
                        songDTO.Artist = artist.Name;
                    }

                }
            }


            //var query = from user in _context.Users
            //            join lib in _context.Libraries on user.LibraryId equals lib.Id
            //            join libSong in _context.LibrarySong on lib.Id equals libSong.LibraryId
            //            join song in _context.Songs on libSong.SongId equals song.Id
            //            join album in _context.Albums on song.AlbumId equals album.Id
            //            join artist in _context.Artists on album.ArtistId equals artist.Id

            //            where user.Id == filter.UserId
            //            && (song.Genre == filter.Genre || filter.Genre == null)
            //            //&& ( IsYearInDecade(song.Year, filter.Decade))
            //            && (song.PopularityRankingId == filter.PopularityRankingId || filter.PopularityRankingId == null)
            //            && (song.Genre == filter.Genre || filter.Genre == null)

            //            orderby (song.Name)
            //            select new SongDTO
            //            {
            //                Id = song.Id,
            //                Name = song.Name,
            //                Year = song.Year,
            //                Album = AlbumCoreConverter.ToShortDTO(album),
            //                Artist = ArtistCoreConverter.ToShortDTO(artist),
            //            };


            //int totalNumber = query.ToList().Count;
            //int totalNumber = query.ToList().Where(song => IsYearInDecade(song.Year, filter.Decade)).ToList().Count;

            //var songs = query.ToList().Where(song => IsYearInDecade(song.Year, filter.Decade)).Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).ToList();
            //return (totalNumber, songs);


            return (totalNumber, songsDTOList);
        }

        public  List<PopularityRankingDTO> GetPopularityRankings()
        {

            return popularityRankingsDbList.Find(a => true).ToList().Select(a => PopularityRankingCoreConverter.ToDTO(a)).ToList();
        }

        private bool IsYearInDecade(int year, DecadeEnum? decade)
        {
            if (decade == null)
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
