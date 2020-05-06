using Common.Enums;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicMicroservice.Seeder
{
    public class AppSeeder
    {
        
        private readonly IMongoCollection<Song> songsDbList;
        private readonly IMongoCollection<PopularityRanking> popularityRankingDbList;
        private readonly IMongoCollection<Artist> artistsDbList;
        private readonly IMongoCollection<Library> libraryDbList;


        public const int ARTISTS_NR = 2;

        //public const int ARTISTS_NR = 100;
        //public const int ALBUMS_NR_PER_ARTIST = 9;
        public const int ALBUMS_NR_PER_ARTIST = 1;

        public const int SONGS_NR_PER_ALBUM = 10;
        public const int SONGS_PER_LIBRARY_NR = 100;
        public const int POPULARITY_RANKINGS_NR = 16;


        public AppSeeder(IConfiguration config)
        {
        MongoClient client = new MongoClient(config["ConnectionStrings:DefaultConnection"]);

            IMongoDatabase database = client.GetDatabase("MusicSpotMusic");
            songsDbList = database.GetCollection<Song>("Songs");
            popularityRankingDbList = database.GetCollection<PopularityRanking>("PopularityRankings");
            artistsDbList = database.GetCollection<Artist>("Artists");
            libraryDbList = database.GetCollection<Library>("Libraries");

        }

        public List<string> ARTISTS_PICTURES = new List<string>()
            {
                //Tailor Swift
                "https://i.insider.com/5e6f8652235c1811b7159ce3?width=1100&format=jpeg&auto=webp",
                //David Bowie
                "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.biography.com%2Fmusician%2Fdavid-bowie&psig=AOvVaw3v04PtniH87qEJrRl_4Cc0&ust=1587485796109000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCICMxsmz9-gCFQAAAAAdAAAAABAD",
                //Radiohead
                "https://www.rollingstone.com/wp-content/uploads/2020/03/Radiohead.jpg?resize=1800,1200&w=1800",
                //Nirvana
                "https://static.infomusic.ro/media/2014/02/nirvana-800x450.jpg",
                //Rolling Stones
                "https://content.eventim.com/static/uploaded/at/5ahl_300_300.jpg",
                //Justin Bieber
                "https://i2.wp.com/bitcoincodesverigerecension.com/wp-content/uploads/2020/01/Justin-Bieber.jpg?fit=1964%2C1964",
                //Drake
                "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.protv.ro%2Fdivertisment%2Fcum-arata-spectaculoasa-casa-a-lui-drake-din-toronto-are-propriul-teren-de-baschet-si-piscina-interioara.html&psig=AOvVaw08RvUOos7H-XCr83w_F441&ust=1587486022234000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCMCTuLW09-gCFQAAAAAdAAAAABAD",
                //Jonas Brothers
                "https://live.staticflickr.com/2361/2625522615_8c588c4e82_z.jpg",
                //Rammstein
                "https://townsquare.media/site/366/files/2019/09/%2525C2%2525A9JensKoch_Rammstein24579_lores.jpg?w=980&q=75",
                //Linkin Park
                "https://townsquare.media/site/366/files/2015/07/Linkin-Park.jpg?w=980&q=75",
                //Eminem
                "https://www.biography.com/.image/t_share/MTQ3NjM5MTEzMTc5MjEwODI2/eminem_photo_by_dave_j_hogan_getty_images_entertainment_getty_187596325.jpg",
                //Placebo
                "https://consequenceofsound.net/wp-content/uploads/2016/03/screen-shot-2016-03-13-at-9-57-58-pm.png?w=800",
                //Stromae
                "https://s12emagst.akamaized.net/products/28028/28027094/images/res_36dd7b730c8ab120326682043d945082_full.jpg",
                //Johann Sebastian Bach
                "https://miro.medium.com/max/1024/1*-Gho31goFmw3GIRG_2whpA.png",
                //Queens of the Stoneage
                "https://consequenceofsound.net/wp-content/uploads/2016/07/screen-shot-2016-07-14-at-10-24-32-pm.png?w=400&h=400&crop=1",
                //Mogwai
                "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSr962C3Ss9H_F6hhlwZceadpuxYZX-a3SWpOIwGEIKz07h1iLd&usqp=CAU",
                //Yelawolf
                "https://worshipthemusic.com/wp-content/uploads/2015/06/yelawolf-600x600.jpg",
                //Rihanna
                "https://virginradio.ro/wp-content/uploads/2018/09/Rihanna-septembrie-2017.jpg",
                //Paramore
                "https://i.ytimg.com/vi/aCyGvGEtOwc/maxresdefault.jpg",
                //The Pretty Reckless
                "https://tickx-artists.imgix.net/artistpic_265041_hero-1495029893.jpg?w=720&h=350&auto=format&q=60&fit=crop&crop=faces%2Cedges%2Centropy",
                //Justin Timberlake
                "https://www.allsaying.com/wp-content/uploads/2016/10/Top-10-Songs-of-Justin-Timberlake-Justin-Timberlake-Popular-Songs.jpg",

            };


        public List<string> ALBUMS_PICTURES = new List<string>()
            {
                "https://upload.wikimedia.org/wikipedia/en/2/2e/In_Rainbows_Official_Cover.jpg",
                "https://images-na.ssl-images-amazon.com/images/I/A1TYxlY-SFL._AC_SL1500_.jpg",
                "https://qph.fs.quoracdn.net/main-qimg-358c1786db0d6ea954c93f632bc6240d.webp",
                "https://e-cdns-images.dzcdn.net/images/artist/c3cbc4309cf09aec8914784270f194e4/264x264.jpg",
                "https://www.metallica.com/dw/image/v2/BCPJ_PRD/on/demandware.static/-/Sites-Metallica-Library/default/dw9360f051/images/releases/20150807_215637_7549_752897.jpg?sw=269&sh=269&sm=cut&sfrm=jpeg&q=95",
                "https://e.snmc.io/i/600/w/10ce683d71085969d370cfd61255ea99/2341279",
                "https://static.qobuz.com/images/covers/rc/fm/d9qon57o5fmrc_600.jpg",
                "https://s12emagst.akamaized.net/products/3121/3120739/images/res_fd2287403e8e7afa3b61955e8139151c_full.jpg",
                "https://upload.wikimedia.org/wikipedia/en/8/8c/Gore_-_Deftones.png",
                "https://bloody-disgusting.com/wp-content/uploads/2012/11/deftoneskoinoyokancover.jpeg",
                "https://upload.wikimedia.org/wikipedia/en/0/07/Imagine_Dragons_Next_to_Me.jpg",
                "https://miro.medium.com/max/770/1*MIxADvXPM188pkLOPAaixw.jpeg",
                "https://img.discogs.com/pwl-BAi_TOor6LA1VgwmmtzWANU=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-10850253-1505330937-9408.jpeg.jpg",
                "https://data.mothership.tools/mothershiptools-ukprod/wp-content/uploads/2019/02/thats-the-spirit.jpg",
                "https://static.infomusic.ro/media/2018/08/Bring-Me-The-Horizon-Amo-coperta-album-2019-600x600.jpg"
            };



        public void SeedAll()
        {
            SeedPopularityRankings();
            SeedArtistsAlbumsSongs();
            SeedSongsForLibraries();
        }


        private void SeedArtistsAlbumsSongs()
        {

            var random = new Random();

            if (artistsDbList.CountDocuments(a=>true) ==0)
            {
                var artists = new List<Artist>();
                for (int i = 0; i < ARTISTS_NR; i++)
                {
                    var artistId = Guid.NewGuid(); 
                    var artist = new Artist
                    {
                        Id = artistId,
                        Name = "Artist " + i,
                        UrlPicture = ARTISTS_PICTURES[random.Next(0, ARTISTS_PICTURES.Count)],
                        Albums = CreateAlbumsForArtist(artistId, i)
                };
                    artists.Add(artist);

                    //SeedAlbumsForArtist(artist.Id, i);

                }
                artistsDbList.InsertMany(artists);
            }
        }




        private List<Album> CreateAlbumsForArtist(Guid artistId, int artistIndex)
        {
            var random = new Random();

            var albums = new List<Album>();
            for (int i = 0; i < ALBUMS_NR_PER_ARTIST; i++)
            {
                var albumId = Guid.NewGuid();
                var songsIds = SeedSongsForAlbums(albumId, artistIndex, i);

                var album = new Album
                {
                    Id = albumId,
                    Name = "Album " + artistIndex + "_" + i,
                    UrlPicture = ALBUMS_PICTURES[random.Next(0, ALBUMS_PICTURES.Count)],
                    SongsIds = songsIds
                };
                albums.Add(album);

            }
            return albums;
        }

        private List<Guid> SeedSongsForAlbums(Guid albumId, int artistIndex, int albumIndex)
        {
            var popularityRankings = popularityRankingDbList.Find(a=> true).ToList();

            var random = new Random();

            var songs = new List<Song>();
            for (int i = 0; i < SONGS_NR_PER_ALBUM; i++)
            {
                var song = new Song
                {
                    Id = Guid.NewGuid(),
                    Name = "Song " + artistIndex + "_" + albumIndex + "_" + i,
                    PopularityRankingId = popularityRankings.ElementAt(random.Next(0, POPULARITY_RANKINGS_NR)).Id,
                    Year = random.Next(1960, 2020),
                    Genre = (GenreEnum)random.Next(0, 16),
                    Url = "https://www.youtube.com/watch?v=v4pi1LxuDHc"
                };
                songs.Add(song);

            }
            songsDbList.InsertMany(songs);
            return songs.Select(s => s.Id).ToList();

        }

        public void SeedSongsForLibraries()
        {
           
            var libraries = libraryDbList.Find(a => a.SongsIds == null || a.SongsIds.Count == 0).ToList();

            foreach( var library in libraries)
            {
                var random = new Random();
                var songs = songsDbList.Find(s=> true).ToList();
                var addedSongIds = new List<Guid>();

                for (var i = 0; i < SONGS_PER_LIBRARY_NR; i++)
                {
                    var songId = songs.Where(s => !addedSongIds.Contains(s.Id)).ElementAt(random.Next(0, songs.Count - addedSongIds.Count)).Id;
                    addedSongIds.Add(songId);
                }

                library.SongsIds = addedSongIds;
                libraryDbList.ReplaceOne(l=>l.Id == library.Id, library);
            }


            //    if (!_context.LibrarySong.Any())
            //    {
            //        var random = new Random();

            //        var libraries = _context.Libraries.ToList();
            //        var librarySongs = new List<LibrarySong>();

            //        foreach (var library in libraries)
            //        {
            //            var songs = _context.Songs.ToList();
            //            var addedSongIds = new List<Guid>();

            //            for (var i = 0; i < SONGS_PER_LIBRARY_NR; i++)
            //            {
            //                var librarySong = new LibrarySong()
            //                {
            //                    Id = Guid.NewGuid(),
            //                    LibraryId = library.Id,
            //                    SongId = songs.Where(s => !addedSongIds.Contains(s.Id)).ElementAt(random.Next(0, songs.Count - addedSongIds.Count)).Id
            //                };

            //                addedSongIds.Add(librarySong.Id);

            //                librarySongs.Add(librarySong);
            //            }

            //            _context.LibrarySong.AddRange(librarySongs);

            //        }
            //        _context.SaveChanges();
            //    }


        }





        private void SeedPopularityRankings()
        {
            if (popularityRankingDbList.CountDocuments(bms => true) == 0)
            {
                var popularityRankings = new List<PopularityRanking>();

                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in January 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in February 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in March 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in April 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in May 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in June 2019"
                });

                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in July 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in August 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in September 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in October 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in November 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in December 2019"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in January 2020"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in February 2020"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in March 2020"
                });

                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in April 2020"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in May 2020"
                });
                popularityRankings.Add(new PopularityRanking()
                {
                    Id = Guid.NewGuid(),
                    Name = "Top 100 in June 2020"
                });

               popularityRankingDbList.InsertMany(popularityRankings);
            }

         }
    }
}
