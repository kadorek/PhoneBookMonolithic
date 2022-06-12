using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PhoneBookMonolithic.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookMonolithic.CRUDServices
{
    public class LocationService
    {
        private readonly IMongoCollection<Location> _locationCollection;
        public LocationService(IOptions<DatabaseSettings> dbSettings)
        {
            var mClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mDb = mClient.GetDatabase(dbSettings.Value.DatabaseName);
            _locationCollection = mDb.GetCollection<Location>(dbSettings.Value.LocationsCollectionName);
        }

        public IEnumerable<Location> GetAll() => _locationCollection.Find(x => true).ToList();

        public IModel GetOne(string id) => _locationCollection.Find(x => x.UUID == id).FirstOrDefault();

        public IEnumerable<SelectListItem> GetAllAsSelecListItem()
        {
            var list = GetAll();
            var result = (from x in list
                          select new SelectListItem { Text = x.Name, Value = x.UUID }).ToList();
            return result;
        }
        public IEnumerable<SelectListItem> GetAllAsSelecListItem(string v)
        {
            var list = GetAll();
            var result = (from x in list
                          select new SelectListItem { Text = x.Name, Value = x.UUID ,Selected=x.UUID==v}).ToList();
            return result;
        }


    }
}
