using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace RolesApp.Controllers
{
    public class BillDetailsController : Controller
    {
        public BillDetailsController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}



