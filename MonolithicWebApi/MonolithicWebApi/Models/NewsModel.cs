using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Models
{
    public class NewsModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string UrlPicture { get; set; }

    }
}