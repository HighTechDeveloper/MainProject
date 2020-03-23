using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RolesApp.Models;

namespace RolesApp.Services
{
    public class BookingService : IBookingService
    {
        public BookingItem GetNewBooking() => new BookingItem();
    }
}
