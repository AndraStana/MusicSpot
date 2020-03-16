using Core.DTO;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DALConverters
{
    public class LibraryDALConverter
    {
        public static Library ToDAL(LibraryDTO libraryDTO)
        {
            if (libraryDTO == null)
            {
                return null;
            }

            return new Library()
            {
                Id = libraryDTO.Id,
                Name = libraryDTO.Name
            };

        }
    }
}
