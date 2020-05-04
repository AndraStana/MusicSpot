using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class SongSimpleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsInLibrary { get; set; }
    }
}
