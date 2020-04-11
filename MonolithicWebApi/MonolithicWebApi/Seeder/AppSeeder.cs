using Common.Enums;
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
        public const int NEWS_NR = 25;



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
                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "Billie Eilish warns fans of fake Snapchat account: “I’m sorry to those who have been scammed",
                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "The Weeknd shares three new songs from ‘After Hours’ deluxe album",
                    });
                    news.Add(new News
                    {
                        Id = Guid.NewGuid(),
                        Description = "The 1975 ask fans to “share moments from their lives” for new video",
                    });

                    _context.News.AddRange(news);
                }
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
