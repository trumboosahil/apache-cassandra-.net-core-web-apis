using Cassandra;
using CassandraAPI.app;
using CassandraAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CassandraAPI.Controllers
{
    public class AirqualityController : ControllerBase
    {
        private readonly AirQuality airQuality;
        public AirqualityController(AirQuality airQuality)
        {
            this.airQuality = airQuality;
        }
        [Route("airquality/GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid uid)
        {
            var list = await airQuality.GetAirqualitytsAsync(uid);
            return Ok(list);

        }
        [Route("airquality/Add")]
        [HttpPost]
        public async Task<IActionResult> AddReading([FromBody] Airqualityts airQualityts)
        {
            await airQuality.SaveAirQualityTs(airQualityts);

            return Ok("done");
        }

    }
}
