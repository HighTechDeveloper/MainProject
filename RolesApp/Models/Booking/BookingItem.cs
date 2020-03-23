using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolesApp.Models
{
    public class BookingItem
    {
        public int Id { get; set; }
        public virtual Room Room { get; set; } //предопределенная конструкция для Entity Framework
        public int? IdRoom { get; set; } // тут ключ - одноименное и однотипное скуль.
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string AlternameMobileNo { get; set; }
        public string IDProof { get; set; }
        public DateTime BookFrom { get; set; }
        public DateTime BookTo { get; set; }
        public string NoOfMembers { get; set; }
    }
}
