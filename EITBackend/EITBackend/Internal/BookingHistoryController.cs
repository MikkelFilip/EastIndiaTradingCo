using EITBackend.Common.DTOs;
using EITBackend.Common.Models;
using EITBackend.Common.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("[controller]")]
    public class BookingHistoryController : ControllerBase
    {
        private readonly ILogger<BookingHistoryController> _logger;
        private readonly IBookingHistoryService BookingHistoryService;
        private DataContext context;
        public BookingHistoryController(IBookingHistoryService BookingHistoryService, ILogger<BookingHistoryController> logger, DataContext context)
        {
            _logger = logger;
            this.BookingHistoryService = BookingHistoryService;
            this.context = context;
        }

        [HttpPost(Name = "PostBookingHistory")]
        public ActionResult<BookingHistory> PostBookingHistory([FromBody] BookingHistory request)
        {
            try
            {
                var result = BookingHistoryService.PostBookingHistory(request);
                return Ok(result);
            } catch (SmtpException ex)
            {
                return StatusCode(503, ex.Message);
            }
            
        }

        [HttpGet("GetMostUsedRoutes")]
        public ActionResult<List<MostUsedRoute>> GetMostUsedRoutes()
        {
            return Ok(BookingHistoryService.GetMostUsedRoutes());
        }
    }
}
