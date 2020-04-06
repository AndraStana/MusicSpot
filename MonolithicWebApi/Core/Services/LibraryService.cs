using Common.DALConverters;
using Common.Interfaces.Services;
using Common.Shared;
using Core.CoreConverters;
using Core.DTO;
using Core.DTOs;
using Microsoft.EntityFrameworkCore;
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

        public int GetSongsNumber(Guid userId)
        {
            return _context.Users
                    .Include(u=>u.Library)
                    .ThenInclude(l => l.LibrarySong)
                .FirstOrDefault(u => u.Id == userId)
                .Library.LibrarySong.Count();
        }

        public List<PopularityRankingDTO> GetPopularityRankings()
        {
            return _context.PopularityRankings.Select(p => PopularityRankingCoreConverter.ToDTO(p)).ToList();
        }

        public List<SongDTO> GetLibrarySongs(LibraryPageFilter filter)
        {
           
            //TODO  correct filter and check if data is correct

            var query = from user in _context.Users
                        join lib in _context.Libraries on user.LibraryId equals lib.Id
                        join libSong in _context.LibrarySong on lib.Id equals libSong.LibraryId
                        join song in _context.Songs on libSong.SongId equals song.Id
                        join album in _context.Albums on song.AlbumId equals album.Id
                        join artist in _context.Artists on album.ArtistId equals artist.Id

                        where user.Id == filter.UserId
                        orderby (song.Name)
                        select new SongDTO
                        {
                            Id = song.Id,
                            Name = song.Name,
                            Year = song.Year,
                            Album = AlbumCoreConverter.ToDTO(album),
                            Artist = ArtistCoreConverter.ToDTO(artist),
                            Url = song.Url,
                        };
            return query.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).ToList();
        }
    }
}
