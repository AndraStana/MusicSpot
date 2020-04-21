using Common.DALConverters;
using Common.Enums;
using Common.Interfaces.Services;
using Common.Shared;
using Core.CoreConverters;
using Core.DTO;
using Core.DTOs;
using Microsoft.EntityFrameworkCore;
using Persistence.DAL;
using Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _context;
        public LibraryService(AppDbContext context)
        {
            _context = context;
        }

        public Guid Add(LibraryDTO libraryDTO)
        {
            var library = LibraryCoreConverter.ToDAL(libraryDTO);

            library.Id = new Guid();

            _context.Libraries.Add(library);

            return library.Id;
        }

        public List<PopularityRankingDTO> GetPopularityRankings()
        {
            return _context.PopularityRankings.Select(p => PopularityRankingCoreConverter.ToDTO(p)).ToList();
        }

        public (int, List<SongDTO>) GetLibrarySongs(LibraryPageFilter filter)
        {
            //TODO OPTIMIZE QUERY PLEASEEEEE
            //TODO  correct filter and check if data is correct

            var query = from user in _context.Users
                        join lib in _context.Libraries on user.LibraryId equals lib.Id
                        join libSong in _context.LibrarySong on lib.Id equals libSong.LibraryId
                        join song in _context.Songs on libSong.SongId equals song.Id
                        join album in _context.Albums on song.AlbumId equals album.Id
                        join artist in _context.Artists on album.ArtistId equals artist.Id

                        where user.Id == filter.UserId
                        && (song.Genre == filter.Genre || filter.Genre == null)
                        //&& ( IsYearInDecade(song.Year, filter.Decade))
                        && (song.PopularityRankingId == filter.PopularityRankingId || filter.PopularityRankingId == null)
                        && (song.Genre == filter.Genre || filter.Genre == null)

                        orderby (song.Name)
                        select new SongDTO
                        {
                            Id = song.Id,
                            Name = song.Name,
                            Year = song.Year,
                            Album = AlbumCoreConverter.ToShortDTO(album),
                            Artist = ArtistCoreConverter.ToShortDTO(artist),
                        };


            //int totalNumber = query.ToList().Count;
            int totalNumber = query.ToList().Where(song => IsYearInDecade(song.Year, filter.Decade)).ToList().Count;

            var songs = query.ToList().Where(song => IsYearInDecade(song.Year, filter.Decade)).Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).ToList();
            return (totalNumber, songs);
        }


        public List<SongDTO> GetRecommendedSongs(BasicPageFilter filter)
        {
            var user = _context.Users
                    .Include(u => u.Library)
                    .ThenInclude(l => l.LibrarySong)
                    .ThenInclude(ls => ls.Song)
                    .ThenInclude(s => s.Album)

                .FirstOrDefault(u => u.Id == filter.UserId);

            var userArtistsIds = user.Library.LibrarySong.Select(ls => ls.Song.Album.ArtistId).Distinct();

            var allLibSongs = user.Library.LibrarySong.Select(ls => ls.SongId);


            var recommendedSongs = _context.SimilarArtistsRelationships
                .Where(r => userArtistsIds.Contains(r.SecondArtistId))
                .Include(a => a.SecondArtist)
                .ThenInclude(a => a.Albums)
                .ThenInclude(alb => alb.Songs)
                .ThenInclude(a => a.Album)
                .ThenInclude(a => a.Artist)


                .SelectMany(a=>a.SecondArtist.Albums.SelectMany(alb=>alb.Songs))
                .Where(rs => !allLibSongs.Contains(rs.Id))
                .Distinct()
                .OrderBy(s=>s.Name)
                .Skip(filter.PageIndex * filter.PageSize)
                .Take(filter.PageSize)
                .Select(s=> SongCoreConverter.ToLongDTO(s))
                .ToList() ;

            return recommendedSongs;

        }

        private bool IsYearInDecade(int year, DecadeEnum? decade)
        {
            if(decade == null)
            {
                return true;
            }

            switch (decade)
            {
                case DecadeEnum.D2010_2020:
                {
                        if(2010<=year && year< 2020)
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

        public void RemoveSongFromLibrary(Guid libraryId, Guid songId)
        {
            var libSong = _context.LibrarySong.FirstOrDefault(ls => ls.LibraryId == libraryId && ls.SongId == songId);
            _context.LibrarySong.Remove(libSong);
            _context.SaveChanges();
        }

        public void AddSongToLibrary(Guid libraryId, Guid songId)
        {
            var libSong = new LibrarySong()
            {
                Id = Guid.NewGuid(),
                LibraryId = libraryId,
                SongId = songId
            };

            _context.LibrarySong.Add(libSong);
            _context.SaveChanges();
        }

        public List<Guid> GetSongsIds(Guid libraryId)
        {
            return _context.LibrarySong.Where(ls => ls.LibraryId == libraryId).Select(ls => ls.SongId).ToList();
        }
    }
}
