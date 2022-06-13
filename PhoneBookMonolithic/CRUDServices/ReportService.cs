
using MongoDB.Driver;
using PhoneBookMonolithic.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PhoneBookMonolithic.CRUDServices
{
    public class ReportService : IModelService
    {
        private readonly IMongoCollection<Report> _reportCollection;
        private readonly LocationService ls;
        private readonly ContactService cs;
        public ReportService(IOptions<DatabaseSettings> dbSettings)
        {
            var mClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mDb = mClient.GetDatabase(dbSettings.Value.DatabaseName);
            _reportCollection = mDb.GetCollection<Report>(dbSettings.Value.ReportsCollectionName);
            ls = new LocationService(dbSettings);
            cs = new ContactService(dbSettings);
        }

        public void Create(IModel m)
        {
            _reportCollection.InsertOne((Report)m);
        }

        public async Task CreateAsync(Report m)
        {
            await _reportCollection.InsertOneAsync(m);
            UpdateAsync(m);
        }

        public void DeletOne(IModel m)
        {
            var entity = _reportCollection.Find(x => x.UUID == m.UUID).FirstOrDefault();
            if (entity != null)
                _reportCollection.DeleteOne(x => x.UUID == entity.UUID);

        }

        public IModel GetOne(string id) => _reportCollection.Find(x => x.UUID == id).FirstOrDefault();

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

        public async Task UpdateAsync(Report m)
        {

            var allLocations = await ls.GetAllAsync();
            var allContacts = await cs.GetAllAsync();

            var result = new List<ReportData>();

            foreach (var loc in allLocations)
            {
                var rd = new ReportData() { Location = loc };
                foreach (var con in allContacts)
                {
                    if (con.CommuncationInfos.Where(x => x.InfoType == CommunicationInfoType.Location && x.Value==loc.UUID).Count() > 0)
                    {
                        rd.ContactCount++;
                        foreach (var info in con.CommuncationInfos)
                        {
                            if (info.InfoType == CommunicationInfoType.Phone)
                            {
                                rd.PhoneCount++;
                            }
                        }
                    }
                }
                result.Add(rd);
            }
            m.Data = result;
            m.Status = ReportStatus.Completed;
            await _reportCollection.ReplaceOneAsync(x => x.UUID == m.UUID, m);
        }

        public IEnumerable<IModel> GetAll() => _reportCollection.Find(x => true).ToList();
    }
}
