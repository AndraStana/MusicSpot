using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.DAL
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Username")]
        [Required]
        public string Username { get; set; }

        [BsonElement("Email")]
        [Required]
        public string Email { get; set; }

        [BsonElement("YearOfBirth")]
        [Required]
        public int YearOfBirth { get; set; }

        [BsonElement("LibraryId")]
        public Guid LibraryId { get; set; }

    }
}
