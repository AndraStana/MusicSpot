using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class SimilarArtistsRelationship
    {
        public Guid Id { get; set; }
        public Guid FirstArtistId { get; set; }
        public Guid SecondArtistId { get; set; }

        public Artist FirstArtist { get; set; }
        public Artist SecondArtist { get; set; }
    }
}
