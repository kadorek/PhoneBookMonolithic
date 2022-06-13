using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace PhoneBookMonolithic.Models
{
    public class Report : IModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public List<ReportData> Data { get; set; }
        public ReportStatus Status { get; set; }

    }


    public class ReportData
    {
        public Location Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneCount { get; set; }

    }



    public enum ReportStatus
    {
        Preparing, Completed
    }

}
