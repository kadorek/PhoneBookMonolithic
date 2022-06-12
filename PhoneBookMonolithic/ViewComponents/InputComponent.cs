using Microsoft.AspNetCore.Mvc;
using PhoneBookMonolithic.CRUDServices;
using PhoneBookMonolithic.Models;
using System;

namespace PhoneBookMonolithic.ViewComponents
{
    public class InputComponent : ViewComponent
    {
        private readonly LocationService ls;

        public InputComponent(LocationService ls)
        {
            this.ls = ls;

        }

        public IViewComponentResult Invoke(int count, string data, CommunicationInfoType tip)
        {
            switch (tip)
            {
                case CommunicationInfoType.Adress:
                    return View("GenericInput", new Tuple<int, string>(count, data));
                    break;
                case CommunicationInfoType.Email:
                    return View("GenericInput", new Tuple<int, string>(count, data));
                    break;
                case CommunicationInfoType.Phone:
                    return View("GenericInput", new Tuple<int, string>(count, data));
                    break;
                case CommunicationInfoType.Location:
                    var list = ls.GetAllAsSelecListItem(data);
                    ViewData.Add("Locations",list);
                    return View("LocationInput", new Tuple<int, string>(count, data));
                    break;
                default:
                    return View("GenericInput", new Tuple<int, string>(count, data));
                    break;
            }
        }

    }
}
