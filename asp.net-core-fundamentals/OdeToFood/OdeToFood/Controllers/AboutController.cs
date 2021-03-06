﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("about")]
    //[ Route ( "[controller]/[action]" ) ]
    public class AboutController
    {
        [Route("")]
        public string Index()
        {
            return ( Address() + " / " + Phone() );
        }

        [Route("phone")]
        public string Phone()
        {
            return "1+(777)-777-7777";
        }

        [Route("address")]
        public string Address()
        {
            return "Denver, Colorado USA";
        }

    }
}
