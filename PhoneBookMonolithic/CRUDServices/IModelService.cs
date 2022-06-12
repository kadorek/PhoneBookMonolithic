using PhoneBookMonolithic.Models;
using System.Collections.Generic;

namespace PhoneBookMonolithic.CRUDServices
{
    public interface IModelService
    {
        void Create(IModel m);
        void DeletOne(IModel m);
        IEnumerable<IModel> GetAll();
        IModel GetOne(string id);
        void Update(IModel m);
    }
}