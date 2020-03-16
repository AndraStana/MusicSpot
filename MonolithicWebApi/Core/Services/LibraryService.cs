using Common.DALConverters;
using Common.DTOConverters;
using Common.Interfaces.Services;
using Core.DTO;
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
            var library = LibraryDALConverter.ToDAL(libraryDTO);

            library.Id = new Guid();

            _context.Libraries.Add(library);

            return library.Id;
        }
    }
}
