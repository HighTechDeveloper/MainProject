using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolesApp.Models
{
    public class RoomItem
    {
        //тут набор полей для комнаты будет список комнат
        public string RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public string RoomAmount { get; set; }
        public string RoomCapacity { get; set; }
        public string RoomStatus { get; set; }
    }
}
