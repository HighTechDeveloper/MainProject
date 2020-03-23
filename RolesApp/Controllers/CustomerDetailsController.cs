using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolesApp.Models;
using RolesApp.Services;

namespace RolesApp.Controllers
{
    public class CustomerDetailsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ApplicationContext _context;
        public CustomerDetailsController(ApplicationContext context, IBookingService bookingService)
        {
            _context = context;  
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public List<BookingItem> GetList(RoomsQuery query)
        {
            var result = _context.Bookings.ToList();
            return result;
        }

        [HttpGet]
        public BookingItem GetNewItem()
        {
            var newRoom = new BookingItem
            {
                CustomerName = "Default CustomeName",
                Address = "Default Address",
                MobileNo = "Default MobileNo",
                AlternameMobileNo = "Default AlternameMobileNo",
                IDProof = "Default IDProof",
                BookFrom = System.DateTime.Now,
                BookTo = System.DateTime.Now,
                NoOfMembers = "Default NoOfMembers"
            };

            return newRoom;//_roomService.GetNewRoom();
        }



    }
}



