using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.DAL
{
    public class News
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Description")]
        [Required]
        public string Description { get; set; }

        [BsonElement("CreationDate")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreationDate { get; set; }

        [BsonElement("UrlPicture")]
        [Required]
        public string UrlPicture { get; set; }
        public Source Source { get; set; }

    }
}
