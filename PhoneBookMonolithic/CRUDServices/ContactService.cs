using MongoDB.Driver;
using PhoneBookMonolithic.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;



namespace PhoneBookMonolithic.CRUDServices
{
    public class ContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public ContactService(IOptions<DatabaseSettings> dbSettings)
        {
            var mClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mDb = mClient.GetDatabase(dbSettings.Value.DatabaseName);
            _contactCollection = mDb.GetCollection<Contact>(dbSettings.Value.ContactsCollectionName);
        }

        public List<Contact> GetAll() => _contactCollection.Find(x=>true).ToList();

        public void Create(Contact _c) {
            _contactCollection.InsertOne(_c);
        
        }

        

    }
}
