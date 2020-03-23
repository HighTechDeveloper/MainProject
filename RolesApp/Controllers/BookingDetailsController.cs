using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolesApp.Models;
using RolesApp.Services;
using System.Linq;


namespace RolesApp.Controllers
{
    public class BookingDetailsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ApplicationContext _context;
        public BookingDetailsController(ApplicationContext context, IBookingService bookingService)
        {
            _context = context; //ApplicationContext context и взаимодействовать только с сервисом
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

        [HttpPost]
        public BookingItem InsertItem([FromBody]BookingItem model)
        {
            var allRooms = _context.Rooms;
            // если id > нуля , то мы находим запись, которуб нужно редактировать. и редактируем ее
            if (model.Id > 0)
            {
                var item = _context.Bookings.FirstOrDefault(x => x.Id == model.Id);
                if (item != null)
                {
                    item.CustomerName = model.CustomerName;
                    item.Address = model.Address;
                    item.MobileNo = model.MobileNo;
                    item.AlternameMobileNo = model.AlternameMobileNo;
                    item.IDProof = model.IDProof;
                    item.BookFrom = model.BookFrom;
                    item.BookTo = model.BookTo;
                    item.NoOfMembers = model.NoOfMembers;

                    _context.Bookings.Update(item);
                }
            }
            else
            {
                if (allRooms.Count() < 50)
                {
                     _context.Bookings.Add(model);
                }
                else
                {
                    return null;
                }
 
            }

            _context.SaveChanges();

            var ddd = _context.Bookings.ToList();

            return new BookingItem { CustomerName = "test" };
        }

        [HttpPost]
        public bool RemoveItem([FromBody]int id)
        {
            var item = _context.Bookings.FirstOrDefault(x => x.Id == id);
            _context.Bookings.Remove(item);

            var result = _context.SaveChanges() > 0;

            return result;
        }

    }
}



