using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Album> Albums { get; set; }

        public List<SimilarArtistsRelationship> FirstArtists { get; set; }
        public List<SimilarArtistsRelationship> SecondArtists { get; set; }


    }
}
