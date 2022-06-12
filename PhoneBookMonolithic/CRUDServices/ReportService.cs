
using MongoDB.Driver;
using PhoneBookMonolithic.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;


namespace PhoneBookMonolithic.CRUDServices
{
    public class ReportService:IModelService
    {
        private readonly IMongoCollection<Report> _reportCollection;
        public ReportService(IOptions<DatabaseSettings> dbSettings)
        {
            var mClient=new MongoClient(dbSettings.Value.ConnectionString);
            var mDb=mClient.GetDatabase(dbSettings.Value.DatabaseName);
            _reportCollection = mDb.GetCollection<Report>(dbSettings.Value.ReportsCollectionName);
        }

        public void Create(IModel m)=>  _reportCollection.InsertOne((Report)m);
        
        public void DeletOne(IModel m)
        {
            var entity = _reportCollection.Find(x => x.UUID == m.UUID).FirstOrDefault();
            if (entity != null)
                _reportCollection.DeleteOne(x=>x.UUID==entity.UUID);

        }

        public IModel GetOne(string id)=>_reportCollection.Find(x=>x.UUID==id).FirstOrDefault();

        public void Update(IModel m)
        {
            var entity = _reportCollection.Find(x => x.UUID == m.UUID).First();
            if (entity != null)
            {
                _reportCollection.ReplaceOne(x => x.UUID == entity.UUID, (Report)m);
            }
            else
            {
                _reportCollection.InsertOne(entity);
            }

        }

       public IEnumerable<IModel> GetAll() => _reportCollection.Find(x => true).ToList();
    }
}
