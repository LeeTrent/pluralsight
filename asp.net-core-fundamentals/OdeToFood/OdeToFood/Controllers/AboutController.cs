using System;
namespace OdeToFood.Controllers
{
    public class AboutController
    {
        public AboutController()
        {
        }
        public string Index()
        {
            return ( Address() + " / " + Phone() );
        }
        public string Phone()
        {
            return "1+(777)-777-7777";
        }
        public string Address()
        {
            return "Denver, Colorado USA";
        }

    }
}
