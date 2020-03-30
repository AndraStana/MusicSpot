using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public GenreEnum Genre { get; set; }
        public string Url { get; set; }

        public Guid AlbumId { get; set; }
        public Album Album { get; set; }

        public List<LibrarySong> LibrarySong { get; set; }

        public Guid? PopularityRankingId { get; set; }
        public PopularityRanking? PopularityRanking { get; set; }
    }
}
