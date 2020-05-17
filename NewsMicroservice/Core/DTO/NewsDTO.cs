using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class NewsDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string UrlPicture { get; set; }
        public string Source { get; set; }
    }
}
