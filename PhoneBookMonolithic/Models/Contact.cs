using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace PhoneBookMonolithic.Models
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public string FullName => $"{Ad} {Soyad}";
        public List<CommunicationInfo> CommuncationInfos { get; set; }

    }
}

/*
 
 UUID
• Ad
• Soyad
• Firma
• İletişim Bilgisi
o Bilgi Tipi: Telefon Numarası, E-mail Adresi, Konum
o Bilgi İçeriği
 
 */


