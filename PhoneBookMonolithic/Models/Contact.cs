using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace PhoneBookMonolithic.Models
{
    public class Contact:IModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public string FullName => $"{Ad} {Soyad}";
        public List<CommunicationInfo> CommuncationInfos { get; set; }

        public Contact()
        {
            CommuncationInfos = new List<CommunicationInfo>();
        }

        internal void CreateContactInfos(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                CommuncationInfos.Add(new CommunicationInfo());
            }
        }

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


