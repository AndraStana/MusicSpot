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



        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }

        //[BsonElement("Brand")]
        //[Required]
        //public string Brand { get; set; }

        //[BsonElement("Model")]
        //[Required]
        //public string Model { get; set; }

        //[BsonElement("Year")]
        //[Required]
        //[YearRange]
        //public int Year { get; set; }

        //[BsonElement("Price")]
        //[Display(Name = "Price($)")]
        //[DisplayFormat(DataFormatString = "{0:#,0}")]
        //public decimal Price { get; set; }

        //[BsonElement("ImageUrl")]
        //[Display(Name = "Photo")]
        //[DataType(DataType.ImageUrl)]
        //[Required]
        //public string ImageUrl { get; set; }


    }
}
