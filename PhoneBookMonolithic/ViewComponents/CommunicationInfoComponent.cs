using Microsoft.AspNetCore.Mvc;
using PhoneBookMonolithic.CRUDServices;
using PhoneBookMonolithic.Models;
using System;

namespace PhoneBookMonolithic.ViewComponents
{
    public class CommunicationInfoComponent : ViewComponent
    {
        private readonly ContactService cs;
        private readonly LocationService ls;

        public CommunicationInfoComponent(ContactService c, LocationService l)
        {
            cs = c;
            ls = l;
        }

        public IViewComponentResult Invoke(int count, CommunicationInfo info)
        {
            if (info == null)
            {
                return View("InfoCreate", count);
            }
            else
            {
                return View("InfoEdit", new Tuple<int, CommunicationInfo>(count, info));
            }
        }

    }
}
