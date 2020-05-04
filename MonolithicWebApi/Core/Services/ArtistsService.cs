using Common.Shared;
using Core.CoreConverters;
using Core.DTOs;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class ArtistsService : IArtistsService
    {
        private readonly AppDbContext _context;
        public ArtistsService(AppDbContext context)
        {
            _context = context;
        }


        public List<ArtistDTO> GetArtists(ArtistsPageFilter filter)
        {
            return _context.Artists.Include(a => a.Albums)
                 .ThenInclude(alb => alb.Songs)
                 .Where(a => a.Name.Contains(filter.SearchText))
                 .OrderBy(a => a.Name)
                 .Skip(filter.PageIndex * filter.PageSize)
                 .Take(filter.PageSize)
                 .Select(a => ArtistCoreConverter.ToLongDTO(a))
                 .ToList();
        }
    }
}
