using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.App
{
    [Route("api/heartbeats")]
    public sealed class HeartbeatsController : Controller
    {
        [HttpGet]
        public bool Get()
        {
            return true;
        }

        [HttpHead]
        public bool Head()
        {
            return true;
        }
    }
}
