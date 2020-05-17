using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class NewsDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string UrlPicture { get; set; }
        public SourceDTO Source { get; set; }
    }

}