using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RolesApp.Models
{
    public class Room
    {
        //тут набор полей для комнаты будет список комнат
        public int Id { get; set; }
        public ICollection<BookingItem> Bookings{ get; set; } //предопределенная конструкция
        public string RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public string RoomAmount { get; set; }
        public string RoomCapacity { get; set; }
        public string RoomStatus { get; set; }
    }
}
