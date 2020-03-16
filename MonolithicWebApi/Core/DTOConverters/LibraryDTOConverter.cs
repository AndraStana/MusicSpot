using Core.DTO;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTOConverters
{
    public static class LibraryDTOConverter
    {
        public static LibraryDTO ToDTO(Library library)
        {
            if(library == null)
            {
                return null;
            }

            return new LibraryDTO()
            {
                Id = library.Id,
                Name = library.Name
            };

        }
    }
}
