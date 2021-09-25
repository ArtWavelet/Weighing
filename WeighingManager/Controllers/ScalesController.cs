using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeighingManager.Models;
using System.IO;
using WeighingManager.Services;
using WeighingManager.Helpers;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeighingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScalesController : ControllerBase
    {
        private WeightMeasurementStorageService _storage;
        public ScalesController(WeightMeasurementStorageService storage)
        {
            _storage = storage;
        }

        // GET: api/<ScalesController>
        [HttpGet]
        public string Get()
        {
            return "Up and running...";
        }

        // GET api/scales/summary/filter
        /// <summary>
        /// Get a filtered summary of the stored measurements.
        /// </summary>
        /// <param name="truck_id">Optional parameter: Example: "trckEOO725"</param>
        /// <param name="scale_id">Optional parameter: Example: "bsg_769"</param>
        /// <param name="month">Optional parameter: Example: "Jan", "Fen", "Mar", ...</param>
        /// <param name="unit">Optional parameter: Example: "kg", "pound", "ton"</param>
        [SwaggerResponse((int)HttpStatusCode.OK, "Summary of measurements", typeof(WeighingSummary))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [HttpGet("summary/filter")]
        public IActionResult Get(
            [FromQuery] string truck_id,
            [FromQuery] string scale_id,
            [FromQuery] string month,
            [FromQuery] string unit)
        {
            WeightUnit usedUnit = WeightUnit.kg;
            if (!string.IsNullOrWhiteSpace(unit))
            {
                if (!Enum.TryParse<WeightUnit>(unit.ToLower(), out usedUnit))
                    return BadRequest($"Unsupported unit: {unit}. Only Ton, Kg and Pound are supported.");
            }

            if (!string.IsNullOrWhiteSpace(month))
            {
                int monthNro = TimeHelper.MonthAbbreviationToNumber(month);
                if (monthNro == 0)
                {
                    return BadRequest($"Unsupported month abbreviation: {month}. Only Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov and Dec are supported.");
                }
            }

            return Ok(_storage.GetFilteredMeasurements(truck_id, scale_id, month, usedUnit));
        }

        // POST api/scales/import
        /// <summary>
        /// Import weight measurements in a json file.
        /// </summary>
        /// <param name="file">Required parameter: Example: file.json</param>
        [SwaggerResponse((int)HttpStatusCode.OK, "XX measurements added", typeof(WeighingSummary))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        [HttpPost("import")]
        public IActionResult Post([FromForm] IFormFile file)
        {
            if (file?.ContentType != "application/json")
                return StatusCode(415, "File format must be application/json.");

            int measurementsAdded = 0;
            string jsonString = "";
            try
            {
                if ((file?.Length ?? 0) > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        jsonString = System.Text.Encoding.UTF8.GetString(fileBytes);
                    }

                    List<WeightMeasurement> measurements = new();
                    try
                    {
                        measurements = JsonConvert.DeserializeObject<List<WeightMeasurement>>(jsonString);
                    }
                    catch(Exception ex)
                    {
                        StatusCode(422, "Problem deserializing the input file.");
                    }
                    measurementsAdded = _storage.AddRange(measurements);
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, "Something went wrong. Contact administrator.");
            }
            return Ok($"{measurementsAdded} measurements added");
        }
    }
}
