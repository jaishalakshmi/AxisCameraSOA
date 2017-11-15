using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AxiscamWeb.Models;

namespace AxiscamWeb.Controllers
{
    [RoutePrefix("api/CamLog")]
    public class CamLogController : ApiController
    {
        [Route("logs")]
        [ResponseType(typeof(List<CamLogData>))]
        public IHttpActionResult GetCamLogs()
        {
            //TODO: read log file from camera log location.
            //camaxilogparser. //
            List<CamLogData> logs = new List<CamLogData>();
            for (int i = 0; i < 50; i++)
            {
                logs.Add(new CamLogData()
                {
                    DetectedTime = DateTime.Now.Add(TimeSpan.FromMinutes(-i)),
                    IsDetected = i % 2 == 0
                });
            }

            return Ok(logs);
        }


    }
}
