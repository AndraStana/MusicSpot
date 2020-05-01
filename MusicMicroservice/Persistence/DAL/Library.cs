using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.DAL
{
    public class Library
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }

    }
}
