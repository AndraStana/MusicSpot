using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces.Services
{
    public interface ILibraryService
    {
        Guid Add(LibraryDTO library);
    }
}
