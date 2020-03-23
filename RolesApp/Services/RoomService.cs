using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RolesApp.Models;

namespace RolesApp.Services
{
    public class RoomService : IRoomService
    {
        public RoomItem GetNewRoom() => new RoomItem();
    }
}
