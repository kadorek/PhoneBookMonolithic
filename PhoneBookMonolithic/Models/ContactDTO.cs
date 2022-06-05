using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookMonolithic.Models
{
    public class ContactDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        [Display(Name="Bilgi Türü")]
        public CommunicationInfoType InfoType { get; set; }
        public string Value { get; set; }
    }
}
