using System;

namespace Common.Models
{
    public class SongSimpleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsInLibrary { get; set; }
    }
}
