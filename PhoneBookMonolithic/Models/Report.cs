using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PhoneBookMonolithic.Models
{
    public class Report:IModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneNumberCount { get; set; }
        public ReportStatus Status { get; set; }

    }


    public enum ReportStatus
    {
        Preparing, Completed
    }

}
