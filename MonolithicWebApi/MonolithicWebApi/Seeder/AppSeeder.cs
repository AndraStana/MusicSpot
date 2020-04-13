﻿using Common.Enums;
using Persistence.DAL;
using Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Seeder
{
    public class AppSeeder : IAppSeeder
    {
        public const int ARTISTS_NR = 100;
        public const int ALBUMS_NR = 100;
        public const int SONGS_NR = 1000;
        public const int SONGS_PER_LIBRARY_NR = 100;
        public const int POPULARITY_RANKINGS_NR = 16;
        public const int NEWS_NR = 20;

        private readonly AppDbContext _context;

        public AppSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void SeedAll()
        {
            SeedPopularityRankings();
            SeedArtists();
            SeedAlbums();
            SeedSongs();
            SeedLibrarySongs();
            SeedFriendships();
            SeedNews();

        }

        private void SeedArtists()
        {
            if (!_context.Artists.Any())
            {
                var artists = new List<Artist>();
                for (int i = 0; i < ARTISTS_NR; i++)
                {
                    var artist = new Artist
                    {
                        Id = Guid.NewGuid(),
                        Name = "Artist " + i
                    };
                    artists.Add(artist);

                }
                _context.Artists.AddRange(artists);
            }
            _context.SaveChanges();

        }

        private void SeedAlbums()
        {
            if (!_context.Albums.Any())
            {

                var artists = _context.Artists.ToList();
                var random = new Random();

                var albums = new List<Album>();
                for (int i = 0; i < ALBUMS_NR; i++)
                {
                    var album = new Album
                    {
                        Id = Guid.NewGuid(),
                        Name = "Album " + i,
                        ArtistId = artists.ElementAt(random.Next(0, ARTISTS_NR)).Id
                    };
                    albums.Add(album);

                }
                _context.Albums.AddRange(albums);
            }
            _context.SaveChanges();

        }

        private void SeedSongs()
        {
            if (!_context.Songs.Any())
            {
                var albums = _context.Albums.ToList();
                var popularotyRankings = _context.PopularityRankings.ToList();

                var random = new Random();

                var songs = new List<Song>();
                for (int i = 0; i < SONGS_NR; i++)
                {
                    var song = new Song
                    {
                        Id = Guid.NewGuid(),
                        Name = "Song " + i,
                        AlbumId = albums.ElementAt(random.Next(0, ALBUMS_NR - 1)).Id,
                        PopularityRankingId = popularotyRankings.ElementAt(random.Next(0, POPULARITY_RANKINGS_NR)).Id,
                        Year = random.Next(1960, 2020),
                        Genre = (GenreEnum)random.Next(0, 16),
                        Url = "https://www.youtube.com/watch?v=v4pi1LxuDHc"
                    };
                    songs.Add(song);

                }
                _context.Songs.AddRange(songs);
            }
            _context.SaveChanges();

        }

        public void SeedLibrarySongs()
        {

            if (!_context.LibrarySong.Any())
            {
                var random = new Random();

                var libraries = _context.Libraries.ToList();
                var librarySongs = new List<LibrarySong>();

                foreach (var library in libraries)
                {
                    var songs = _context.Songs.ToList();
                    var addedSongIds = new List<Guid>();

                    for (var i = 0; i < SONGS_PER_LIBRARY_NR; i++)
                    {
                        var librarySong = new LibrarySong()
                        {
                            Id = Guid.NewGuid(),
                            LibraryId = library.Id,
                            SongId = songs.Where(s => !addedSongIds.Contains(s.Id)).ElementAt(random.Next(0, SONGS_NR - addedSongIds.Count)).Id
                        };

                        addedSongIds.Add(librarySong.Id);

                        librarySongs.Add(librarySong);
                    }

                    _context.LibrarySong.AddRange(librarySongs);

                }
                _context.SaveChanges();
            }


        }

        public void SeedFriendships()
        {
            if (!_context.Friendships.Any())
            {
                var users = _context.Users.ToList();
                var friendships = new List<Friendship>();

                foreach (var user in users)
                {
                    var restOfUsers = users.Where(u => u.Id != user.Id).ToList();

                    foreach (var user2 in restOfUsers)
                    {
                        var friendship = new Friendship()
                        {
                            Id = Guid.NewGuid(),
                            FirstFriendId = user.Id,
                            SecondFriendId = user2.Id
                        };

                        friendships.Add(friendship);
                    }

                    _context.Friendships.AddRange(friendships);
                }
                _context.SaveChanges();
            }
        }

        public void SeedNews()
        {
            if (!_context.News.Any())
            {
                var news = new List<News>();
                for (int i = 0; i < NEWS_NR; i++)
                {
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Isle Of Wight Festival announces new dates and ticket details for 2021",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://www.banatulazi.ro/wp-content/uploads/2019/06/festival.jpg"

                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Billie Eilish warns fans of fake Snapchat account: “I’m sorry to those who have been scammed",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://static01.nyt.com/images/2020/03/15/magazine/15mag-billie-03/15mag-billie-03-mediumSquareAt3X-v3.jpg"
                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "The Weeknd shares three new songs from ‘After Hours’ deluxe album",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://img.discogs.com/K55jpWrMIcY1J5TshfZTz2_NQ1s=/600x750/smart/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/A-2171152-1578550845-1748.jpeg.jpg"
                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "The 1975 ask fans to “share moments from their lives” for new video",
                        CreationDate = DateTime.Now,
                        UrlPicture= "https://www.cheatsheet.com/wp-content/uploads/2020/01/The-1975-Me-and-You-Together-Song-1024x751.jpg"
                    });

                    //-------
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Placebo have signed with independent label So Recordings for the release of their next studio album",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://api.unsitedemuzica.ro/resized/articole/photo/placebo.jpg?w=1200"
                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Akon officially owns a city in Senegal and he's named it after himself",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://www.aceshowbiz.com/images/photo/akon.jpg"
                    });
                    //-------
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Ten years later, Bill and Tom Kaulitz tell MTV News what happened the night they won Best New Artist",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://lh3.googleusercontent.com/proxy/re_Cknd9yiQh6jO-CCZ00qUQ6zge8JXWS62vUPyDL4o1r01ypSlik_hVvG_-0-YFsSa6pemi0EzbGdz2mxC0uNx_7JIx_70KOKp9SHGbCXkuktZqds8VvOEVTv4"


                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Strictly Come Dancing: Radiohead frontman Thom Yorke says he was once asked to be on competition",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://static.independent.co.uk/s3fs-public/thumbnails/image/2019/09/11/20/gettyimages-1025888030.jpg"
                    });
                    //-------
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Twenty One Pilots to perform at 2020 Electric Castle festival in Romania",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://i.pinimg.com/originals/33/e5/a6/33e5a68527499d3e83188087b04be3f5.jpg"
                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Ludovico Einaudi gained the title of most-streamed classical music artist of all time",
                        CreationDate = DateTime.Now,
                        UrlPicture = "https://i.hurimg.com/i/hdn/75/0x0/5e33c8237152d80f2c9e3c5e.jpg"
                    });

                }
                _context.News.AddRange(news);

                _context.SaveChanges();
            }
        }



        private void SeedPopularityRankings()
        {
            if (!_context.PopularityRankings.Any())
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

                _context.PopularityRankings.AddRange(popularityRankings);
            }
            _context.SaveChanges();

        }
    }
}
