using Microsoft.AspNetCore.Mvc;
using PhoneBookMonolithic.CRUDServices;

namespace PhoneBookMonolithic.ViewComponents
{
    public class LocationComponent : ViewComponent
    {

        private readonly LocationService ls;
        public LocationComponent(LocationService ls)
        {
            this.ls = ls;
        }

        public IViewComponentResult Invoke(string id)
        {
            return View("Name", ls.GetOne(id));
        }

    }
}
