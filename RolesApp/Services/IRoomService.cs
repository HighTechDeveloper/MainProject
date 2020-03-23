using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RolesApp.Models;

namespace RolesApp.Services
{
    public interface IRoomService
    {
        RoomItem GetNewRoom();

        //bool InsertOrUpdateItem(Room model);//так для каждой операции  и в сервисе все это реализовать
    }
}

