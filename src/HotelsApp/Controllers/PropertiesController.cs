namespace HotelsApp.Controllers
{
    using HotelsApp.Core.Contracts.Services;
    using HotelsApp.Core.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]/")]
    [ApiController]
    public class PropertiesController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IHereMapService _hereMapService;

        public PropertiesController(IBookingService bookingService, IHereMapService hereMapService)
        {
            _bookingService = bookingService;
            _hereMapService = hereMapService;
        }

        [HttpPost]
        public IActionResult Index(PropertyModel property)
        {
            try
            {
                var result = _bookingService.AddProperty(property);
                return Json(result);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        public async Task<IActionResult> Properties([FromQuery] string at)
        {
            //at=Lan,Log
            //TODO: Cache query result
            if (string.IsNullOrWhiteSpace(at)) return NotFound();

            var geoSettings = at.Split(',');
            if(geoSettings.Length != 2) return NotFound();

            try
            {
                var result = await _hereMapService.GetProperties(geoSettings[0].Trim(), geoSettings[1].Trim());
                return Json(result);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }

        }

        [HttpGet("{propertyId}/bookings")]
        public IActionResult GetBookings(string propertyId)
        {
            try
            {
                var result = _bookingService.GetBookings(propertyId);
                return Json(result);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}