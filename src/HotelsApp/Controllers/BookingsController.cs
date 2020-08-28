namespace HotelsApp.Controllers
{
    using HotelsApp.Core.Contracts.Services;
    using HotelsApp.Core.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]/")]
    [ApiController]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult Index(BookingModel booking)
        {
            try
            {
                var result = _bookingService.NewBooking(booking);
                return Json(result);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}