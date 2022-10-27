using EITBackend.Common.Models;
using EITBackend.Common.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("[controller]")]
    public class PostBookingHistoryController : ControllerBase
    {


        private readonly ILogger<PostBookingHistoryController> _logger;
        private readonly IBookingHistoryService BookingHistoryService;
        private DataContext context;
        public PostBookingHistoryController(IBookingHistoryService BookingHistoryService, ILogger<PostBookingHistoryController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpPost(Name = "PostBookingHistory")]
        public ActionResult<BookingHistory> PostBookingHistory([FromBody] BookingHistory bookingHistory)
        {
            BookingHistoryService.PostBookingHistory(bookingHistory);
            return Ok();
        }
    }
}
