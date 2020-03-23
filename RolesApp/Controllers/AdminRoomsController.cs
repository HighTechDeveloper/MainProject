using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolesApp.Models;
using RolesApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Linq;

namespace RolesApp.Controllers
{
    public class AdminRoomsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly ApplicationContext _context;
        public AdminRoomsController(ApplicationContext context, IRoomService roomService)
        {
            _context = context; //ApplicationContext context и взаимодействовать только с сервисом
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public Room InsertItem([FromBody]Room model)
        {
            var allRooms = _context.Rooms;

            // если id > нуля , то мы находим запись, которуб нужно редактировать. и редактируем ее
            if (model.Id > 0) 
            {
                var item = _context.Rooms.FirstOrDefault(x => x.Id == model.Id);
                if (item != null)
                {
                    item.RoomNumber = model.RoomNumber;
                    item.RoomAmount = model.RoomAmount;
                    item.RoomStatus = model.RoomStatus;
                    item.RoomCapacity = model.RoomCapacity;
                    item.RoomDescription = model.RoomDescription;

                    _context.Rooms.Update(item);
                }    
            }
            else
            {
                if (allRooms.Count() < 50)
                {
                    _context.Rooms.Add(model);
                }
                else 
                {
                    return null;
                }
            }
           
            _context.SaveChanges();
            
            var ddd =  _context.Rooms.ToList();

            return new Room { RoomNumber = "test" };
        }

        [HttpPost]
        public bool RemoveItem([FromBody]int id)
        {       
            var item = _context.Rooms.FirstOrDefault(x => x.Id == id);
            _context.Rooms.Remove(item);

            var result = _context.SaveChanges() > 0;

            return result;
        }

        [HttpGet]
        public List<Room> GetList(RoomsQuery query)
        {
            var result = _context.Rooms.ToList();
            if(!string.IsNullOrEmpty(query.SearchString) && result.Any())
            {
                result = result.Where(x =>!string.IsNullOrEmpty(x.RoomNumber) && x.RoomNumber.Contains(query.SearchString)).ToList();
            }
            var res = new Room()
            {
                RoomNumber = "123",
                RoomDescription = "Room Description",
                RoomAmount = "RoomAmount",
                RoomCapacity = "RoomCapacity",
                RoomStatus = "RoomStatus"
            };
            //var res = _postCreditUserService.GetPostCreditUsers(query.Page, query.SearchString, query.SortType, query.SortDirection, false);
            return result;
        }

        [HttpGet]
        public RoomItem GetNewItem()
        {
            var newRoom = new RoomItem
            {
                RoomNumber = "123",
                RoomDescription = "Room Description",
                RoomAmount = "RoomAmount",
                RoomCapacity = "RoomCapacity",
                RoomStatus = "RoomStatus"
            };

            return newRoom;//_roomService.GetNewRoom();
        }
    }
}



 