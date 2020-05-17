using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class News
    {
        public Guid Id {get;set;}
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string UrlPicture { get; set; }
        public Guid SourceId { get; set; }
        public Source Source { get; set; }
    }
}
