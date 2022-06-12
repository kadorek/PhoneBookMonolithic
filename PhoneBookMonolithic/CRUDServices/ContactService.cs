using MongoDB.Driver;
using PhoneBookMonolithic.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;



namespace PhoneBookMonolithic.CRUDServices
{
    public class ContactService : IModelService
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public ContactService(IOptions<DatabaseSettings> dbSettings)
        {
            var mClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mDb = mClient.GetDatabase(dbSettings.Value.DatabaseName);
            _contactCollection = mDb.GetCollection<Contact>(dbSettings.Value.ContactsCollectionName);
        }

        public IEnumerable<IModel> GetAll() => _contactCollection.Find(x => true).ToList();

        public void Create(IModel _c)
        {
            _contactCollection.InsertOne((Contact)_c);

        }

        public IModel GetOne(string? id) => _contactCollection.Find(x => x.UUID == id).FirstOrDefault();

        public void Update(IModel c)
        {

            var entity = _contactCollection.Find(x => x.UUID == c.UUID).First();
            if (entity != null)
            {
                _contactCollection.ReplaceOne(x => x.UUID == entity.UUID, (Contact)c);
            }
            else
            {
                _contactCollection.InsertOne(entity);
            }
        }

        public void DeletOne(IModel c)
        {
            var entity = _contactCollection.Find(x => x.UUID == c.UUID).FirstOrDefault();
            if (entity != null)
            {
                _contactCollection.DeleteOne(x => x.UUID == entity.UUID);
            }
        }

    }
}
